using System;

namespace StateMachineFramework
{
    public sealed partial class Transition<TState, TTransition, TSignal>
    {
        public StateMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
        }

        public Transition<TState, TTransition, TSignal> Action(ITransitionAction action)
        {
            AddAction(action);
            return this;
        }

        public Transition<TState, TTransition, TSignal> Action<T>() where T : ITransitionAction, new()
        {
            AddAction(new T());
            return this;
        }

        public Transition<TState, TTransition, TSignal> OnStart(Action<ITransitionAction, TransitionArgs> action)
            => OnStart(null, action);

        public Transition<TState, TTransition, TSignal> OnStart(string name, Action<ITransitionAction, TransitionArgs> action)
        {
            if (action == null)
                return this;

            AddAction(new TransitionActionStart(name, action));
            return this;
        }

        public Transition<TState, TTransition, TSignal> OnFinish(Action<ITransitionAction> action)
            => OnFinish(null, action);

        public Transition<TState, TTransition, TSignal> OnFinish(string name, Action<ITransitionAction> action)
        {
            if (action == null)
                return this;

            AddAction(new TransitionActionFinish(name, action));
            return this;
        }
    }
}
