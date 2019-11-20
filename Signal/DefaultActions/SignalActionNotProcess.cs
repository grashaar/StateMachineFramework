using System;

namespace StateMachineFramework
{
    internal sealed class SignalActionNotProcess : SignalActionBase
    {
        private const string DefaultName = "NotProcess";

        private readonly Action<ISignalAction, SignalNotProcessedArgs> action;

        internal SignalActionNotProcess(Action<ISignalAction, SignalNotProcessedArgs> action) : this(DefaultName, action) { }

        internal SignalActionNotProcess(string name, Action<ISignalAction, SignalNotProcessedArgs> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnNotProcess(SignalNotProcessedArgs args)
        {
            this.action(this, args);
        }

        protected override void OnEmit() { }

        protected override void OnProcess() { }
    }
}
