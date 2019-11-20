using System;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionInitialize : StateMachineActionBase
    {
        private const string DefaultName = "Initialize";

        private readonly Action<IStateMachineAction> action;

        internal StateMachineActionInitialize(Action<IStateMachineAction> action) : this(DefaultName, action) { }

        internal StateMachineActionInitialize(string name, Action<IStateMachineAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnInitialize()
        {
            this.action(this);
        }

        protected override void OnStateChange(IState priorState, IState formerState) { }

        protected override void OnTerminate() { }
    }
}
