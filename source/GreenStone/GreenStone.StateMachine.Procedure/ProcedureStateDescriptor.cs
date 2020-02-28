namespace GreenStone.StateMachine.Procedure
{
    using Models;

    /// <inheritdoc />
    public abstract class ProcedureStateDescriptor<TState> : StateDescriptor<Procedure, TState> where TState : class, IState<Procedure>
    {
        /// <inheritdoc />
        public abstract override bool Selectable(Procedure subject);
    }
}