namespace GreenStone.StateMachine.Procedure
{
    using System.Collections.Generic;
    using Models;
    
    /// <inheritdoc />
    public sealed class ProcedureStateMachine : StateMachine<Procedure>
    {
        /// <inheritdoc />
        public ProcedureStateMachine(IEnumerable<IState<Procedure>> states) : base(states) { }
    }
}