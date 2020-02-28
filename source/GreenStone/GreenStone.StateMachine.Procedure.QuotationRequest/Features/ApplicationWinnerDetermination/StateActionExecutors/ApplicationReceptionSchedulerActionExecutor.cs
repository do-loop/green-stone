namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActionExecutors
{
    using System;
    using Models;
    using StateActions;

    /// <inheritdoc />
    public sealed class ApplicationWinnerDeterminationPublishProtocolActionExecutor : ProcedureStateActionExecutor<ApplicationWinnerDeterminationState, PublishProtocolStateAction>
    {
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

            // Add few block money sagas.
            ExecutionContext.AddBlockMoneySaga(new { Id = 1 });
            ExecutionContext.AddBlockMoneySaga(new { Id = 2 });
            ExecutionContext.AddBlockMoneySaga(new { Id = 3 });

            ExecutionContext.SetProcedureState(ProcedureStateEnum.ContractConclusion);
        }

        /// <inheritdoc />
        protected override void AfterExecute()
        {
            Console.WriteLine($"Протокол с идентификатором {ExecutionContext.GetProtocolId()} опубликован.");
        }
    }
}