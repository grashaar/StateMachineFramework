namespace StateMachineFramework
{
    public class StateActionBase<TState, TTransition, TSignal> : StateActionBase<TState>, IStateAction<TState, TTransition, TSignal>
    {
        public new State<TState, TTransition, TSignal> State
        {
            get => this.state;
            set => SetState(value);
        }

        private State<TState, TTransition, TSignal> state;

        public StateActionBase() : this(null) { }

        public StateActionBase(string name) : base(name) { }

        protected void SetState(State<TState, TTransition, TSignal> state)
        {
            this.state = state;
            base.SetState(state);
        }
    }
}