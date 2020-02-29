namespace GreenStone.StateMachine.Procedure.QuotationRequest.Features.ApplicationWinnerDetermination.StateActions.PublishProtocol
{
    using System;

    /// <summary>
    /// Действие публикации протокола.
    /// </summary>
    public sealed class PublishProtocolStateAction : StateAction<PublishProtocolStateActionData, PublishProtocolStateActionResult>
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="PublishProtocolStateAction" />.
        /// </summary>
        public PublishProtocolStateAction(PublishProtocolStateActionData data)
            : base(data, nameof(PublishProtocolStateAction), DateTime.UtcNow)
        { }

        /// <summary>
        /// Инициализирует экземпляр <see cref="PublishProtocolStateAction" />.
        /// </summary>
        public PublishProtocolStateAction(PublishProtocolStateActionData data, string name, DateTime date)
            : base(data, name, date)
        { }
    }
}