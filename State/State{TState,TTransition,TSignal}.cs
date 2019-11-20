using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public sealed partial class State<TState, TTransition, TSignal> : State<TState>, IState<TState, TTransition, TSignal>
    {
        public State<TState, TTransition, TSignal> ParentState { get; internal set; }

        public StateMachine<TState, TTransition, TSignal> Machine
            => this.MachineI;

        public IReadOnlyList<Transition<TState, TTransition, TSignal>> Transitions
            => this.TransitionsI.Keys.ToList();

        public override IReadOnlyList<IStateAction> Actions
            => this.actions;

        public IReadOnlyDictionary<int, Orthogonal<TState, TTransition, TSignal>> Orthogonals
            => this.OrthogonalsI;

        /// <summary>
        /// Internal <see cref="Machine"/>
        /// </summary>
        internal StateMachine<TState, TTransition, TSignal> MachineI { get; private set; }

        /// <summary>
        /// Internal <see cref="Transitions"/>
        /// </summary>
        internal Dictionary<Transition<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> TransitionsI { get; }

        /// <summary>
        /// Internal <see cref="Orthogonals"/>
        /// </summary>
        internal Dictionary<int, Orthogonal<TState, TTransition, TSignal>> OrthogonalsI { get; }

        private readonly List<Orthogonal<TState, TTransition, TSignal>> orthogonalUpdate;
        private readonly StateActionList actions;

        internal State(TState name) : base(name)
        {
            this.TransitionsI = new Dictionary<Transition<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>>();

            this.OrthogonalsI = new Dictionary<int, Orthogonal<TState, TTransition, TSignal>> {
                { 0, new Orthogonal<TState, TTransition, TSignal>(this, 0) }
            };

            this.orthogonalUpdate = new List<Orthogonal<TState, TTransition, TSignal>>();
            this.actions = new StateActionList();
        }

        public bool AddTransition(Transition<TState, TTransition, TSignal> transition, State<TState, TTransition, TSignal> state)
        {
            if (this.TransitionsI.ContainsKey(transition))
            {
                return false;
            }

            this.TransitionsI.Add(transition, state);
            return true;
        }

        public bool AddOrthogonal(int index)
        {
            if (this.OrthogonalsI.Count == index)
            {
                this.OrthogonalsI.Add(index, new Orthogonal<TState, TTransition, TSignal>(this, index));
                return true;
            }

            return false;
        }

        public bool AddInnerState(State<TState, TTransition, TSignal> innerState, int index = 0)
        {
            if (!this.OrthogonalsI.ContainsKey(index))
            {
                if (!AddOrthogonal(index))
                {
                    return false;
                }
            }

            this.HasInnerState = true;
            innerState.HasParentState = true;
            innerState.ParentState = this;
            return this.OrthogonalsI[index].Machine.AddState(innerState);
        }

        public override bool AddAction(IStateAction action)
        {
            if (action == null || this.actions.Contains(action))
                return false;

            switch (action)
            {
                case IStateAction<TState, TTransition, TSignal> actionSTS:
                    actionSTS.State = this;
                    break;

                case IStateAction<TState> actionT:
                    actionT.State = this;
                    break;

                default:
                    action.State = this;
                    break;
            }

            this.actions.Add(action);
            return true;
        }

        public bool SetInitialInnerState(State<TState, TTransition, TSignal> innerState, int index = 0)
        {
            if (!this.HasInnerState)
            {
                return false;
            }

            if (!this.OrthogonalsI.ContainsKey(index))
            {
                if (!AddOrthogonal(index))
                {
                    return false;
                }
            }

            return this.OrthogonalsI[index].Machine.SetInitialState(innerState);
        }

        public bool SetStateMachine(StateMachine<TState, TTransition, TSignal> machine)
        {
            if (this.MachineI != null || machine == null)
                return false;

            this.MachineI = machine;

            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.ConnectStateChangedEvent();
            }

            return true;
        }

        internal void Enter()
        {
            this.IsCurrentState = true;
            this.actions.Enter();

            if (this.HasInnerState)
            {
                foreach (var orthogonal in this.OrthogonalsI.Values)
                {
                    orthogonal.Machine.Initialize();
                }
            }
        }

        internal void Exit()
        {
            this.IsCurrentState = false;
            this.actions.Exit();

            if (this.HasInnerState)
            {
                foreach (var orthogonal in this.OrthogonalsI.Values)
                {
                    orthogonal.Machine.Terminate();
                }
            }
        }

        internal void Terminate()
        {
            if (this.HasInnerState)
            {
                foreach (var orthogonal in this.OrthogonalsI.Values)
                {
                    orthogonal.Machine.Terminate();
                }
            }

            this.actions.Terminate();
            this.IsCurrentState = false;
        }

        internal void Update()
        {
            this.actions.Update();

            if (this.HasInnerState)
            {
                this.orthogonalUpdate.Clear();
                this.orthogonalUpdate.AddRange(this.OrthogonalsI.Values);

                foreach (var orthogonal in this.orthogonalUpdate)
                {
                    orthogonal.Machine.Tick();
                }
            }
        }

        internal bool PassSignal(Signal<TState, TTransition, TSignal> signal)
        {
            var signalProcessed = false;

            if (this.HasInnerState)
            {
                foreach (var orthogonal in this.OrthogonalsI.Values)
                {
                    if (orthogonal.Machine.ProcessSignal(signal))
                    {
                        signalProcessed = true;
                    }
                }
            }

            return signalProcessed;
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IStateMachine GetMachine()
            => this.MachineI;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IReadOnlyList<ITransition> GetTransitions()
            => this.TransitionsI.Keys.ToList();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IReadOnlyDictionary<int, IOrthogonal> GetOrthogonals()
            => this.OrthogonalsI.ToDictionary(x => x.Key, x => x.Value as IOrthogonal);
    }
}
