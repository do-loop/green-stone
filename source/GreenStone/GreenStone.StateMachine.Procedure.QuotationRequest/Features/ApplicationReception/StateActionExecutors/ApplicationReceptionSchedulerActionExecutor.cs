namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationReception.StateActionExecutors
{
    using System;
    using Models;
    using StateActions;

    /// <inheritdoc />
    public sealed class ApplicationReceptionSchedulerActionExecutor : ProcedureStateActionExecutor<ApplicationReceptionState, SchedulerStateAction>
    {
        /// <inheritdoc />
        protected override void BeforeExecute()
        {
            if (ExecutionContext.GetProcedureState() != ProcedureStateEnum.ApplicationReception)
                throw new StateMachineException("Процедура находиться в статусе, непригодном для выполнения действия.");
        }

        /// <inheritdoc />
        protected override void Execute()
        {
            ExecutionContext.SetProcedureState(ProcedureStateEnum.ApplicationConsideration);
        }

        /// <inheritdoc />
        protected override void AfterExecute()
        {
            Console.WriteLine($"Процедура {ExecutionContext.GetProcedureId()} перешла в состояние {ExecutionContext.GetProcedureState()}.");
        }
    }
}