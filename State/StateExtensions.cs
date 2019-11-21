namespace StateMachineFramework
{
    public static class StateExtensions
    {
        public static Direction<object> To(this IState from, IState to)
            => new Direction<object>(from.Name, to.Name);

        public static Direction<T> To<T>(this IState<T> from, IState<T> to)
            => new Direction<T>(from.Name, to.Name);
    }
}
