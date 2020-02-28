namespace GreenStone.StateMachine.Procedure
{
    using System.Collections.Generic;
    using Models;

    /// <inheritdoc />
    public sealed class ProcedureStateMachineFactory : StateMachineFactory<Procedure>
    {
        /// <inheritdoc />
        public ProcedureStateMachineFactory(IEnumerable<IStateMachine<Procedure>> machines)
            : base(machines)
        { }
    }
}