namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationConsideration
{
    using Models;
    using StateActions;

    /// <inheritdoc />
    [StateAction(typeof(SchedulerStateAction))]
    public sealed class ApplicationConsiderationState : ProcedureState<ApplicationConsiderationState>
    {
        /// <inheritdoc />
        public ApplicationConsiderationState(
            IStateDescriptor<Procedure, ApplicationConsiderationState> descriptor,
            IStateActionExecutionProvider<Procedure, ApplicationConsiderationState> provider)
            : base(descriptor, provider)
        { }
    }
}