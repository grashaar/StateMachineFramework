namespace StateMachineFramework
{
    public readonly partial struct OrthogonalState<TState, TTransition, TSignal>
    {
        public OrthogonalMachine<TState, TTransition, TSignal> Machine { get; }

        public State<TState, TTransition, TSignal> State { get; }

        public OrthogonalState(OrthogonalMachine<TState, TTransition, TSignal> machine, State<TState, TTransition, TSignal> state)
        {
            this.Machine = machine;
            this.State = state;
        }
    }
}
