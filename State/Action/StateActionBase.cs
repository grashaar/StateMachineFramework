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

        public void Enter(IState previous)
        {
            Initialize();

            OnEnter(previous);
        }

        public void Resume(IState next)
        {
            OnResume(next);
        }

        public void LateEnter(IState previous)
        {
            OnLateEnter(previous);
        }

        public void Exit(IState next)
        {
            OnExit(next);
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

        protected virtual void OnEnter(IState previous) { }

        protected virtual void OnResume(IState next) { }

        protected virtual void OnLateEnter(IState previous) { }

        protected virtual void OnExit(IState next) { }

        protected virtual void OnUpdate() { }

        protected virtual void OnTerminate() { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
