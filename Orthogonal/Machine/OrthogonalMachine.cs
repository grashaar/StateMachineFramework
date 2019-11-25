namespace StateMachineFramework
{
    public readonly partial struct OrthogonalMachine<TState, TTransition, TSignal>
    {
        public OrthogonalState<TState, TTransition, TSignal> OfState { get; }

        public OrthogonalStateMachine<TState, TTransition, TSignal> Machine { get; }

        public OrthogonalMachine(in OrthogonalState<TState, TTransition, TSignal> state, OrthogonalStateMachine<TState, TTransition, TSignal> machine)
        {
            this.OfState = state;
            this.Machine = machine;
        }
    }
}