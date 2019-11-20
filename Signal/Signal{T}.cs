using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public abstract class Signal<T> : ISignal<T>
    {
        public T Name { get; }

        object ISignal.Name
            => this.Name;

        T ISignal<T>.Name
            => this.Name;

        IStateMachine ISignal.Machine
            => GetMachine();

        IReadOnlyList<ITransition> ISignal.SignalTo
            => GetSignalTo();

        IReadOnlyList<ISignalCondition> ISignal.EmitConditions
            => GetEmitConditions();

        IReadOnlyDictionary<ISignalCondition, ITransition> ISignal.TransitionConditions
            => GetTransitionConditions();

        public abstract IReadOnlyList<ISignalAction> Actions { get; }

        protected Signal(T name)
        {
            this.Name = name;
        }

        public abstract bool AddAction(ISignalAction action);

        public abstract bool Emit();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IStateMachine GetMachine();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyList<ITransition> GetSignalTo();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyList<ISignalCondition> GetEmitConditions();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract IReadOnlyDictionary<ISignalCondition, ITransition> GetTransitionConditions();
    }
}
