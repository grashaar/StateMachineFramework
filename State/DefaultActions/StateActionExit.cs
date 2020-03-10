using System;

namespace StateMachineFramework
{
    internal sealed class StateActionExit : StateActionBase
    {
        private const string DefaultName = "Exit";

        private readonly Action<IStateAction> action;

        internal StateActionExit(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionExit(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnExit()
        {
            this.action(this);
        }
    }
}
