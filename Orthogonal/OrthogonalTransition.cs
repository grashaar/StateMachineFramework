namespace StateMachineFramework
{
    public readonly partial struct OrthogonalTransition<TState, TTransition, TSignal>
    {
        public OrthogonalMachine<TState, TTransition, TSignal> Machine { get; }

        public Transition<TState, TTransition, TSignal> Transition { get; }

        public OrthogonalTransition(OrthogonalMachine<TState, TTransition, TSignal> machine, Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine = machine;
            this.Transition = transition;
        }
    }
}
