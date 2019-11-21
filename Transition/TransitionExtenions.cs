namespace StateMachineFramework
{
    public static class TransitionExtenions
    {
        public static Direction<object> GetDirection(this ITransition transition)
            => new Direction<object>(transition.StartState.Name, transition.EndState.Name);

        public static Direction<TState> GetDirection<TState>(this ITransition transition)
            => new Direction<TState>((TState)transition.StartState.Name, (TState)transition.EndState.Name);

        public static Direction<TState> GetDirection<TState, TTransition, TSignal>(this ITransition<TState, TTransition, TSignal> transition)
            => new Direction<TState>(transition.StartState.Name, transition.EndState.Name);
    }
}
