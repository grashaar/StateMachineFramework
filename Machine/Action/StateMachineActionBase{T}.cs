namespace StateMachineFramework
{
    public class StateMachineActionBase<T> : StateMachineActionBase, IStateMachineAction<T>
    {
        public StateMachineActionBase() : this(null) { }

        public StateMachineActionBase(string name) : base(name) { }

        public void StateChange(IState<T> former, IState<T> current)
        {
            OnStateChange(former, current);
        }

        protected virtual void OnStateChange(IState<T> former, IState<T> current) { }

        protected sealed override void OnStateChange(IState former, IState current) { }
    }
}
