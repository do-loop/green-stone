namespace GreenStone.StateMachine.Application.Models
{
    /// <summary>
    /// Заявка на участие.
    /// </summary>
    public sealed class Application
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; } = 777;

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; } = nameof(Application);

        /// <summary>
        /// Состояния.
        /// </summary>
        public ApplicationStateEnum State { get; set; }
    }
}