using System;

namespace StateMachineFramework
{
    internal sealed class StateActionEnter : StateActionBase
    {
        private const string DefaultName = "Enter";

        private readonly Action<IStateAction> action;

        internal StateActionEnter(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionEnter(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnEnter(IState previous)
        {
            this.action(this);
        }
    }
}
