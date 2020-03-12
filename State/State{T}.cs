using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public abstract class State<T> : IState<T>, IEquatable<State<T>>, IEquatable<T>
    {
        public T Name { get; }

        object IState.Name
            => this.Name;

        IStateMachine IState.Machine
            => GetMachine();

        IReadOnlyList<ITransition> IState.Transitions
            => GetTransitions();

        IReadOnlyDictionary<int, IOrthogonal> IState.Orthogonals
            => GetOrthogonalMachines();

        public bool IsCurrentState { get; protected set; }

        public bool HasParentState { get; internal set; }

        public abstract IReadOnlyList<IStateAction> Actions { get; }

        protected State(T name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            this.Name = name;
        }

        public override bool Equals(object obj)
            => obj is State<T> other ? Equals(this.Name, other.Name) : false;

        public bool Equals(State<T> other)
            => other == null ? false : Equals(this.Name, other.Name);

        public bool Equals(T other)
            => other == null ? false : Equals(this.Name, other);

        public override int GetHashCode()
            => this.Name.GetHashCode();

        public abstract bool AddAction(IStateAction action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IStateMachine GetMachine();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyList<ITransition> GetTransitions();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyDictionary<int, IOrthogonal> GetOrthogonalMachines();
    }
}