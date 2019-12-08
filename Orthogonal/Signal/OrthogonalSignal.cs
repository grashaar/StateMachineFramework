namespace StateMachineFramework
{
    public readonly partial struct OrthogonalSignal<TState, TTransition, TSignal>
    {
        public Orthogonal<TState, TTransition, TSignal> Machine { get; }

        public Signal<TState, TTransition, TSignal> Signal { get; }

        public OrthogonalState<TState, TTransition, TSignal> Parent { get; }

        public OrthogonalSignal(Orthogonal<TState, TTransition, TSignal> machine, Signal<TState, TTransition, TSignal> signal, in OrthogonalState<TState, TTransition, TSignal> parent = default)
        {
            this.Machine = machine;
            this.Signal = signal;
            this.Parent = parent;
        }
    }
}