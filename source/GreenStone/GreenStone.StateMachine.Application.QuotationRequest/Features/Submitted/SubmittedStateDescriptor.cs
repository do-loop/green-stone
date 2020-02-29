namespace GreenStone.StateMachine.Application.QuotationRequest.Features.Submitted
{
    using Models;

    /// <inheritdoc />
    public sealed class SubmittedStateDescriptor : ApplicationStateDescriptor<SubmittedState>
    {
        /// <inheritdoc />
        public override bool Selectable(Application subject)
        {
            return subject.State == ApplicationStateEnum.Submitted;
        }
    }
}