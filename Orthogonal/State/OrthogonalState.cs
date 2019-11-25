namespace StateMachineFramework
{
    public readonly partial struct OrthogonalState<TState, TTransition, TSignal>
    {
        public OrthogonalStateMachine<TState, TTransition, TSignal> Machine { get; }

        public State<TState, TTransition, TSignal> State { get; }

        public OrthogonalParent Parent { get; }

        public OrthogonalState(OrthogonalStateMachine<TState, TTransition, TSignal> machine, State<TState, TTransition, TSignal> state, in OrthogonalState<TState, TTransition, TSignal> parent = default)
        {
            this.Machine = machine;
            this.State = state;
            this.Parent = new OrthogonalParent(parent.Machine, parent.State);
        }

        public readonly struct OrthogonalParent
        {
            public OrthogonalStateMachine<TState, TTransition, TSignal> Machine { get; }

            public State<TState, TTransition, TSignal> State { get; }

            public OrthogonalParent(OrthogonalStateMachine<TState, TTransition, TSignal> machine, State<TState, TTransition, TSignal> state)
            {
                this.Machine = machine;
                this.State = state;
            }

            public static implicit operator OrthogonalState<TState, TTransition, TSignal>(in OrthogonalParent value)
                => new OrthogonalState<TState, TTransition, TSignal>(value.Machine, value.State);
        }
    }
}
