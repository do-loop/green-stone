namespace GreenStone.StateMachine.Application.QuotationRequest.Features.Submitted.StateActionExecutors
{
    using Application;
    using Models;
    using StateActions;
    using Submitted;

    /// <inheritdoc />
    public sealed class SubmittedStateApproveActionExecutor : ApplicationStateActionExecutor<SubmittedState, ApproveStateAction>
    {
        /// <inheritdoc />
        protected override void Execute()
        {
            ExecutionContext.Subject.State = ApplicationStateEnum.Approved;
        }
    }
}