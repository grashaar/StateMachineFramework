using System;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionStateChange : StateMachineActionBase
    {
        private const string DefaultName = "StateChange";

        private readonly Action<IStateMachineAction, IState, IState> action;

        internal StateMachineActionStateChange(Action<IStateMachineAction, IState, IState> action) : this(DefaultName, action) { }

        internal StateMachineActionStateChange(string name, Action<IStateMachineAction, IState, IState> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnStateChange(IState former, IState current)
        {
            this.action(this, former, current);
        }

        protected override void OnInitialize() { }

        protected override void OnTerminate() { }
    }
}
