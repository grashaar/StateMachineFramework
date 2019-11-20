namespace StateMachineFramework
{
    public class StateActionBase<T> : StateActionBase, IStateAction<T>
    {
        public new IState<T> State
        {
            get => this.state;
            set => SetState(value);
        }

        private IState<T> state;

        public StateActionBase() : this(null) { }

        public StateActionBase(string name) : base(name) { }

        protected void SetState(IState<T> state)
        {
            this.state = state;
            base.SetState(state);
        }
    }
}