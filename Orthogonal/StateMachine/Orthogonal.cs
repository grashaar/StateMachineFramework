namespace StateMachineFramework
{
    public sealed partial class Orthogonal<TState, TTransition, TSignal>
        : IOrthogonal<TState, TTransition, TSignal>
    {
        public int Index { get; }

        public StateMachine<TState, TTransition, TSignal> Machine { get; }

        public State<TState, TTransition, TSignal> OfState { get; }

        public State<TState, TTransition, TSignal> CurrentState
            => this.Machine.CurrentStateI;

        internal Orthogonal(State<TState, TTransition, TSignal> state, int index)
        {
            this.Index = index;
            this.OfState = state;
            this.Machine = new StateMachine<TState, TTransition, TSignal>();

            ConnectStateChangedEvent();
        }

        internal void ConnectStateChangedEvent()
        {
            if (this.OfState.MachineI != null)
                this.Machine.AddAction(new FireOnStateChangedAction(this.OfState.MachineI));
        }

        private sealed class FireOnStateChangedAction : StateMachineActionBase
        {
            private readonly StateMachine<TState, TTransition, TSignal> machine;

            public FireOnStateChangedAction(StateMachine<TState, TTransition, TSignal> machine) : base("FireOnStateChanged")
            {
                this.machine = machine ?? throw new System.ArgumentNullException(nameof(machine));
            }

            public void FireOnStateChanged(State<TState, TTransition, TSignal> priorState, State<TState, TTransition, TSignal> formerState)
                => this.machine.FireOnStateChanged(priorState, formerState);
        }
    }
}