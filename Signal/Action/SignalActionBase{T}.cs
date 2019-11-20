namespace StateMachineFramework
{
    public class SignalActionBase<T> : SignalActionBase, ISignalAction<T>
    {
        public new ISignal<T> Signal
        {
            get => this.signal;
            set => SetSignal(value);
        }

        private ISignal<T> signal;

        public SignalActionBase() : this(null) { }

        public SignalActionBase(string name) : base(name) { }

        protected void SetSignal(ISignal<T> value)
        {
            this.signal = value;
            base.SetSignal(value);
        }
    }
}
