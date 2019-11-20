namespace StateMachineFramework
{
    public class SignalActionBase<TState, TTransition, TSignal> : SignalActionBase<TSignal>, ISignalAction<TState, TTransition, TSignal>
    {
        public new Signal<TState, TTransition, TSignal> Signal
        {
            get => this.signal;
            set => SetSignal(value);
        }

        private Signal<TState, TTransition, TSignal> signal;

        public SignalActionBase() : this(null) { }

        public SignalActionBase(string name) : base(name) { }

        protected void SetSignal(Signal<TState, TTransition, TSignal> value)
        {
            this.signal = value;
            base.SetSignal(value);
        }
    }
}
