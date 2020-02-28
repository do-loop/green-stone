namespace GreenStone.StateMachine.Procedure.QuotationRequest.StateActions
{
    using System;

    /// <summary>
    /// Действие, выполняемое планировщиком.
    /// </summary>
    public sealed class SchedulerStateAction : StateAction
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="SchedulerStateAction" />.
        /// </summary>
        public SchedulerStateAction() : this(nameof(SchedulerStateAction), DateTime.UtcNow) { }

        /// <summary>
        /// Инициализирует экземпляр <see cref="SchedulerStateAction" />.
        /// </summary>
        public SchedulerStateAction(string name, DateTime date) : base(name, date) { }
    }
}