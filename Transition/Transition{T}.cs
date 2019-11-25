﻿using System.Collections.Generic;
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

        public abstract IReadOnlyList<ITransitionCondition> StartConditions { get; }

        public abstract IReadOnlyList<ITransitionCondition> FinishConditions { get; }

        public Transition(T name)
        {
            this.Name = name;
        }

        public abstract bool AddAction(ITransitionAction action);

        public abstract bool AddStartCondition(ITransitionCondition condition);

        public abstract bool AddFinishCondition(ITransitionCondition condition);

        public abstract void Terminate();

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