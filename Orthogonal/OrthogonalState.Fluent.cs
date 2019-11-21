using System;

namespace StateMachineFramework
{
    public readonly partial struct OrthogonalState<TState, TTransition, TSignal>
    {
        public OrthogonalMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
        }

        public OrthogonalState<TState, TTransition, TSignal> Action(IStateAction action)
        {
            this.State.Action(action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> Action<T>() where T : IStateAction, new()
        {
            this.State.Action<T>();
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnEnter(Action<IStateAction> action)
        {
            this.State.OnEnter(action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnEnter(string name, Action<IStateAction> action)
        {
            this.State.OnEnter(name, action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnExit(Action<IStateAction> action)
        {
            this.State.OnExit(action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnExit(string name, Action<IStateAction> action)
        {
            this.State.OnExit(name, action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnUpdate(Action<IStateAction> action)
        {
            this.State.OnUpdate(action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnUpdate(string name, Action<IStateAction> action)
        {
            this.State.OnUpdate(name, action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnTerminate(Action<IStateAction> action)
        {
            this.State.OnTerminate(action);
            return this;
        }

        public OrthogonalState<TState, TTransition, TSignal> OnTerminate(string name, Action<IStateAction> action)
        {
            this.State.OnTerminate(name, action);
            return this;
        }
    }
}