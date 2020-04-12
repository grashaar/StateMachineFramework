using System;

namespace StateMachineFramework
{
    internal sealed class StateActionLateEnter : StateActionBase
    {
        private const string DefaultName = "LateEnter";

        private readonly Action<IStateAction> action;

        internal StateActionLateEnter(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionLateEnter(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnLateEnter(IState previous)
        {
            this.action(this);
        }
    }
}
