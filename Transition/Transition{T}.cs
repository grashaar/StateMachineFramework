using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public abstract class Transition<T> : ITransition<T>
    {
        public T Name { get; }

        object ITransition.Name
            => this.Name;

        IStateMachine ITransition.Machine
            => GetMachine();

        IReadOnlyList<ISignal> ITransition.Signals
            => GetSignals();

        IState ITransition.StartState
            => GetStartState();

        IState ITransition.EndState
            => GetEndState();

        public abstract bool CanTransition { get; }

        public abstract IReadOnlyList<ITransitionAction> Actions { get; }

        public Transition(T name)
        {
            this.Name = name;
        }

        public abstract bool AddAction(ITransitionAction action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IStateMachine GetMachine();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyList<ISignal> GetSignals();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IState GetStartState();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IState GetEndState();
    }
}