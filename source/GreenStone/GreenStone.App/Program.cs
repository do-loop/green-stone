namespace GreenStone.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Castle.Windsor;
    using StateMachine.Application.Models;
    using StateMachine;
    using StateMachine.Application;
    using StateMachine.Application.QuotationRequest.Features.Submitted;
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
                typeof(ProcedureStateMachine).Assembly,
                typeof(StateActionExecutionContextExtensions).Assembly,
                typeof(ApplicationStateMachine).Assembly,
                typeof(SubmittedState).Assembly,
            };

            container.AddStateMachine<Procedure>(assemblies)
                .AddState<ApplicationConsiderationState>()
                .AddState<ApplicationReceptionState>()
                .AddState<ApplicationWinnerDeterminationState>();

            container.AddStateMachine<Application>(assemblies)
                .AddState<SubmittedState>();

            var procedure = new Procedure
            {
                State = ProcedureStateEnum.ApplicationReception,
                Applications = new List<Application>
                {
                    new Application { State = ApplicationStateEnum.Submitted },
                    new Application { State = ApplicationStateEnum.Submitted },
                    new Application { State = ApplicationStateEnum.Submitted }
                }
            };

            // 1. Прием заявок.
            // 2. Рассмотрение заявок.
            // 3. Определение победителя среди заявок (публикация протокола).
            //    3.1 Все заявки допускаем.
            // 4. Заключение контракта.

            var data = new PublishProtocolStateActionData();
            var action = new PublishProtocolStateAction(data);

            container.Resolve<IStateMachine<Procedure>>()
                .Execute(procedure, new SchedulerStateAction())
                .Execute(procedure, new SchedulerStateAction())
                .Execute(procedure, action);

            Console.WriteLine(procedure.State); // Заключение контракта.
            Console.WriteLine(action.Result.BlockMoneySagas.Count); // 3
            Console.WriteLine(procedure.Applications.All(x => x.State == ApplicationStateEnum.Approved)); // true

            Console.ReadKey();
        }
    }
}