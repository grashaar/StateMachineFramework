namespace StateMachineFramework
{
    public class TransitionActionBase : ITransitionAction
    {
        public string Name { get; protected set; }

        public ITransition Transition
        {
            get => this.transition;
            set => SetTransition(value);
        }

        private ITransition transition;
        private bool initialized = false;

        public TransitionActionBase() : this(null) { }

        public TransitionActionBase(string name)
        {
            this.Name = name ?? "Untitled";
        }

        public void Start(TransitionArgs args)
        {
            Initialize();

            OnStart(args);
        }

        public void Finish()
        {
            OnFinish();
        }

        private void Initialize()
        {
            if (this.initialized)
                return;

            OnIntialize();
            this.initialized = true;
        }

        protected void SetTransition(ITransition value)
            => this.transition = value;

        protected virtual void OnIntialize() { }

        protected virtual void OnStart(TransitionArgs args) { }

        protected virtual void OnFinish() { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
