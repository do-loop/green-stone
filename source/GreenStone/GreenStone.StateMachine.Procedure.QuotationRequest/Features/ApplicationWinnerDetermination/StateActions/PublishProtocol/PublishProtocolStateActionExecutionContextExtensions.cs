namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActions
{
    using Models;

    /// <summary>
    /// Методы расширения для контекста выполенния действия.
    /// </summary>
    public static class PublishProtocolStateActionExecutionContextExtensions
    {
        /// <summary>
        /// Возвращает идентификатор публикуемого протокола.
        /// </summary>
        public static int GetProtocolId(this StateActionExecutionContext<Procedure, PublishProtocolStateAction> context)
        {
            return context.Action.Data.ProtocolId;
        }

        /// <summary>
        /// Добавляет сагу на блокировку денежных средств.
        /// </summary>
        public static void AddBlockMoneySaga(this StateActionExecutionContext<Procedure, PublishProtocolStateAction> context, object saga)
        {
            context.Action.Result.BlockMoneySagas.Add(saga);
        }
    }
}