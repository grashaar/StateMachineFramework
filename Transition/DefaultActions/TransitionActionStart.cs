using System;

namespace StateMachineFramework
{
    internal sealed class TransitionActionStart : TransitionActionBase
    {
        private const string DefaultName = "Start";

        private readonly Action<ITransitionAction, TransitionArgs> action;

        internal TransitionActionStart(Action<ITransitionAction, TransitionArgs> action) : this(DefaultName, action) { }

        internal TransitionActionStart(string name, Action<ITransitionAction, TransitionArgs> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnStart(TransitionArgs args)
        {
            this.action(this, args);
        }

        protected override void OnFinish() { }

        protected override void OnIntialize() { }
    }
}
