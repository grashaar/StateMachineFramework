namespace StateMachineFramework
{
    public interface ITransitionAction
    {
        string Name { get; }

        ITransition Transition { get; set; }

        void Invoke(TransitionArgs args);

        void Start(TransitionArgs args);

        void Finish();
    }

    public interface ITransitionAction<T> : ITransitionAction
    {
        new ITransition<T> Transition { get; set; }
    }

    public interface ITransitionAction<TState, TTransition, TSignal> : ITransitionAction<TTransition>
    {
        new Transition<TState, TTransition, TSignal> Transition { get; set; }
    }
}
