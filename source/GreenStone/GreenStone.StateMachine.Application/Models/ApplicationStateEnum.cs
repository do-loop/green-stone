namespace GreenStone.StateMachine.Application.Models
{
    /// <summary>
    /// Состояния заявки на участие.
    /// </summary>
    public enum ApplicationStateEnum
    {
        /// <summary>
        /// Подана.
        /// </summary>
        Submitted,

        /// <summary>
        /// Отклонена.
        /// </summary>
        Rejected,

        /// <summary>
        /// Одобрена.
        /// </summary>
        Approved
    }
}