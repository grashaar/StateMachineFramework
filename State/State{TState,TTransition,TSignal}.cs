using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public sealed partial class State<TState, TTransition, TSignal>
        : State<TState>, IState<TState, TTransition, TSignal>
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

        private readonly StateActionList actions;

        internal State(TState name) : base(name)
        {
            this.TransitionsI = new Dictionary<Transition<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>>();

            this.OrthogonalsI = new Dictionary<int, Orthogonal<TState, TTransition, TSignal>> {
                { 0, new Orthogonal<TState, TTransition, TSignal>(this, 0) }
            };

            this.actions = new StateActionList();
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

        internal bool AddTransition(Transition<TState, TTransition, TSignal> transition, State<TState, TTransition, TSignal> state)
        {
            if (this.TransitionsI.ContainsKey(transition))
            {
                return false;
            }

            this.TransitionsI.Add(transition, state);
            return true;
        }

        internal bool AddInnerState(State<TState, TTransition, TSignal> innerState, int index = 0)
        {
            if (!this.OrthogonalsI.ContainsKey(index))
            {
                if (!AddOrthogonal(index))
                {
                    return false;
                }
            }

            innerState.HasParentState = true;
            innerState.ParentState = this;
            return this.OrthogonalsI[index].Machine.AddState(innerState);
        }

        internal bool SetInitialInnerState(State<TState, TTransition, TSignal> innerState, int index = 0)
        {
            if (this.OrthogonalsI.Count <= 0)
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

        internal bool SetStateMachine(StateMachine<TState, TTransition, TSignal> machine)
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

        internal bool AddOrthogonal(int index)
        {
            if (this.OrthogonalsI.Count == index)
            {
                this.OrthogonalsI.Add(index, new Orthogonal<TState, TTransition, TSignal>(this, index));
                return true;
            }

            return false;
        }

        internal void Enter()
        {
            this.IsCurrentState = true;
            this.actions.Enter();

            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.Machine.Initialize();
            }
        }

        internal void Resume()
        {
            this.actions.Resume();
        }

        internal void LateEnter()
        {
            this.actions.LateEnter();
        }

        internal void Exit()
        {
            this.IsCurrentState = false;
            this.actions.Exit();

            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.Machine.Terminate();
            }
        }

        internal void Terminate()
        {
            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.Machine.Terminate();
            }

            this.actions.Terminate();
            this.IsCurrentState = false;
        }

        internal void Update()
        {
            this.actions.Update();

            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.Machine.Tick();
            }
        }

        internal void PassSignal(Signal<TState, TTransition, TSignal> signal)
        {
            foreach (var orthogonal in this.OrthogonalsI.Values)
            {
                orthogonal.Machine.ProcessSignal(signal);
            }
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
        protected override IReadOnlyDictionary<int, IOrthogonal> GetOrthogonalMachines()
            => this.OrthogonalsI.ToDictionary(x => x.Key, x => x.Value as IOrthogonal);
    }
}
