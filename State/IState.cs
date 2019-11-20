using System.Collections.Generic;

namespace StateMachineFramework
{
    public interface IState
    {
        object Name { get; }

        IStateMachine Machine { get; }

        IReadOnlyList<ITransition> Transitions { get; }

        IReadOnlyDictionary<int, IOrthogonal> Orthogonals { get; }

        bool HasInnerState { get; }

        bool IsCurrentState { get; }

        bool HasParentState { get; }

        IReadOnlyList<IStateAction> Actions { get; }

        bool AddAction(IStateAction action);
    }

    public interface IState<T> : IState
    {
        new T Name { get; }
    }

    public interface IState<TState, TTransition, TSignal> : IState<TState>
    {
        new StateMachine<TState, TTransition, TSignal> Machine { get; }

        new IReadOnlyList<Transition<TState, TTransition, TSignal>> Transitions { get; }

        new IReadOnlyDictionary<int, Orthogonal<TState, TTransition, TSignal>> Orthogonals { get; }

        bool AddTransition(Transition<TState, TTransition, TSignal> transition, State<TState, TTransition, TSignal> state);

        bool AddOrthogonal(int index);

        bool AddInnerState(State<TState, TTransition, TSignal> innerState, int index = 0);

        bool SetInitialInnerState(State<TState, TTransition, TSignal> innerState, int index = 0);

        bool SetStateMachine(StateMachine<TState, TTransition, TSignal> machine);
    }
}