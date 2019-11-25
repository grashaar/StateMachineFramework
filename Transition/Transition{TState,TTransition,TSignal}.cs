using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public sealed partial class Transition<TState, TTransition, TSignal> : Transition<TTransition>, ITransition<TState, TTransition, TSignal>
    {
        private enum Status
        {
            Idle, Starting, Finishing
        }

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

        public override IReadOnlyList<ITransitionCondition> StartConditions
            => this.startConditions;

        public override IReadOnlyList<ITransitionCondition> FinishConditions
            => this.finishConditions;

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
        private readonly TransitionConditionList startConditions;
        private readonly TransitionConditionList finishConditions;

        private Status status;
        private Signal<TState, TTransition, TSignal> signal;

        internal Transition(StateMachine<TState, TTransition, TSignal> machine, TTransition name) : base(name)
        {
            this.MachineI = machine;
            this.CanTransitionI = true;
            this.SignalsI = new List<Signal<TState, TTransition, TSignal>>();

            this.actions = new TransitionActionList();
            this.startConditions = new TransitionConditionList();
            this.finishConditions = new TransitionConditionList();

            this.status = Status.Idle;
            this.signal = null;
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

        public override bool AddStartCondition(ITransitionCondition condition)
        {
            if (condition == null || this.startConditions.Contains(condition))
                return false;

            this.startConditions.Add(condition);
            return true;
        }

        public override bool AddFinishCondition(ITransitionCondition condition)
        {
            if (condition == null || this.finishConditions.Contains(condition))
                return false;

            this.finishConditions.Add(condition);
            return true;
        }

        public override void Terminate()
        {
            var signal = this.signal;
            this.status = Status.Idle;
            this.signal = null;

            this.MachineI.TerminateTransition(this, signal);
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
                return false;

            this.SignalsI.Add(signal);
            return true;
        }

        internal bool Invoke(Signal<TState, TTransition, TSignal> signal)
        {
            var args = new TransitionArgs();
            this.actions.Invoke(args);

            if (args.CancelTransition)
                return false;

            this.signal = signal;
            this.status = Status.Starting;
            return true;
        }

        internal void Update()
        {
            switch (this.status)
            {
                case Status.Starting:
                    if (this.startConditions.Validate())
                    {
                        this.MachineI.StartTransition(this, this.signal);
                        this.status = Status.Finishing;
                    }
                    break;

                case Status.Finishing:
                    if (this.finishConditions.Validate())
                    {
                        this.MachineI.FinishTransition(this);
                    }
                    break;
            }
        }

        internal bool Start()
        {
            var args = new TransitionArgs();
            this.actions.Start(args);

            if (args.CancelTransition)
                return false;

            return true;
        }

        internal void Finish()
        {
            this.status = Status.Idle;
            this.signal = null;
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