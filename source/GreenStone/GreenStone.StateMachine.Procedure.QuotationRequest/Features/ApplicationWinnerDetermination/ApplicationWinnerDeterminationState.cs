namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination
{
    using Models;
    using StateActions;

    /// <inheritdoc />
    [StateAction(typeof(PublishProtocolStateAction))]
    public sealed class ApplicationWinnerDeterminationState : ProcedureState<ApplicationWinnerDeterminationState>
    {
        /// <inheritdoc />
        public ApplicationWinnerDeterminationState(
            IStateDescriptor<Procedure, ApplicationWinnerDeterminationState> descriptor,
            IStateActionExecutionProvider<Procedure, ApplicationWinnerDeterminationState> provider)
            : base(descriptor, provider)
        { }
    }
}