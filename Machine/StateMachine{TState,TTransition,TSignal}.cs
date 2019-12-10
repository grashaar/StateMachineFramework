using System.Collections.Generic;
using System.Linq;

namespace StateMachineFramework
{
    public partial class StateMachine<TState, TTransition, TSignal>
        : IStateMachine<TState, TTransition, TSignal>
    {
        public bool Initialized { get; private set; }

        public State<TState, TTransition, TSignal> CurrentState
            => this.CurrentStateI;

        public State<TState, TTransition, TSignal> InitialState
            => this.InitialStateI;

        public Transition<TState, TTransition, TSignal> CurrentTransition
            => this.CurrentTransitionI;

        public IReadOnlyList<State<TState, TTransition, TSignal>> States
            => this.StatesI.Values.ToList();

        public IReadOnlyList<Signal<TState, TTransition, TSignal>> Signals
            => this.SignalsI.Values.ToList();

        public IReadOnlyList<Transition<TState, TTransition, TSignal>> Transitions
            => this.TransitionsI.Values.ToList();

        public IReadOnlyList<IStateMachineAction> Actions
            => this.actions;

        IState IStateMachine.InitialState
            => this.InitialStateI;

        IState IStateMachine.CurrentState
            => this.CurrentStateI;

        ITransition IStateMachine.CurrentTransition
            => this.CurrentTransitionI;

        IReadOnlyList<IState> IStateMachine.States
            => this.StatesI.Values.ToList();

        IReadOnlyList<ISignal> IStateMachine.Signals
            => this.SignalsI.Values.ToList();

        IReadOnlyList<ITransition> IStateMachine.Transitions
            => this.TransitionsI.Values.ToList();

        /// <summary>
        /// Internal <see cref="InitialState"/>
        /// </summary>
        internal State<TState, TTransition, TSignal> InitialStateI { get; private set; }

        /// <summary>
        /// Internal <see cref="CurrentState"/>
        /// </summary>
        internal State<TState, TTransition, TSignal> CurrentStateI { get; private set; }

        /// <summary>
        /// Internal <see cref="CurrentTransition"/>
        /// </summary>
        internal Transition<TState, TTransition, TSignal> CurrentTransitionI { get; private set; }

        /// <summary>
        /// Internal <see cref="States"/>
        /// </summary>
        internal Dictionary<TState, State<TState, TTransition, TSignal>> StatesI { get; }

        /// <summary>
        /// Internal <see cref="Signals"/>
        /// </summary>
        internal Dictionary<TSignal, Signal<TState, TTransition, TSignal>> SignalsI { get; }

        /// <summary>
        /// Internal <see cref="Transitions"/>
        /// </summary>
        internal Dictionary<TTransition, Transition<TState, TTransition, TSignal>> TransitionsI { get; }

        private readonly StateMachineActionList actions;

        public StateMachine()
        {
            this.StatesI = new Dictionary<TState, State<TState, TTransition, TSignal>>();
            this.SignalsI = new Dictionary<TSignal, Signal<TState, TTransition, TSignal>>();
            this.TransitionsI = new Dictionary<TTransition, Transition<TState, TTransition, TSignal>>();
            this.actions = new StateMachineActionList();
        }

        #region State Creation
        internal bool AddState(State<TState, TTransition, TSignal> state)
        {
            if (state == null || this.StatesI.ContainsKey(state.Name))
            {
                return false;
            }

            state.SetStateMachine(this);
            this.StatesI.Add(state.Name, state);
            return true;
        }

        public State<TState, TTransition, TSignal> CreateState(TState stateName)
        {
            var state = new State<TState, TTransition, TSignal>(stateName);
            AddState(state);
            return state;
        }

        public State<TState, TTransition, TSignal> CreateState(TState innerStateName, TState stateName, int orthogonalIndex = 0)
        {
            var state = this.StatesI[stateName];
            return CreateState(innerStateName, state, orthogonalIndex);
        }

        public State<TState, TTransition, TSignal> CreateState(TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            var innerState = new State<TState, TTransition, TSignal>(innerStateName);
            this.StatesI.Add(innerStateName, innerState);

            state.AddInnerState(innerState, orthogonalIndex);

            return innerState;
        }

        public bool TryCreateState(TState stateName, out State<TState, TTransition, TSignal> state)
        {
            if (this.StatesI.ContainsKey(stateName))
            {
                state = null;
                return false;
            }

            state = CreateState(stateName);
            return true;
        }

        public bool TryCreateState(TState innerStateName, TState stateName, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            if (!this.StatesI.ContainsKey(stateName) || this.StatesI.ContainsKey(innerStateName))
            {
                innerState = null;
                return false;
            }

            var state = this.StatesI[stateName];
            return TryCreateState(innerStateName, state, out innerState, orthogonalIndex);
        }

        public bool TryCreateState(TState innerStateName, State<TState, TTransition, TSignal> state, out State<TState, TTransition, TSignal> innerState, int orthogonalIndex = 0)
        {
            if (state == null)
            {
                innerState = null;
                return false;
            }

            innerState = CreateState(innerStateName, state, orthogonalIndex);
            return true;
        }
        #endregion

        #region Transition Creation
        public Transition<TState, TTransition, TSignal> CreateTransition(TTransition transitionName, TState startStateName, TState endStateName)
        {
            var startState = this.StatesI[startStateName];
            var endState = this.StatesI[endStateName];

            if (startState.MachineI != endState.MachineI)
            {
                throw new InvalidTransitionException<TState, TTransition>(startState.Name, endState.Name, transitionName);
            }

            return CreateTransition(transitionName, startState, endState);
        }

        public Transition<TState, TTransition, TSignal> CreateTransition(TTransition transitionName, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState)
        {
            if (startState == null || endState == null)
            {
                return null;
            }

            if (startState.MachineI != endState.MachineI)
            {
                throw new InvalidTransitionException<TState, TTransition>(startState.Name, endState.Name, transitionName);
            }

            var transition = new Transition<TState, TTransition, TSignal>(this, transitionName, startState, endState);
            this.TransitionsI.Add(transitionName, transition);
            startState.AddTransition(transition, endState);

            return transition;
        }

        public bool TryCreateTransition(TTransition transitionName, TState startStateName, TState endStateName, out Transition<TState, TTransition, TSignal> transition)
        {
            if (this.TransitionsI.ContainsKey(transitionName) || !this.StatesI.ContainsKey(startStateName) || !this.StatesI.ContainsKey(endStateName))
            {
                transition = null;
                return false;
            }

            var startState = this.StatesI[startStateName];
            var endState = this.StatesI[endStateName];
            return TryCreateTransition(transitionName, startState, endState, out transition);
        }

        public bool TryCreateTransition(TTransition transitionName, State<TState, TTransition, TSignal> startState, State<TState, TTransition, TSignal> endState, out Transition<TState, TTransition, TSignal> transition)
        {
            if (startState == null || endState == null || this.TransitionsI.ContainsKey(transitionName))
            {
                transition = null;
                return false;
            }

            if (startState.MachineI != endState.MachineI)
            {
                throw new InvalidTransitionException<TState, TTransition>(startState.Name, endState.Name, transitionName);
            }

            transition = CreateTransition(transitionName, startState, endState);
            return true;
        }
        #endregion

        #region Signal Creation And Connection
        public bool ConnectSignal(TSignal signalName, TTransition transitionName)
        {
            if (!this.TransitionsI.ContainsKey(transitionName))
            {
                return false;
            }

            var transition = this.TransitionsI[transitionName];
            return ConnectSignal(signalName, transition);
        }

        public bool ConnectSignal(TSignal signalName, TTransition transitionName, out Signal<TState, TTransition, TSignal> signal)
        {
            if (!this.TransitionsI.ContainsKey(transitionName))
            {
                signal = null;
                return false;
            }

            var transition = this.TransitionsI[transitionName];
            return ConnectSignal(signalName, transition, out signal);
        }

        public bool ConnectSignal(TSignal signalName, Transition<TState, TTransition, TSignal> transition)
        {
            if (transition == null)
            {
                return false;
            }

            if (!this.SignalsI.ContainsKey(signalName))
            {
                CreateSignal(signalName, transition);
                return true;
            }

            var signal = this.SignalsI[signalName];

            return ConnectSignal(signal, transition);
        }

        public bool ConnectSignal(TSignal signalName, Transition<TState, TTransition, TSignal> transition, out Signal<TState, TTransition, TSignal> signal)
        {
            if (transition == null)
            {
                signal = null;
                return false;
            }

            if (!this.SignalsI.ContainsKey(signalName))
            {
                signal = CreateSignal(signalName, transition);
                return true;
            }
            else
            {
                signal = this.SignalsI[signalName];
            }

            return ConnectSignal(signal, transition);
        }

        public bool ConnectSignal(Signal<TState, TTransition, TSignal> signal, TTransition transitionName)
        {
            if (signal == null || !this.TransitionsI.ContainsKey(transitionName))
            {
                return false;
            }

            var transition = this.TransitionsI[transitionName];
            return ConnectSignal(signal, transition);
        }

        public bool ConnectSignal(Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition)
        {
            if (signal == null || transition == null)
            {
                return false;
            }

            return signal.AddTransition(transition) && transition.AddSignal(signal);
        }

        public Signal<TState, TTransition, TSignal> CreateSignal(TSignal signalName, Transition<TState, TTransition, TSignal> transition)
        {
            if (transition == null)
            {
                return null;
            }

            var signal = new Signal<TState, TTransition, TSignal>(this, signalName);
            signal.AddTransition(transition);
            transition.AddSignal(signal);
            this.SignalsI.Add(signal.Name, signal);

            return signal;
        }
        #endregion

        #region Set Initial State
        public bool SetInitialState(TState stateName)
        {
            if (!this.StatesI.ContainsKey(stateName))
            {
                return false;
            }

            var state = this.StatesI[stateName];
            return SetInitialState(state);
        }

        public bool SetInitialState(State<TState, TTransition, TSignal> state)
        {
            if (this.InitialStateI != null || this.CurrentStateI != null || this.Initialized || state == null)
            {
                return false;
            }

            this.InitialStateI = state;
            return true;
        }

        public bool SetInitialState(TState innerStateName, TState stateName, int orthogonalIndex = 0)
        {
            if (!this.StatesI.ContainsKey(stateName))
            {
                return false;
            }

            var state = this.StatesI[stateName];
            return SetInitialState(innerStateName, state, orthogonalIndex);
        }

        public bool SetInitialState(TState innerStateName, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            if (!this.StatesI.ContainsKey(innerStateName))
            {
                return false;
            }

            var innerState = this.StatesI[innerStateName];
            return SetInitialState(innerState, state, orthogonalIndex);
        }

        public bool SetInitialState(State<TState, TTransition, TSignal> innerState, State<TState, TTransition, TSignal> state, int orthogonalIndex = 0)
        {
            if (innerState == null || state == null)
            {
                return false;
            }

            // Set state's currentState to innerState
            state.SetInitialInnerState(innerState, orthogonalIndex);
            return true;
        }
        #endregion

        #region Create Condition
        public bool CreateEmitCondition(TSignal signalName, params TState[] conditionalStateNames)
        {
            if (!this.SignalsI.ContainsKey(signalName))
            {
                return false;
            }

            var signal = this.SignalsI[signalName];
            return CreateEmitCondition(signal, conditionalStateNames);
        }

        public bool CreateEmitCondition(Signal<TState, TTransition, TSignal> signal, params TState[] conditionalStateNames)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name))
            {
                return false;
            }

            var conditionalStates = new State<TState, TTransition, TSignal>[conditionalStateNames.Length];
            for (var i = 0; i < conditionalStateNames.Length; i++)
            {
                if (!this.StatesI.ContainsKey(conditionalStateNames[i]))
                {
                    return false;
                }

                conditionalStates[i] = this.StatesI[conditionalStateNames[i]];
            }

            return CreateEmitCondition(signal, conditionalStates);
        }

        public bool CreateEmitCondition(Signal<TState, TTransition, TSignal> signal, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name))
            {
                return false;
            }

            foreach (var conditionalState in conditionalStates)
            {
                if (conditionalState == null || !this.StatesI.ContainsKey(conditionalState.Name))
                {
                    return false;
                }
            }

            var signalCondition = new SignalCondition<TState, TTransition, TSignal>();
            signalCondition.AddCondition(conditionalStates);
            signal.AddEmitCondition(signalCondition);
            return true;
        }

        public bool CreateTransitionCondition(TSignal signalName, TTransition transitionName, params TState[] conditionalStateNames)
        {
            if (!this.SignalsI.ContainsKey(signalName) ||
                !this.TransitionsI.ContainsKey(transitionName))
            {
                return false;
            }

            var signal = this.SignalsI[signalName];
            var transition = this.TransitionsI[transitionName];
            return CreateTransitionCondition(signal, transition, conditionalStateNames);
        }

        public bool CreateTransitionCondition(Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params TState[] conditionalStateNames)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name) ||
                !this.TransitionsI.ContainsKey(transitionName))
            {
                return false;
            }

            var transition = this.TransitionsI[transitionName];
            return CreateTransitionCondition(signal, transition, conditionalStateNames);
        }

        public bool CreateTransitionCondition(Signal<TState, TTransition, TSignal> signal, TTransition transitionName, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name) ||
                !this.TransitionsI.ContainsKey(transitionName))
            {
                return false;
            }

            var transition = this.TransitionsI[transitionName];
            return CreateTransitionCondition(signal, transition, conditionalStates);
        }

        public bool CreateTransitionCondition(Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params TState[] conditionalStateNames)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name) ||
                transition == null || !this.TransitionsI.ContainsKey(transition.Name))
            {
                return false;
            }

            var conditionalStates = new State<TState, TTransition, TSignal>[conditionalStateNames.Length];
            for (var i = 0; i < conditionalStateNames.Length; i++)
            {
                if (!this.StatesI.ContainsKey(conditionalStateNames[i]))
                {
                    return false;
                }

                conditionalStates[i] = this.StatesI[conditionalStateNames[i]];
            }

            return CreateTransitionCondition(signal, transition, conditionalStates);
        }

        public bool CreateTransitionCondition(Signal<TState, TTransition, TSignal> signal, Transition<TState, TTransition, TSignal> transition, params State<TState, TTransition, TSignal>[] conditionalStates)
        {
            if (signal == null || !this.SignalsI.ContainsKey(signal.Name) ||
                transition == null || !this.TransitionsI.ContainsKey(transition.Name))
            {
                return false;
            }

            foreach (var conditionalState in conditionalStates)
            {
                if (conditionalState == null || !this.StatesI.ContainsKey(conditionalState.Name))
                {
                    return false;
                }
            }

            var signalCondition = new SignalCondition<TState, TTransition, TSignal>();
            signalCondition.AddCondition(conditionalStates);
            signal.AddTransitionCondition(signalCondition, transition);
            return true;
        }
        #endregion

        public bool AddAction(IStateMachineAction action)
        {
            if (action == null || this.actions.Contains(action))
                return false;

            switch (action)
            {
                case IStateMachineAction<TState, TTransition, TSignal> actionSTS:
                    actionSTS.Machine = this;
                    break;

                default:
                    action.Machine = this;
                    break;
            }

            this.actions.Add(action);
            return true;
        }

        public void Initialize()
        {
            if (!this.Initialized && this.CurrentStateI == null && this.InitialStateI != null)
            {
                this.actions.Initialize();
                this.Initialized = true;
                this.CurrentStateI = this.InitialStateI;
                this.CurrentStateI.Enter();
            }
        }

        public void Terminate()
        {
            this.Initialized = false;
            this.CurrentStateI?.Terminate();
            this.CurrentStateI = null;
            this.actions.Terminate();
        }

        public void Tick()
        {
            this.CurrentStateI?.Update();
            this.CurrentTransitionI?.Update();
        }

        public void EmitSignal(object signalName)
        {
            if (signalName is TSignal name)
            {
                EmitSignal(name);
            }
        }

        public void EmitSignal(TSignal signalName)
        {
            if (!this.SignalsI.ContainsKey(signalName))
            {
                return;
            }

            this.SignalsI[signalName].Emit();
        }

        public State<TState, TTransition, TSignal> GetStateByName(TState stateName)
        {
            return this.StatesI[stateName];
        }

        public Transition<TState, TTransition, TSignal> GetTransitionByName(TTransition transitionName)
        {
            return this.TransitionsI[transitionName];
        }

        public Signal<TState, TTransition, TSignal> GetSignalByName(TSignal signalName)
        {
            return this.SignalsI[signalName];
        }

        public List<TState> GetAllActiveStateNames()
        {
            return this.StatesI.Values.Where(s => s.IsCurrentState).Select(s => s.Name).ToList();
        }

        public List<string> GetAllActiveStateNamesAsString()
        {
            return this.StatesI.Values.Where(s => s.IsCurrentState).Select(s => s.Name.ToString()).ToList();
        }

        public List<State<TState, TTransition, TSignal>> GetAllActiveStates()
        {
            return this.StatesI.Values.Where(s => s.IsCurrentState).ToList();
        }

        List<IState> IStateMachine.GetAllActiveStates()
        {
            return this.StatesI.Values.Where(s => s.IsCurrentState).ToList<IState>();
        }

        internal void FireOnStateChanged(State<TState, TTransition, TSignal> priorState, State<TState, TTransition, TSignal> formerState)
        {
            this.actions.StateChange(priorState, formerState);
        }

        internal void ProcessSignal(Signal<TState, TTransition, TSignal> signal)
        {
            if (this.CurrentTransitionI != null)
                return;

            foreach (var transition in signal.SignalToI)
            {
                if (this.CurrentStateI.TransitionsI.ContainsKey(transition) && transition.CanTransitionI)
                {
                    this.CurrentTransitionI = transition;
                    break;
                }
            }

            if (this.CurrentTransitionI == null)
            {
                this.CurrentStateI.PassSignal(signal);
                return;
            }

            if (!this.CurrentTransitionI.Invoke(signal))
            {
                signal.DoNotProcess();
                this.CurrentTransitionI = null;
            }
        }

        internal void TerminateTransition(Transition<TState, TTransition, TSignal> transition, Signal<TState, TTransition, TSignal> signal)
        {
            if (this.CurrentTransitionI != transition)
                return;

            if (this.CurrentStateI != transition.EndStateI)
                signal.DoNotProcess();

            this.CurrentTransitionI = null;
        }

        internal void StartTransition(Transition<TState, TTransition, TSignal> transition, Signal<TState, TTransition, TSignal> signal)
        {
            if (this.CurrentTransitionI != transition)
                return;

            this.CurrentStateI.Exit();

            if (!transition.Start())
            {
                this.CurrentStateI.Enter();
                transition.Terminate();
                return;
            }

            this.CurrentStateI = transition.EndStateI;
            this.CurrentStateI.Enter();

            FireOnStateChanged(transition.StartStateI, transition.EndStateI);
            signal.DoProcess();
        }

        internal void FinishTransition(Transition<TState, TTransition, TSignal> transition)
        {
            if (this.CurrentTransitionI != transition)
                return;

            transition.Finish();
            this.CurrentTransitionI = null;
        }
    }
}
