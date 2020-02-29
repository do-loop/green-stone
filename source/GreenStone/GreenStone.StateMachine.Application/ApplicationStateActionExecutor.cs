namespace GreenStone.StateMachine.Application
{
    using Models;

    /// <inheritdoc />
    public abstract class ApplicationStateActionExecutor<TState, TStateAction> : StateActionExecutor<Application, TState, TStateAction>
        where TState : class, IState<Application>
        where TStateAction : class, IStateAction
    { }
}