namespace GreenStone.StateMachine.Procedure.Models
{
    /// <summary>
    /// Процедура.
    /// </summary>
    public sealed class Procedure
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; } = 777;

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; } = nameof(Procedure);

        /// <summary>
        /// Состояния процедуры.
        /// </summary>
        public ProcedureStateEnum State { get; set; }

        /// <summary>
        /// Тип процедуры.
        /// </summary>
        public ProcedureType Type { get; set; } = ProcedureType.QuotationRequest;
    }
}