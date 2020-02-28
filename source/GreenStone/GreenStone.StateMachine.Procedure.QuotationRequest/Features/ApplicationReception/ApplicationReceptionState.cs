namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationReception
{
    using Models;
    using StateActions;

    /// <inheritdoc />
    [StateAction(typeof(SchedulerStateAction))]
    public sealed class ApplicationReceptionState : ProcedureState<ApplicationReceptionState>
    {
        /// <inheritdoc />
        public ApplicationReceptionState(
            IStateDescriptor<Procedure, ApplicationReceptionState> descriptor,
            IStateActionExecutionProvider<Procedure, ApplicationReceptionState> provider)
            : base(descriptor, provider)
        { }
    }
}