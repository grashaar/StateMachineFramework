using System;

namespace StateMachineFramework
{
    internal sealed class TransitionActionFinish : TransitionActionBase
    {
        private const string DefaultName = "Finish";

        private readonly Action<ITransitionAction> action;

        internal TransitionActionFinish(Action<ITransitionAction> action) : this(DefaultName, action) { }

        internal TransitionActionFinish(string name, Action<ITransitionAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnFinish()
        {
            this.action(this);
        }

        protected override void OnStart(TransitionArgs args) { }

        protected override void OnInvoke(TransitionArgs args) { }

        protected override void OnIntialize() { }
    }
}
