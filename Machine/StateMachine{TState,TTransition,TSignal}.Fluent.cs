using System;

namespace StateMachineFramework
{
    public partial class StateMachine<TState, TTransition, TSignal>
    {
        public StateMachine<TState, TTransition, TSignal> Build()
        {
            Initialize();
            return this;
        }

        public State<TState, TTransition, TSignal> Begin(TState stateName)
        {
            return GetStateByName(stateName);
        }

        public State<TState, TTransition, TSignal> Begin(IState state)
        {
            return GetStateByName((TState)state.Name);
        }

        public State<TState, TTransition, TSignal> Begin(IState<TState> state)
        {
            return GetStateByName(state.Name);
        }

        public Signal<TState, TTransition, TSignal> Begin(TSignal signalName)
        {
            return GetSignalByName(signalName);
        }

        public Signal<TState, TTransition, TSignal> Begin(ISignal signal)
        {
            return GetSignalByName((TSignal)signal.Name);
        }

        public Signal<TState, TTransition, TSignal> Begin(ISignal<TSignal> signal)
        {
            return GetSignalByName(signal.Name);
        }

        public Transition<TState, TTransition, TSignal> Begin(TTransition transitionName)
        {
            return GetTransitionByName(transitionName);
        }

        public Transition<TState, TTransition, TSignal> Begin(ITransition transition)
        {
            return GetTransitionByName((TTransition)transition.Name);
        }

        public Transition<TState, TTransition, TSignal> Begin(ITransition<TTransition> transition)
        {
            return GetTransitionByName(transition.Name);
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState stateName, out State<TState, TTransition, TSignal> state)
        {
            state = CreateState(stateName);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState stateName, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            var state = CreateState(stateName);
            callback?.Invoke(state);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState stateName, out State<TState, TTransition, TSignal> state,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            state = CreateState(stateName);
            callback?.Invoke(state);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, TState stateName, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            innerState = CreateState(innerStateName, stateName, orthogonalIndex);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, TState stateName, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            var innerState = CreateState(innerStateName, stateName, orthogonalIndex);
            callback?.Invoke(innerState);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, TState stateName, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            innerState = CreateState(innerStateName, stateName, orthogonalIndex);
            callback?.Invoke(innerState);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, State<TState, TTransition, TSignal> state, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            innerState = CreateState(innerStateName, state, orthogonalIndex);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0,
            Action<State<TState, TTransition, TSignal>> callback = null)
        {
            var innerState = CreateState(innerStateName, state, orthogonalIndex);
            callback?.Invoke(innerState);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> State(
            TState innerStateName, State<TState, TTransition, TSignal> state, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0, Action<State<TState, TTransition, TSignal>> callback = null)
        {
            innerState = CreateState(innerStateName, state, orthogonalIndex);
            callback?.Invoke(innerState);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, TState startStateName, TState endStateName, out Transition<TState, TTransition, TSignal> transition)
        {
            transition = CreateTransition(transitionName, startStateName, endStateName);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, TState startStateName, TState endStateName,
            Action<Transition<TState, TTransition, TSignal>> callback)
        {
            var transition = CreateTransition(transitionName, startStateName, endStateName);
            callback?.Invoke(transition);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, TState startStateName, TState endStateName, out Transition<TState, TTransition, TSignal> transition,
            Action<Transition<TState, TTransition, TSignal>> callback)
        {
            transition = CreateTransition(transitionName, startStateName, endStateName);
            callback?.Invoke(transition);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition)
        {
            transition = CreateTransition(transitionName, startState, endState);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            Action<Transition<TState, TTransition, TSignal>> callback)
        {
            var transition = CreateTransition(transitionName, startState, endState);
            callback?.Invoke(transition);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Transition(
            TTransition transitionName, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState,
            out Transition<TState, TTransition, TSignal> transition, Action<Transition<TState, TTransition, TSignal>> callback)
        {
            transition = CreateTransition(transitionName, startState, endState);
            callback?.Invoke(transition);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, TTransition transitionName, out Signal<TState, TTransition, TSignal> signal)
        {
            ConnectSignal(signalName, transitionName, out signal);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, TTransition transitionName, Action<Signal<TState, TTransition, TSignal>> callback)
        {
            ConnectSignal(signalName, transitionName, out Signal<TState, TTransition, TSignal> signal);
            callback?.Invoke(signal);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, TTransition transitionName, out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback)
        {
            ConnectSignal(signalName, transitionName, out signal);
            callback?.Invoke(signal);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition, out Signal<TState, TTransition, TSignal> signal)
        {
            ConnectSignal(signalName, transition, out signal);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition,
            Action<Signal<TState, TTransition, TSignal>> callback)
        {
            ConnectSignal(signalName, transition, out Signal<TState, TTransition, TSignal> signal);
            callback?.Invoke(signal);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Signal(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition, out Signal<TState, TTransition, TSignal> signal,
            Action<Signal<TState, TTransition, TSignal>> callback)
        {
            ConnectSignal(signalName, transition, out signal);
            callback?.Invoke(signal);

            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Connect(
            TSignal signalName, TTransition transitionName)
        {
            ConnectSignal(signalName, transitionName);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Connect(
            TSignal signalName, Transition<TState, TTransition, TSignal> transition)
        {
            ConnectSignal(signalName, transition);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName)
        {
            ConnectSignal(signal, transitionName);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Connect(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition)
        {
            ConnectSignal(signal, transition);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Initial(
            TState stateName)
        {
            SetInitialState(stateName);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> state)
        {
            SetInitialState(state);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Initial(
            TState innerStateName, TState stateName, int orthogonalIndex = 0)
        {
            SetInitialState(innerStateName, stateName, orthogonalIndex);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Initial(
            TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            SetInitialState(innerStateName, state, orthogonalIndex);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Initial(
            State<TState, TTransition, TSignal> innerState, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            SetInitialState(innerState, state, orthogonalIndex);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> EmitCondition(
            TSignal signalName, params TState[] conditionalStateNames)
        {
            CreateEmitCondition(signalName, conditionalStateNames);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal, params TState[] conditionalStateNames)
        {
            CreateEmitCondition(signal, conditionalStateNames);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> EmitCondition(
            Signal<TState, TTransition, TSignal> signal, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            CreateEmitCondition(signal, conditionalStates);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> TransitionCondition(
            TSignal signalName, TTransition transitionName, params TState[] conditionalStateNames)
        {
            CreateTransitionCondition(signalName, transitionName, conditionalStateNames);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params TState[] conditionalStateNames)
        {
            CreateTransitionCondition(signal, transitionName, conditionalStateNames);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            CreateTransitionCondition(signal, transitionName, conditionalStates);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params TState[] conditionalStateNames)
        {
            CreateTransitionCondition(signal, transition, conditionalStateNames);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> TransitionCondition(
            Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            CreateTransitionCondition(signal, transition, conditionalStates);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Action(IStateMachineAction action)
        {
            AddAction(action);
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> Action<T>() where T : IStateMachineAction, new()
        {
            AddAction(new T());
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> OnInitialize(
            Action<IStateMachineAction> action)
        {
            return OnInitialize(null, action);
        }

        public StateMachine<TState, TTransition, TSignal> OnInitialize(
            string name, Action<IStateMachineAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateMachineActionInitialize(name, action));
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> OnTerminate(
            Action<IStateMachineAction> action)
        {
            return OnTerminate(null, action);
        }

        public StateMachine<TState, TTransition, TSignal> OnTerminate(
            string name, Action<IStateMachineAction> action)
        {
            if (action == null)
                return this;

            AddAction(new StateMachineActionTerminate(name, action));
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState, IState> action)
        {
            return OnStateChange(null, action);
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState, IState> action)
        {
            if (action == null)
                return this;

            AddAction(new StateMachineActionStateChange(name, action));
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            return OnStateChange(null, action);
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, IState<TState>, IState<TState>> action)
        {
            if (action == null)
                return this;

            AddAction(new StateMachineActionStateChange<TState>(name, action));
            return this;
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            return OnStateChange(null, action);
        }

        public StateMachine<TState, TTransition, TSignal> OnStateChange(
            string name, Action<IStateMachineAction, State<TState, TTransition, TSignal>, State<TState, TTransition, TSignal>> action)
        {
            if (action == null)
                return this;

            AddAction(new StateMachineActionStateChange<TState, TTransition, TSignal>(name, action));
            return this;
        }
    }
}
