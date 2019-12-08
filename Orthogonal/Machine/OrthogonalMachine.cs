namespace StateMachineFramework
{
    public readonly partial struct OrthogonalMachine<TState, TTransition, TSignal>
    {
        public OrthogonalState<TState, TTransition, TSignal> OfState { get; }

        public Orthogonal<TState, TTransition, TSignal> Machine { get; }

        public OrthogonalMachine(in OrthogonalState<TState, TTransition, TSignal> state, Orthogonal<TState, TTransition, TSignal> machine)
        {
            this.OfState = state;
            this.Machine = machine;
        }
    }
}