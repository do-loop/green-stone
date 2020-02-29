namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActions.PublishProtocol
{
    using System.Collections.Generic;

    /// <summary>
    /// Результат выполнения действия публикации протокола.
    /// </summary>
    public sealed class PublishProtocolStateActionResult
    {
        /// <summary>
        /// Саги на блокировку денежных средств.
        /// </summary>
        public List<object> BlockMoneySagas = new List<object>();
    }
}