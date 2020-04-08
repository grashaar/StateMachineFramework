using System;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionTerminate : StateMachineActionBase
    {
        private const string DefaultName = "Terminate";

        private readonly Action<IStateMachineAction> action;

        internal StateMachineActionTerminate(Action<IStateMachineAction> action) : this(DefaultName, action) { }

        internal StateMachineActionTerminate(string name, Action<IStateMachineAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnTerminate()
        {
            this.action(this);
        }

        protected override void OnInitialize() { }

        protected override void OnStateChange(IState former, IState current) { }
    }
}
