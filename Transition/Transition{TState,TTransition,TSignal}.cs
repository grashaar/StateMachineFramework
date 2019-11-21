using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public sealed partial class Transition<TState, TTransition, TSignal> : Transition<TTransition>, ITransition<TState, TTransition, TSignal>
    {
        public override bool CanTransition
            => this.CanTransitionI;

        public StateMachine<TState, TTransition, TSignal> Machine
            => this.MachineI;

        public IReadOnlyList<Signal<TState, TTransition, TSignal>> Signals
            => this.SignalsI;

        public State<TState, TTransition, TSignal> StartState
            => this.StartStateI;

        public State<TState, TTransition, TSignal> EndState
            => this.EndStateI;

        public override IReadOnlyList<ITransitionAction> Actions
            => this.actions;

        /// <summary>
        /// Internal <see cref="Machine"/>
        /// </summary>
        internal StateMachine<TState, TTransition, TSignal> MachineI { get; }

        /// <summary>
        /// Internal <see cref="Signals"/>
        /// </summary>
        internal List<Signal<TState, TTransition, TSignal>> SignalsI { get; }

        /// <summary>
        /// Internal <see cref="StartState"/>
        /// </summary>
        internal State<TState, TTransition, TSignal> StartStateI { get; private set; }

        /// <summary>
        /// Internal <see cref="EndState"/>
        /// </summary>
        internal State<TState, TTransition, TSignal> EndStateI { get; private set; }

        /// <summary>
        /// Internal <see cref="CanTransition"/>
        /// </summary>
        internal bool CanTransitionI { get; set; }

        private readonly TransitionActionList actions;

        internal Transition(StateMachine<TState, TTransition, TSignal> machine, TTransition name) : base(name)
        {
            this.MachineI = machine;
            this.CanTransitionI = true;
            this.SignalsI = new List<Signal<TState, TTransition, TSignal>>();
            this.actions = new TransitionActionList();
        }

        internal Transition(StateMachine<TState, TTransition, TSignal> machine, TTransition name, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState) : this(machine, name)
        {
            SetTransition(startState, endState);
        }

        public override bool AddAction(ITransitionAction action)
        {
            if (action == null || this.actions.Contains(action))
                return false;

            switch (action)
            {
                case ITransitionAction<TState, TTransition, TSignal> actionSTS:
                    actionSTS.Transition = this;
                    break;

                case ITransitionAction<TTransition> actionT:
                    actionT.Transition = this;
                    break;

                default:
                    action.Transition = this;
                    break;
            }

            this.actions.Add(action);
            return true;
        }

        internal bool SetTransition(State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState)
        {
            if (this.StartStateI == null && this.EndStateI == null)
            {
                this.StartStateI = startState;
                this.EndStateI = endState;
                return true;
            }

            return false;
        }

        internal bool AddSignal(Signal<TState, TTransition, TSignal> signal)
        {
            if (this.SignalsI.Exists(ts => ts.Name.Equals(signal.Name)))
            {
                return false;
            }

            this.SignalsI.Add(signal);
            return true;
        }

        internal bool Start()
        {
            var args = new TransitionArgs();
            this.actions.Start(args);

            if (args.CancelTransition)
            {
                return false;
            }

            return true;
        }

        internal void Finish()
        {
            this.actions.Finish();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IStateMachine GetMachine()
            => this.MachineI;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IReadOnlyList<ISignal> GetSignals()
            => this.SignalsI;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IState GetStartState()
            => this.StartStateI;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override IState GetEndState()
            => this.EndStateI;
    }
}