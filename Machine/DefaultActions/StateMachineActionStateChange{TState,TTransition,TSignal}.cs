using System;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionStateChange<TState, TTransition, TSignal>
        : StateMachineActionBase<TState, TTransition, TSignal>
    {
        private readonly static string DefaultName = $"StateChange<{typeof(TState).Name}, {typeof(TTransition).Name}, {typeof(TSignal).Name}>";

        private readonly Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action;

        internal StateMachineActionStateChange(Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
            : this(DefaultName, action) { }

        internal StateMachineActionStateChange(string name, Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
            : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnStateChange(State<TState, TTransition, TSignal> former, State<TState, TTransition, TSignal> current)
        {
            this.action(this, former, current);
        }

        protected override void OnInitialize() { }

        protected override void OnTerminate() { }
    }
}
