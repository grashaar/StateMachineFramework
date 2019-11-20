using System;

namespace StateMachineFramework
{
    internal sealed class StateActionUpdate : StateActionBase
    {
        private const string DefaultName = "Update";

        private readonly Action<IStateAction> action;

        internal StateActionUpdate(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionUpdate(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnUpdate()
        {
            this.action(this);
        }

        protected override void OnInitialize() { }

        protected override void OnEnter() { }

        protected override void OnExit() { }

        protected override void OnTerminate() { }
    }
}
