﻿using System;

namespace StateMachineFramework
{
    public sealed partial class State<TState, TTransition, TSignal>
    {
        public StateMachine<TState, TTransition, TSignal> End()
        {
            return this.Machine;
        }

        public Orthogonal<TState, TTransition, TSignal> BeginOrthogonal(int orthogonalIndex)
        {
            return this.OrthogonalsI[orthogonalIndex];
        }

        public State<TState, TTransition, TSignal> Action(IStateAction action)
        {
            AddAction(action);
            return this;
        }

        public State<TState, TTransition, TSignal> Action<T>() where T : IStateAction, new()
        {
            AddAction(new T());
            return this;
        }

        public State<TState, TTransition, TSignal> OnEnter(Action<IStateAction> action)
            => OnEnter(null, action);

        public State<TState, TTransition, TSignal> OnEnter(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionEnter(name, action));
            return this;
        }

        public State<TState, TTransition, TSignal> OnResume(Action<IStateAction> action)
            => OnResume(null, action);

        public State<TState, TTransition, TSignal> OnResume(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionResume(name, action));
            return this;
        }

        public State<TState, TTransition, TSignal> OnLateEnter(Action<IStateAction> action)
            => OnLateEnter(null, action);

        public State<TState, TTransition, TSignal> OnLateEnter(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionLateEnter(name, action));
            return this;
        }

        public State<TState, TTransition, TSignal> OnExit(Action<IStateAction> action)
            => OnExit(null, action);

        public State<TState, TTransition, TSignal> OnExit(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionExit(name, action));
            return this;
        }

        public State<TState, TTransition, TSignal> OnUpdate(Action<IStateAction> action)
            => OnUpdate(null, action);

        public State<TState, TTransition, TSignal> OnUpdate(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionUpdate(name, action));
            return this;
        }

        public State<TState, TTransition, TSignal> OnTerminate(Action<IStateAction> action)
            => OnTerminate(null, action);

        public State<TState, TTransition, TSignal> OnTerminate(string name, Action<IStateAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateActionTerminate(name, action));
            return this;
        }
    }
}