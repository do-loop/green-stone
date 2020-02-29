namespace GreenStone.StateMachine.Application
{
    using Models;

    /// <summary>
    /// Состояние заявки на участие.
    /// </summary>
    public abstract class ApplicationState<TState> : State<Application, TState>
        where TState : class, IState<Application>
    {
        /// <inheritdoc />
        protected ApplicationState(IStateDescriptor<Application> descriptor, IStateActionExecutionProvider<Application, TState> provider)
            : base(descriptor, provider)
        { }
    }
}