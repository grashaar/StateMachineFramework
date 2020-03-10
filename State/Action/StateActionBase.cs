namespace StateMachineFramework
{
    public class StateActionBase : IStateAction
    {
        public string Name { get; protected set; }

        public IState State
        {
            get => this.state;
            set => SetState(value);
        }

        private bool initialized = false;
        private IState state;

        public StateActionBase() : this(null) { }

        public StateActionBase(string name)
        {
            this.Name = name ?? "Untitled";
        }

        public void Enter()
        {
            Initialize();

            OnEnter();
        }

        public void Resume()
        {
            OnResume();
        }

        public void LateEnter()
        {
            OnLateEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        public void Update()
        {
            OnUpdate();
        }

        public void Terminate()
        {
            OnTerminate();
        }

        protected void SetState(IState state)
            => this.state = state;

        private void Initialize()
        {
            if (this.initialized)
                return;

            OnInitialize();
            this.initialized = true;
        }

        protected virtual void OnInitialize() { }

        protected virtual void OnEnter() { }

        protected virtual void OnResume() { }

        protected virtual void OnLateEnter() { }

        protected virtual void OnExit() { }

        protected virtual void OnUpdate() { }

        protected virtual void OnTerminate() { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
