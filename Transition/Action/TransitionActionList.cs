﻿using System.Collections.Generic;

namespace StateMachineFramework
{
    internal sealed class TransitionActionList : List<ITransitionAction>
    {
        internal TransitionActionList() : base() { }

        internal TransitionActionList(int capacity) : base(capacity) { }

        internal TransitionActionList(IEnumerable<ITransitionAction> collection) : base(collection) { }

        internal void Invoke(TransitionArgs args)
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Invoke(args);
            }
        }

        internal void Start(TransitionArgs args)
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Start(args);
            }
        }

        internal void Finish()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this[i].Finish();
            }
        }
    }
}
