using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public abstract class State<T> : IState<T>
    {
        public T Name { get; }

        object IState.Name
            => this.Name;

        IStateMachine IState.Machine
            => GetMachine();

        IReadOnlyList<ITransition> IState.Transitions
            => GetTransitions();

        IReadOnlyDictionary<int, IOrthogonal> IState.Orthogonals
            => GetOrthogonals();

        public bool HasInnerState { get; protected set; }

        public bool IsCurrentState { get; protected set; }

        public bool HasParentState { get; internal set; }

        public abstract IReadOnlyList<IStateAction> Actions { get; }

        protected State(T name)
        {
            this.Name = name;
        }

        public abstract bool AddAction(IStateAction action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IStateMachine GetMachine();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyList<ITransition> GetTransitions();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyDictionary<int, IOrthogonal> GetOrthogonals();
    }
}