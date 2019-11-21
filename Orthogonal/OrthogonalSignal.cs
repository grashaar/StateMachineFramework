namespace StateMachineFramework
{
    public readonly partial struct OrthogonalSignal<TState, TTransition, TSignal>
    {
        public OrthogonalMachine<TState, TTransition, TSignal> Machine { get; }

        public Signal<TState, TTransition, TSignal> Signal { get; }

        public OrthogonalSignal(OrthogonalMachine<TState, TTransition, TSignal> machine, Signal<TState, TTransition, TSignal> signal)
        {
            this.Machine = machine;
            this.Signal = signal;
        }
    }
}