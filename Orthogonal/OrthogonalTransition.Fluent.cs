﻿using System;

namespace StateMachineFramework
{
    public readonly partial struct OrthogonalTransition<TState, TTransition, TSignal>
    {
        public OrthogonalMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
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