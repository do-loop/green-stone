namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationReception
{
    using Models;

    /// <inheritdoc />
    public sealed class ApplicationReceptionStateDescriptor : ProcedureStateDescriptor<ApplicationReceptionState>
    {
        /// <inheritdoc />
        public override bool Selectable(Procedure subject)
        {
            return subject.Type == ProcedureType.QuotationRequest &&
                   subject.State == ProcedureStateEnum.ApplicationReception;
        }
    }
}