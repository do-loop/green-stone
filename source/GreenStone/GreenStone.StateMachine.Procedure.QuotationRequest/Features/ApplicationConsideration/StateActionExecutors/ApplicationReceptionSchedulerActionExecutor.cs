namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationConsideration.StateActionExecutors
{
    using System;
    using ApplicationConsideration;
    using Models;
    using StateActions;

    /// <inheritdoc />
    public sealed class ApplicationConsiderationSchedulerActionExecutor : ProcedureStateActionExecutor<ApplicationConsiderationState, SchedulerStateAction>
    {
        /// <inheritdoc />
        protected override void BeforeExecute()
        {
            if (ExecutionContext.GetProcedureState() != ProcedureStateEnum.ApplicationConsideration)
                throw new StateMachineException("Процедура находиться в статусе, непригодном для выполнения действия.");
        }

        /// <inheritdoc />
        protected override void Execute()
        {
            ExecutionContext.SetProcedureState(ProcedureStateEnum.ApplicationWinnerDetermination);
        }

        /// <inheritdoc />
        protected override void AfterExecute()
        {
            Console.WriteLine($"Процедура {ExecutionContext.GetProcedureId()} перешла в состояние {ExecutionContext.GetProcedureState()}.");
        }
    }
}