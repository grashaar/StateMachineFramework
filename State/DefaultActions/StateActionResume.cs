using System;

namespace StateMachineFramework
{
    internal sealed class StateActionResume : StateActionBase
    {
        private const string DefaultName = "Resume";

        private readonly Action<IStateAction> action;

        internal StateActionResume(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionResume(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnResume()
        {
            this.action(this);
        }
    }
}
