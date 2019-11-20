using System;

namespace StateMachineFramework
{
    internal sealed class SignalActionProcess : SignalActionBase
    {
        private const string DefaultName = "Process";

        private readonly Action<ISignalAction> action;

        internal SignalActionProcess(Action<ISignalAction> action) : this(DefaultName, action) { }

        internal SignalActionProcess(string name, Action<ISignalAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnProcess()
        {
            this.action(this);
        }

        protected override void OnEmit() { }

        protected override void OnNotProcess(SignalNotProcessedArgs args) { }
    }
}
