namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationConsideration.StateActionExecutors
{
    using System;
    using Application.Models;
    using Application.QuotationRequest.StateActions;
    using ApplicationConsideration;
    using Models;
    using StateActions;

    /// <inheritdoc />
    public sealed class ApplicationConsiderationSchedulerActionExecutor : ProcedureStateActionExecutor<ApplicationConsiderationState, SchedulerStateAction>
    {
        private readonly IStateMachine<Application> _stateMachine;

        /// <inheritdoc />
        public ApplicationConsiderationSchedulerActionExecutor(IStateMachine<Application> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        /// <inheritdoc />
        protected override void BeforeExecute()
        {
            if (ExecutionContext.GetProcedureState() != ProcedureStateEnum.ApplicationConsideration)
                throw new StateMachineException("Процедура находиться в статусе, непригодном для выполнения действия.");
        }

        /// <inheritdoc />
        protected override void Execute()
        {
            foreach (var application in ExecutionContext.Subject.Applications)
                _stateMachine.Execute(application, new ApproveStateAction());

            ExecutionContext.SetProcedureState(ProcedureStateEnum.ApplicationWinnerDetermination);
        }

        /// <inheritdoc />
        protected override void AfterExecute()
        {
            Console.WriteLine($"Процедура {ExecutionContext.GetProcedureId()} перешла в состояние {ExecutionContext.GetProcedureState()}.");
        }
    }
}