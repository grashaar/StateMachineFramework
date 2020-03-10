using System.Collections.Generic;

namespace StateMachineFramework
{
    internal sealed class StateActionList : List<IStateAction>
    {
        internal StateActionList() : base() { }

        internal StateActionList(int capacity) : base(capacity) { }

        internal StateActionList(IEnumerable<IStateAction> collection) : base(collection) { }

        internal void Enter()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Enter();
            }
        }

        internal void Resume()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Resume();
            }
        }

        internal void LateEnter()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Enter();
            }
        }

        internal void Exit()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Exit();
            }
        }

        internal void Update()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Update();
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
