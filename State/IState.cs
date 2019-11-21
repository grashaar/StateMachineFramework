using System.Collections.Generic;

namespace StateMachineFramework
{
    public interface IState
    {
        object Name { get; }

        IStateMachine Machine { get; }

        IReadOnlyList<ITransition> Transitions { get; }

        IReadOnlyDictionary<int, IOrthogonalMachine> OrthogonalMachines { get; }

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

        new IReadOnlyDictionary<int, OrthogonalMachine<TState, TTransition, TSignal>> OrthogonalMachines { get; }
    }
}