namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActions
{
    /// <summary>
    /// Данные для выполнения действия публикации протокола.
    /// </summary>
    public sealed class PublishProtocolStateActionData
    {
        /// <summary>
        /// Идентификатор протокола.
        /// </summary>
        public int ProtocolId { get; set; } = 666;
    }
}