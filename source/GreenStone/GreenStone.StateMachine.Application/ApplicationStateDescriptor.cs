namespace GreenStone.StateMachine.Application
{
    using Models;

    /// <inheritdoc />
    public abstract class ApplicationStateDescriptor<TState> : StateDescriptor<Application, TState> where TState : class, IState<Application>
    {
        /// <inheritdoc />
        public abstract override bool Selectable(Application subject);
    }
}