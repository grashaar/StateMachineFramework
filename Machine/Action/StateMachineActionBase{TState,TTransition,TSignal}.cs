namespace StateMachineFramework
{
    public class StateMachineActionBase<TState, TTransition, TSignal>
        : StateMachineActionBase<TState>, IStateMachineAction<TState, TTransition, TSignal>
    {
        public new StateMachine<TState, TTransition, TSignal> Machine
        {
            get => this.machine;
            set => SetMachine(value);
        }

        private StateMachine<TState, TTransition, TSignal> machine;

        public StateMachineActionBase() : this(null) { }

        public StateMachineActionBase(string name) : base(name) { }

        protected void SetMachine(StateMachine<TState, TTransition, TSignal> machine)
        {
            this.machine = machine;
            base.SetMachine(machine);
        }

        public void StateChange(State<TState, TTransition, TSignal> former, State<TState, TTransition, TSignal> current)
        {
            OnStateChange(former, current);
        }

        protected virtual void OnStateChange(State<TState, TTransition, TSignal> former, State<TState, TTransition, TSignal> current) { }

        protected sealed override void OnStateChange(IState<TState> former, IState<TState> current) { }
    }
}
