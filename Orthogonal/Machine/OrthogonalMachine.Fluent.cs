using System;

namespace StateMachineFramework
{
    public readonly partial struct OrthogonalMachine<TState, TTransition, TSignal>
    {
        public OrthogonalState<TState, TTransition, TSignal> End(int orthogonalIndex)
        {
            return this.OfState;
        }

        public OrthogonalState<TState, TTransition, TSignal> BeginState(TState stateName)
        {
            return this.Machine.BeginState(stateName, this.OfState);
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(TState stateName)
        {
            return this.Machine.BeginState(stateName, this.OfState);
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(IState state)
        {
            return this.Machine.Begin(state, this.OfState);
        }

        public OrthogonalState<TState, TTransition, TSignal> Begin(IState<TState> state)
        {
            return this.Machine.Begin(state, this.OfState);
        }

        public OrthogonalSignal<TState, TTransition, TSignal> BeginSignal(TSignal signalName)
        {
            return this.Machine.BeginSignal(signalName, this.OfState);
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(TSignal signalName)
        {
            return this.Machine.BeginSignal(signalName, this.OfState);
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(ISignal signal)
        {
            return this.Machine.Begin(signal, this.OfState);
        }

        public OrthogonalSignal<TState, TTransition, TSignal> Begin(ISignal<TSignal> signal)
        {
            return this.Machine.Begin(signal, this.OfState);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> BeginTransition(TTransition transitionName)
        {
            return this.Machine.BeginTransition(transitionName, this.OfState);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(TTransition transitionName)
        {
            return this.Machine.BeginTransition(transitionName, this.OfState);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(ITransition transition)
        {
            return this.Machine.Begin(transition, this.OfState);
        }

        public OrthogonalTransition<TState, TTransition, TSignal> Begin(ITransition<TTransition> transition)
        {
            return this.Machine.Begin(transition, this.OfState);
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState stateName, out State<TState, TTransition, TSignal> state)
        {
            this.Machine.Create(stateName, out state);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> CreateState(
            TState stateName, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateState(stateName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState stateName, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(stateName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState stateName, out State<TState, TTransition, TSignal> state,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(stateName, out state, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            this.Machine.Create(innerStateName, stateName, out innerState, orthogonalIndex);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> CreateState(
            TState innerStateName, TState stateName, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateState(innerStateName, stateName, orthogonalIndex, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, stateName, orthogonalIndex, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, TState stateName, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, stateName, out innerState, orthogonalIndex, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            this.Machine.Create(innerStateName, state, out innerState, orthogonalIndex);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, state, orthogonalIndex, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TState innerStateName, State<TState, TTransition, TSignal> state,
            out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(innerStateName, state, out innerState, orthogonalIndex, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            out Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, out transition);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> CreateTransition(
            TTransition transitionName, TState startStateName, TState endStateName,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateTransition(transitionName, startStateName, endStateName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName, TState startStateName, TState endStateName,
            out Transition<TState, TTransition, TSignal> transition,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startStateName, endStateName, out transition, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName,
            State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Create(transitionName, startState, endState, out transition);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName,
            State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startState, endState, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TTransition transitionName,
            State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition,
            Action<Transition<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(transitionName, startState, endState, out transition, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            out Signal<TState, TTransition, TSignal> signal)
        {
            this.Machine.Create(signalName, transitionName, out signal);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> CreateSignal(
            TSignal signalName, TTransition transitionName,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.CreateSignal(signalName, transitionName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transitionName, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, TTransition transitionName,
            out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transitionName, out signal, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            out Signal<TState, TTransition, TSignal> signal)
        {
            this.Machine.Create(signalName, transition, out signal);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transition, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Create(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback = null)
        {
            this.Machine.Create(signalName, transition, out signal, callback);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Connect(
            TSignal signalName, TTransition transitionName)
        {
            this.Machine.Connect(signalName, transitionName);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Connect(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Connect(signalName, transition);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName)
        {
            this.Machine.Connect(signal, transitionName);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition)
        {
            this.Machine.Connect(signal, transition);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Initial(
            TState stateName)
        {
            this.Machine.Initial(stateName);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> state)
        {
            this.Machine.Initial(state);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Initial(
            TState innerStateName, TState stateName, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerStateName, stateName, orthogonalIndex);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Initial(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerStateName, state, orthogonalIndex);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> innerState, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            this.Machine.Initial(innerState, state, orthogonalIndex);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> EmitCondition(
            TSignal signalName, params TState[] conditionalStateNames)
        {
            this.Machine.EmitCondition(signalName, conditionalStateNames);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal, params TState[] conditionalStateNames)
        {
            this.Machine.EmitCondition(signal, conditionalStateNames);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.EmitCondition(signal, conditionalStates);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> TransitionCondition(
            TSignal signalName, TTransition transitionName, params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signalName, transitionName, conditionalStateNames);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signal, transitionName, conditionalStateNames);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(signal, transitionName, conditionalStates);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params TState[] conditionalStateNames)
        {
            this.Machine.TransitionCondition(signal, transition, conditionalStateNames);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            this.Machine.TransitionCondition(signal, transition, conditionalStates);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Action(IStateMachineAction action)
        {
            this.Machine.Action(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> Action<T>() where T : IStateMachineAction, new()
        {
            this.Machine.Action<T>();
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnInitialize(
            Action<IStateMachineAction> action)
        {
            this.Machine.OnInitialize(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnInitialize(
            string name, Action<IStateMachineAction> action)
        {
            this.Machine.OnInitialize(name, action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnTerminate(
            Action<IStateMachineAction> action)
        {
            this.Machine.OnTerminate(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnTerminate(
            string name, Action<IStateMachineAction> action)
        {
            this.Machine.OnTerminate(name, action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState, IState> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState, IState> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            this.Machine.OnStateChange(action);
            return this;
        }

        public OrthogonalMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            this.Machine.OnStateChange(name, action);
            return this;
        }
    }
}
