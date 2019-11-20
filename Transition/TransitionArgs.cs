using System;

namespace StateMachineFramework
{
    public class TransitionArgs : EventArgs
    {
        public bool CancelTransition { get; set; }
    }
}