﻿using System;
using System.Runtime.CompilerServices;

namespace StateMachineFramework
{
    public sealed partial class Orthogonal<TState, TTransition, TSignal>
    {
        public State<TState, TTransition, TSignal> End(int orthogonalIndex)
        {
            return this.OfState;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private OrthogonalState<TState, TTransition, TSignal> State(
            State<TState, TTransition, TSignal> value, in OrthogonalState<TState, TTransition, TSignal> parent = default)
        {
            return new OrthogonalState<TState, TTransition, TSignal>(this, value, parent);
        }

        public OrthogonalState<TState, TTransition, TSignal> BeginState(TState stateName)
        {
            return State(this.Machine.Begin(stateName));
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(TState stateName)
        {
            return State(this.Machine.Begin(stateName));
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(IState state)
        {
            return State(this.Machine.Begin(state));
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(IState<TState> state)
        {
            return State(this.Machine.Begin(state));
        }

        internal OrthogonalState<TState, TTransition, TSignal> BeginState(
            TState stateName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return State(this.Machine.Begin(stateName), parent);
        }

        internal OrthogonalState<TState, TTransition, TSignal> Begin(
            TState stateName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return State(this.Machine.Begin(stateName), parent);
        }

        internal OrthogonalState<TState, TTransition, TSignal> Begin(
            IState state, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return State(this.Machine.Begin(state), parent);
        }

        internal OrthogonalState<TState, TTransition, TSignal> Begin(
            IState<TState> state, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return State(this.Machine.Begin(state), parent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private OrthogonalSignal<TState, TTransition, TSignal> Signal(
            Signal<TState, TTransition, TSignal> value,
            in OrthogonalState<TState, TTransition, TSignal> parent = default)
        {
            return new OrthogonalSignal<TState, TTransition, TSignal>(this, value, parent);
        }

        public OrthogonalSignal<TState, TTransition, TSignal> BeginSignal(TSignal signalName)
        {
            return Signal(this.Machine.BeginSignal(signalName));
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(TSignal signalName)
        {
            return Signal(this.Machine.BeginSignal(signalName));
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(ISignal signal)
        {
            return Signal(this.Machine.Begin(signal));
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(ISignal<TSignal> signal)
        {
            return Signal(this.Machine.Begin(signal));
        }

        internal OrthogonalSignal<TState, TTransition, TSignal> BeginSignal(
            TSignal signalName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Signal(this.Machine.BeginSignal(signalName), parent);
        }

        internal OrthogonalSignal<TState, TTransition, TSignal> Begin(
            TSignal signalName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Signal(this.Machine.BeginSignal(signalName), parent);
        }

        internal OrthogonalSignal<TState, TTransition, TSignal> Begin(
            ISignal signal, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Signal(this.Machine.Begin(signal), parent);
        }

        internal OrthogonalSignal<TState, TTransition, TSignal> Begin(
            ISignal<TSignal> signal, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Signal(this.Machine.Begin(signal), parent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private OrthogonalTransition<TState, TTransition, TSignal> Transition(
            Transition<TState, TTransition, TSignal> value,
            in OrthogonalState<TState, TTransition, TSignal> parent = default)
        {
            return new OrthogonalTransition<TState, TTransition, TSignal>(this, value, parent);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> BeginTransition(TTransition transitionName)
        {
            return Transition(this.Machine.BeginTransition(transitionName));
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(TTransition transitionName)
        {
            return Transition(this.Machine.BeginTransition(transitionName));
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(ITransition transition)
        {
            return Transition(this.Machine.Begin(transition));
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(ITransition<TTransition> transition)
        {
            return Transition(this.Machine.Begin(transition));
        }

        internal OrthogonalTransition<TState, TTransition, TSignal> BeginTransition(
            TTransition transitionName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Transition(this.Machine.BeginTransition(transitionName), parent);
        }

        internal OrthogonalTransition<TState, TTransition, TSignal> Begin(
            TTransition transitionName, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Transition(this.Machine.BeginTransition(transitionName), parent);
        }

        internal OrthogonalTransition<TState, TTransition, TSignal> Begin(
            ITransition transition, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Transition(this.Machine.Begin(transition), parent);
        }

        internal OrthogonalTransition<TState, TTransition, TSignal> Begin(
            ITransition<TTransition> transition, in OrthogonalState<TState, TTransition, TSignal> parent)
        {
            return Transition(this.Machine.Begin(transition), parent);
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState stateName, out State<TState, TTransition, TSignal> state)
        {
            this.Machine.Create(stateName, out state);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> CreateState(
            TState stateName, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateState(stateName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState stateName, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(stateName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState stateName, out State<TState, TTransition, TSignal> state,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(stateName, out state, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            this.Machine.Create(innerStateName, stateName, out innerState, orthogonalIndex);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> CreateState(
            TState innerStateName, TState stateName, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateState(innerStateName, stateName, orthogonalIndex, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, stateName, orthogonalIndex, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, stateName, out innerState, orthogonalIndex, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            this.Machine.Create(innerStateName, state, out innerState, orthogonalIndex);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, state, orthogonalIndex, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, state, out innerState, orthogonalIndex, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            out Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, out transition);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> CreateTransition(
            TTransition transitionName, TState startStateName, TState endStateName,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateTransition(transitionName, startStateName, endStateName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            out Transition<TState, TTransition, TSignal> transition,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, out transition, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, State<TState, TTransition, TSignal> startState,
            State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Create(transitionName, startState, endState, out transition);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, State<TState, TTransition, TSignal> startState,
            State<TState, TTransition, TSignal> endState,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startState, endState, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TTransition transitionName, State<TState, TTransition, TSignal> startState,
            State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startState, endState, out transition, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            out Signal<TState, TTransition, TSignal> signal)
        {
            this.Machine.Create(signalName, transitionName, out signal);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> CreateSignal(
            TSignal signalName, TTransition transitionName,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateSignal(signalName, transitionName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transitionName, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transitionName, out signal, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            out Signal<TState, TTransition, TSignal> signal)
        {
            this.Machine.Create(signalName, transition, out signal);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transition, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transition, out signal, callback);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Connect(
            TSignal signalName, TTransition transitionName)
        {
            this.Machine.Connect(signalName, transitionName);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Connect(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Connect(signalName, transition);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName)
        {
            this.Machine.Connect(signal, transitionName);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Connect(signal, transition);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Initial(
            TState stateName)
        {
            this.Machine.Initial(stateName);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> state)
        {
            this.Machine.Initial(state);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Initial(
            TState innerStateName, TState stateName, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerStateName, stateName, orthogonalIndex);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Initial(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerStateName, state, orthogonalIndex);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> innerState, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerState, state, orthogonalIndex);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> EmitCondition(
            TSignal signalName, params TState[] conditionalStateNames)
        {
            this.Machine.EmitCondition(signalName, conditionalStateNames);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal,
            params TState[] conditionalStateNames)
        {
            this.Machine.EmitCondition(signal, conditionalStateNames);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal,
            params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.EmitCondition(signal, conditionalStates);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> TransitionCondition(
            TSignal signalName, TTransition transitionName,
            params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signalName, transitionName, conditionalStateNames);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName,
            params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signal, transitionName, conditionalStateNames);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName,
            params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(signal, transitionName, conditionalStates);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition,
            params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signal, transition, conditionalStateNames);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition,
            params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(signal, transition, conditionalStates);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Action(IStateMachineAction action)
        {
            this.Machine.Action(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> Action<T>() where T : IStateMachineAction, new()
        {
            this.Machine.Action<T>();
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnInitialize(
            Action<IStateMachineAction> action)
        {
            this.Machine.OnInitialize(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnInitialize(
            string name, Action<IStateMachineAction> action)
        {
            this.Machine.OnInitialize(name, action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnTerminate(
            Action<IStateMachineAction> action)
        {
            this.Machine.OnTerminate(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnTerminate(
            string name, Action<IStateMachineAction> action)
        {
            this.Machine.OnTerminate(name, action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState, IState> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState, IState> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public Orthogonal<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }
    }
}