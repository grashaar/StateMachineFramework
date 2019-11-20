using System;

namespace StateMachineFramework
{
    public sealed partial class Signal<TState, TTransition, TSignal>
    {
        public StateMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
        }

        public Signal<TState, TTransition, TSignal> Emit(params TState[] conditionalStateNames)
        {
            this.Machine.EmitCondition(this, conditionalStateNames);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Emit(params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.EmitCondition(this, conditionalStates);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Transition(TTransition transitionName, params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(this, transitionName, conditionalStateNames);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Transition(TTransition transitionName, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(this, transitionName, conditionalStates);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Transition(Transition<TState, TTransition, TSignal> transition, params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(this, transition, conditionalStateNames);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Transition(Transition<TState, TTransition, TSignal> transition, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(this, transition, conditionalStates);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Action(ISignalAction action)
        {
            AddAction(action);
            return this;
        }

        public Signal<TState, TTransition, TSignal> Action<T>() where T : ISignalAction, new()
        {
            AddAction(new T());
            return this;
        }

        public Signal<TState, TTransition, TSignal> OnEmit(Action<ISignalAction> action)
            => OnEmit( null, action);

        public Signal<TState, TTransition, TSignal> OnEmit(string name, Action<ISignalAction> action)
        {
            if (action == null)
                return this;

            AddAction(new SignalActionEmit(name, action));
            return this;
        }

        public Signal<TState, TTransition, TSignal> OnProcess(Action<ISignalAction> action)
            => OnProcess(null, action);

        public Signal<TState, TTransition, TSignal> OnProcess(string name, Action<ISignalAction> action)
        {
            if (action == null)
                return this;

            AddAction(new SignalActionProcess(name, action));
            return this;
        }

        public Signal<TState, TTransition, TSignal> OnNotProcess(Action<ISignalAction, SignalNotProcessedArgs> action)
            => OnNotProcess(null, action);

        public Signal<TState, TTransition, TSignal> OnNotProcess(string name, Action<ISignalAction, SignalNotProcessedArgs> action)
        {
            if (action == null)
                return this;

            AddAction(new SignalActionNotProcess(name, action));
            return this;
        }
    }
}
