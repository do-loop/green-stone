namespace GreenStone.StateMachine.Procedure.Models
{
    /// <summary>
    /// Состояния процедуры.
    /// </summary>
    public enum ProcedureStateEnum
    {
        /// <summary>
        /// Прием заявок.
        /// </summary>
        ApplicationReception,

        /// <summary>
        /// Рассмотрение заявок.
        /// </summary>
        ApplicationConsideration,

        /// <summary>
        /// Определение победителя среди заявок.
        /// </summary>
        ApplicationWinnerDetermination,

        /// <summary>
        /// Заключение контракта.
        /// </summary>
        ContractConclusion,
    }
}