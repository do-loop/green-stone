namespace GreenStone.StateMachine.Procedure
{
    using Models;

    /// <summary>
    /// Состояние электронной процедуры.
    /// </summary>
    public abstract class ProcedureState<TState> : State<Procedure, TState>
        where TState : class, IState<Procedure>
    {
        /// <inheritdoc />
        protected ProcedureState(IStateDescriptor<Procedure> descriptor, IStateActionExecutionProvider<Procedure, TState> provider)
            : base(descriptor, provider)
        { }
    }
}