namespace GreenStone.StateMachine.Application.QuotationRequest.StateActions
{
    using System;

    /// <summary>
    /// Действие одобрения заявки на участие.
    /// </summary>
    public sealed class ApproveStateAction : StateAction
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="ApproveStateAction" />.
        /// </summary>
        public ApproveStateAction() : this(nameof(ApproveStateAction), DateTime.UtcNow) { }

        /// <summary>
        /// Инициализирует экземпляр <see cref="ApproveStateAction" />.
        /// </summary>
        public ApproveStateAction(string name, DateTime date) : base(name, date) { }
    }
}