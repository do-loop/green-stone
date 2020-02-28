namespace GreenStone.StateMachine.Procedure
{
    using Models;

    /// <inheritdoc />
    public abstract class ProcedureStateActionExecutor<TState, TStateAction> : StateActionExecutor<Procedure, TState, TStateAction>
        where TState : class, IState<Procedure>
        where TStateAction : class, IStateAction
    { }
}