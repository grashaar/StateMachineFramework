using System;

namespace StateMachineFramework
{
    public readonly partial struct OrthogonalTransition<TState, TTransition, TSignal>
    {
        public OrthogonalStateMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> End(int orthogonalIndex)
        {
            return new OrthogonalMachine<TState, TTransition, TSignal>(
                new OrthogonalState<TState, TTransition, TSignal>(this.Parent.Machine, this.Parent.State), this.Machine);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Signal(
            TSignal signalName, out Signal<TState, TTransition, TSignal> signal)
        {
            this.Transition.Signal(signalName, out signal);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Signal(
            TSignal signalName, Action<Signal<TState, TTransition, TSignal>> callback)
        {
            this.Transition.Signal(signalName, callback);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Signal(
            TSignal signalName, out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback)
        {
            this.Transition.Signal(signalName, out signal, callback);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> StartWhen(ITransitionCondition condition)
        {
            this.Transition.StartWhen(condition);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> StartWhen<T>() where T : ITransitionCondition, new()
        {
            this.Transition.StartWhen<T>();
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> StartWhen(Func<bool> callback)
        {
            this.Transition.StartWhen(callback);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> FinishWhen(ITransitionCondition condition)
        {
            this.Transition.StartWhen(condition);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> FinishWhen<T>() where T : ITransitionCondition, new()
        {
            this.Transition.FinishWhen<T>();
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> FinishWhen(Func<bool> callback)
        {
            this.Transition.FinishWhen(callback);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Action(ITransitionAction action)
        {
            this.Transition.Action(action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Action<T>() where T : ITransitionAction, new()
        {
            this.Transition.Action<T>();
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnInvoke(Action<ITransitionAction, TransitionArgs> action)
        {
            this.Transition.OnInvoke(action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnInvoke(string name, Action<ITransitionAction, TransitionArgs> action)
        {
            this.Transition.OnInvoke(name, action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnStart(Action<ITransitionAction, TransitionArgs> action)
        {
            this.Transition.OnStart(action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnStart(string name, Action<ITransitionAction, TransitionArgs> action)
        {
            this.Transition.OnStart(name, action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnFinish(Action<ITransitionAction> action)
        {
            this.Transition.OnFinish(action);
            return this;
        }

        public OrthogonalTransition<TState, TTransition, TSignal> OnFinish(string name, Action<ITransitionAction> action)
        {
            this.Transition.OnFinish(name, action);
            return this;
        }
    }
}