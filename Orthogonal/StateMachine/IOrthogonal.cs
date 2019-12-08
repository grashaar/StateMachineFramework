namespace StateMachineFramework
{
    public interface IOrthogonal
    {
        int Index { get; }
    }

    public interface IOrthogonal<TState, TTransition, TSignal> : IOrthogonal
    {
        StateMachine<TState, TTransition, TSignal> Machine { get; }

        State<TState, TTransition, TSignal> OfState { get; }

        State<TState, TTransition, TSignal> CurrentState { get; }
    }
}