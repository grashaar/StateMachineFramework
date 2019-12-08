using System.Collections.Generic;

namespace StateMachineFramework
{
    internal sealed class StateMachineActionList : List<IStateMachineAction>
    {
        internal StateMachineActionList() : base() { }

        internal StateMachineActionList(int capacity) : base(capacity) { }

        internal StateMachineActionList(IEnumerable<IStateMachineAction> collection) : base(collection) { }

        internal void Initialize()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Initialize();
            }
        }

        internal void StateChange<TState, TTransition, TSignal>(State<TState, TTransition, TSignal> priorState, State<TState, TTransition, TSignal> formerState)
        {
            for (var i = 0; i < this.Count; i++)
            {
                switch (this[i])
                {
                    case IStateMachineAction<TState, TTransition, TSignal> actionSTS:
                        actionSTS.StateChange(priorState, formerState);
                        break;

                    case IStateMachineAction<TState> actionT:
                        actionT.StateChange(priorState, formerState);
                        break;

                    default:
                        this[i].StateChange(priorState, formerState);
                        break;
                }
            }
        }

        internal void Terminate()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Terminate();
            }
        }
    }
}
