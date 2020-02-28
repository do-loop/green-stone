namespace GreenStone.StateMachine.Procedure.QuotationRequest
{
    using Models;

    /// <inheritdoc />
    public sealed class QuotationRequestProcedureStateMachineDescriptor : ProcedureStateMachineDescriptor
    {
        /// <inheritdoc />
        public override bool Selectable(Procedure subject)
        {
            return subject.Type == ProcedureType.QuotationRequest;
        }
    }
}