namespace StateMachineFramework
{
    public interface IOrthogonalStateMachine
    {
        int Index { get; }
    }

    public interface IOrthogonalStateMachine<TState, TTransition, TSignal> : IOrthogonalStateMachine
    {
        StateMachine<TState, TTransition, TSignal> Machine { get; }

        State<TState, TTransition, TSignal> OfState { get; }

        State<TState, TTransition, TSignal> CurrentState { get; }
    }
}