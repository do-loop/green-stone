namespace GreenStone.StateMachine.Application.QuotationRequest.Features.Submitted
{
    using Models;
    using StateActions;

    /// <inheritdoc />
    [StateAction(typeof(ApproveStateAction))]
    public sealed class SubmittedState : ApplicationState<SubmittedState>
    {
        /// <inheritdoc />
        public SubmittedState(
            IStateDescriptor<Application, SubmittedState> descriptor,
            IStateActionExecutionProvider<Application, SubmittedState> provider)
            : base(descriptor, provider)
        { }
    }
}