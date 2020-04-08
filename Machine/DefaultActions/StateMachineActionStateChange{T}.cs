using System;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionStateChange<T> : StateMachineActionBase<T>
    {
        private readonly static string DefaultName = $"StateChange<{typeof(T).Name}>";

        private readonly Action<IStateMachineAction, IState<T>, IState<T>> action;

        internal StateMachineActionStateChange(Action<IStateMachineAction, IState<T>, IState<T>> action) : this(DefaultName, action) { }

        internal StateMachineActionStateChange(string name, Action<IStateMachineAction, IState<T>, IState<T>> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnStateChange(IState<T> former, IState<T> current)
        {
            this.action(this, former, current);
        }

        protected override void OnInitialize() { }

        protected override void OnTerminate() { }
    }
}
