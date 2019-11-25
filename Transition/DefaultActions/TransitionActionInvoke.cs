using System;

namespace StateMachineFramework
{
    internal sealed class TransitionActionInvoke : TransitionActionBase
    {
        private const string DefaultName = "Invoke";

        private readonly Action<ITransitionAction, TransitionArgs> action;

        internal TransitionActionInvoke(Action<ITransitionAction, TransitionArgs> action) : this(DefaultName, action) { }

        internal TransitionActionInvoke(string name, Action<ITransitionAction, TransitionArgs> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnInvoke(TransitionArgs args)
        {
            this.action(this, args);
        }

        protected override void OnStart(TransitionArgs args) { }

        protected override void OnFinish() { }

        protected override void OnIntialize() { }
    }
}
