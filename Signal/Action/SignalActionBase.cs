namespace StateMachineFramework
{
    public class SignalActionBase : ISignalAction
    {
        public string Name { get; protected set; }

        public ISignal Signal
        {
            get => this.signal;
            set => SetSignal(value);
        }

        private ISignal signal;

        public SignalActionBase() : this(null) { }

        public SignalActionBase(string name)
        {
            this.Name = name ?? "Untitled";
        }

        public void Emit()
        {
            OnEmit();
        }

        public void Process()
        {
            OnProcess();
        }

        public void NotProcess(SignalNotProcessedArgs args)
        {
            OnNotProcess(args);
        }

        protected void SetSignal(ISignal value)
            => this.signal = value;

        protected virtual void OnEmit() { }

        protected virtual void OnProcess() { }

        protected virtual void OnNotProcess(SignalNotProcessedArgs args) { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
