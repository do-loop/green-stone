namespace GreenStone.StateMachine.Procedure.QuotationRequest
{
    using Models;

    /// <summary>
    /// Методы расширения для контекста выполенния действия.
    /// </summary>
    public static class StateActionExecutionContextExtensions
    {
        /// <summary>
        /// Возвращает наименование процедуры.
        /// </summary>
        public static string GetProcedureName<TStateAction>(this StateActionExecutionContext<Procedure, TStateAction> context)
            where TStateAction : class, IStateAction
        {
            return context.Subject.Name;
        }

        /// <summary>
        /// Возвращает идентификатор процедуры.
        /// </summary>
        public static int GetProcedureId<TStateAction>(this StateActionExecutionContext<Procedure, TStateAction> context)
            where TStateAction : class, IStateAction
        {
            return context.Subject.Id;
        }

        /// <summary>
        /// Возвращает состояние процедуры.
        /// </summary>
        public static ProcedureStateEnum GetProcedureState<TStateAction>(this StateActionExecutionContext<Procedure, TStateAction> context)
            where TStateAction : class, IStateAction
        {
            return context.Subject.State;
        }

        /// <summary>
        /// Возвращает состояние процедуры.
        /// </summary>
        public static void SetProcedureState<TStateAction>(this StateActionExecutionContext<Procedure, TStateAction> context, ProcedureStateEnum state)
            where TStateAction : class, IStateAction
        {
            context.Subject.State = state;
        }
    }
}