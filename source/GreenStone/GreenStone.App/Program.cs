namespace GreenStone.App
{
    using System;
    using System.Text;
    using Castle.Windsor;
    using StateMachine;
    using StateMachine.Procedure;
    using StateMachine.Procedure.Models;
    using StateMachine.Procedure.QuotationRequest;
    using StateMachine.Procedure.QuotationRequest.Features.ApplicationConsideration;
    using StateMachine.Procedure.QuotationRequest.Features.ApplicationReception;
    using StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination;
    using StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActions.PublishProtocol;
    using StateMachine.Procedure.QuotationRequest.StateActions;
    using StateMachine.Registration;

    public sealed class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var container = new WindsorContainer();

            var assemblies = new[]
            {
                typeof(ProcedureStateMachineDescriptor).Assembly,
                typeof(QuotationRequestProcedureStateMachineDescriptor).Assembly,
            };

            container.AddStateMachine<Procedure>(assemblies)
                .AddState<ApplicationConsiderationState>()
                .AddState<ApplicationReceptionState>()
                .AddState<ApplicationWinnerDeterminationState>();

            var procedure = new Procedure
            {
                State = ProcedureStateEnum.ApplicationReception
            };

            // 1. Прием заявок.
            // 2. Рассмотрение заявок.
            // 3. Определение победителя среди заявок (публикация протокола).
            // 4. Заключение контракта.

            var data = new PublishProtocolStateActionData();
            var action = new PublishProtocolStateAction(data);

            container.Resolve<IStateMachineFactory<Procedure>>().Create(procedure)
                .Execute(procedure, new SchedulerStateAction())
                .Execute(procedure, new SchedulerStateAction())
                .Execute(procedure, action);

            Console.WriteLine(action.Result.BlockMoneySagas.Count); // 3
            Console.WriteLine(procedure.State); // Заключение контракта.

            Console.ReadKey();
        }
    }
}