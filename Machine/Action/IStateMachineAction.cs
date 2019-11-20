namespace StateMachineFramework
{
    public interface IStateMachineAction
    {
        string Name { get; }

        IStateMachine Machine { get; set; }

        void Initialize();

        void StateChange(IState priorState, IState formerState);

        void Terminate();
    }

    public interface IStateMachineAction<T> : IStateMachineAction
    {
        void StateChange(IState<T> priorState, IState<T> formerState);
    }

    public interface IStateMachineAction<TState, TTransition, TSignal> : IStateMachineAction<TState>
    {
        new StateMachine<TState, TTransition, TSignal> Machine { get; set; }

        void StateChange(State<TState, TTransition, TSignal> priorState, State<TState, TTransition, TSignal> formerState);
    }
}
