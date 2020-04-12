namespace StateMachineFramework
{
    public interface IStateAction
    {
        string Name { get; }

        IState State { get; set; }

        void Enter(IState previous);

        void Resume(IState next);

        void LateEnter(IState previous);

        void Exit(IState next);

        void Update();

        void Terminate();
    }

    public interface IStateAction<T> : IStateAction
    {
        new IState<T> State { get; set; }
    }

    public interface IStateAction<TState, TTransition, TSignal> : IStateAction<TState>
    {
        new State<TState, TTransition, TSignal> State { get; set; }
    }
}
