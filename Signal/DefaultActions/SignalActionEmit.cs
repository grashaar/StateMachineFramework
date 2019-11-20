using System;

namespace StateMachineFramework
{
    internal sealed class SignalActionEmit : SignalActionBase
    {
        private const string DefaultName = "Emit";

        private readonly Action<ISignalAction> action;

        internal SignalActionEmit(Action<ISignalAction> action) : this(DefaultName, action) { }

        internal SignalActionEmit(string name, Action<ISignalAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnEmit()
        {
            this.action(this);
        }

        protected override void OnProcess() { }

        protected override void OnNotProcess(SignalNotProcessedArgs args) { }
    }
}
