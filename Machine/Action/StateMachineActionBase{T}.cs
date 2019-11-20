namespace StateMachineFramework
{
    public class StateMachineActionBase<T> : StateMachineActionBase, IStateMachineAction<T>
    {
        public StateMachineActionBase() : this(null) { }

        public StateMachineActionBase(string name) : base(name) { }

        public void StateChange(IState<T> priorState, IState<T> formerState)
        {
            OnStateChange(priorState, formerState);
        }

        protected virtual void OnStateChange(IState<T> priorState, IState<T> formerState) { }

        protected sealed override void OnStateChange(IState priorState, IState formerState) { }
    }
}
