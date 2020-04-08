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

        public void StateChange(IState former, IState current)
        {
            OnStateChange(former, current);
        }

        public void Terminate()
        {
            OnTerminate();
        }

        protected virtual void OnInitialize() { }

        protected virtual void OnStateChange(IState former, IState current) { }

        protected virtual void OnTerminate() { }

        protected void SetMachine(IStateMachine machine)
            => this.machine = machine;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
