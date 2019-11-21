namespace StateMachineFramework
{
    public interface IOrthogonalMachine
    {
        int Index { get; }
    }

    public interface IOrthogonalMachine<TState, TTransition, TSignal> : IOrthogonalMachine
    {
        StateMachine<TState, TTransition, TSignal> Machine { get; }

        State<TState, TTransition, TSignal> OfState { get; }

        State<TState, TTransition, TSignal> CurrentState { get; }
    }
}