namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationConsideration
{
    using Models;

    /// <inheritdoc />
    public sealed class ApplicationConsiderationStateDescriptor : ProcedureStateDescriptor<ApplicationConsiderationState>
    {
        /// <inheritdoc />
        public override bool Selectable(Procedure subject)
        {
            return subject.State == ProcedureStateEnum.ApplicationConsideration;
        }
    }
}