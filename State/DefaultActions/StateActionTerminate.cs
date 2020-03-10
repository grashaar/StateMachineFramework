using System;

namespace StateMachineFramework
{
    internal sealed class StateActionTerminate : StateActionBase
    {
        private const string DefaultName = "Terminate";

        private readonly Action<IStateAction> action;

        internal StateActionTerminate(Action<IStateAction> action) : this(DefaultName, action) { }

        internal StateActionTerminate(string name, Action<IStateAction> action) : base(name ?? DefaultName)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        protected override void OnTerminate()
        {
            this.action(this);
        }
    }
}
