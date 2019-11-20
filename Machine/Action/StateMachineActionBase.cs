namespace StateMachineFramework
{
    public class StateMachineActionBase : IStateMachineAction
    {
        public string Name { get; protected set; }

        public IStateMachine Machine
        {
            get => this.machine;
            set => SetMachine(value);
        }

        private IStateMachine machine;

        public StateMachineActionBase() : this(null) { }

        public StateMachineActionBase(string name)
        {
            this.Name = name ?? "Untitled";
        }

        public void Initialize()
        {
            OnInitialize();
        }

        public void StateChange(IState priorState, IState formerState)
        {
            OnStateChange(priorState, formerState);
        }

        public void Terminate()
        {
            OnTerminate();
        }

        protected virtual void OnInitialize() { }

        protected virtual void OnStateChange(IState priorState, IState formerState) { }

        protected virtual void OnTerminate() { }

        protected void SetMachine(IStateMachine machine)
            => this.machine = machine;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
