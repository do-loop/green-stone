namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActionExecutors
{
    using System;
    using Application.Models;
    using Application.QuotationRequest.StateActions;
    using Models;
    using StateActions.PublishProtocol;

    /// <inheritdoc />
    public sealed class ApplicationWinnerDeterminationPublishProtocolActionExecutor : ProcedureStateActionExecutor<ApplicationWinnerDeterminationState, PublishProtocolStateAction>
    {
        private readonly IStateMachine<Application> _stateMachine;

        /// <inheritdoc />
        public ApplicationWinnerDeterminationPublishProtocolActionExecutor(IStateMachine<Application> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        /// <inheritdoc />
        protected override void BeforeExecute()
        {
            if (ExecutionContext.GetProcedureState() != ProcedureStateEnum.ApplicationWinnerDetermination)
                throw new StateMachineException("Процедура находиться в статусе, непригодном для выполнения действия.");
        }

        /// <inheritdoc />
        protected override void Execute()
        {
            Console.WriteLine($"Идентификатор публикуемого протокол: {ExecutionContext.GetProtocolId()}.");

            foreach (var application in ExecutionContext.Subject.Applications)
                _stateMachine.Execute(application, new ApproveStateAction());

            ExecutionContext.SetProcedureState(ProcedureStateEnum.ContractConclusion);
        }

        /// <inheritdoc />
        protected override void AfterExecute()
        {
            // Add few block money sagas.
            ExecutionContext.AddBlockMoneySaga(new { Id = 1 });
            ExecutionContext.AddBlockMoneySaga(new { Id = 2 });
            ExecutionContext.AddBlockMoneySaga(new { Id = 3 });

            Console.WriteLine($"Протокол с идентификатором {ExecutionContext.GetProtocolId()} опубликован.");
        }
    }
}