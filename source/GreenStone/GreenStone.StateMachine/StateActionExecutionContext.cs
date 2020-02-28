namespace GreenStone.StateMachine
{
    using System;

    /// <summary>
    /// Контекст выполенния действия.
    /// </summary>
    public class StateActionExecutionContext<TSubject, TStateAction>
        where TSubject : class
        where TStateAction : class, IStateAction
    {
        /// <summary>
        /// Субъект.
        /// </summary>
        public TSubject Subject { get; }

        /// <summary>
        /// Выполняемое действие.
        /// </summary>
        public TStateAction Action { get; }

        /// <summary>
        /// Дата и время выполнения действия (UTC).
        /// </summary>
        public DateTime ActionDate => Action.Date;

        /// <summary>
        /// Наименование выполнеямого действия.
        /// </summary>
        public string ActionName => Action.Name;

        /// <summary>
        /// Инициализирует экземпляр.
        /// </summary>
        public StateActionExecutionContext(TSubject subject, TStateAction action)
        {
            Subject = subject ?? throw new ArgumentException(nameof(subject));
            Action = action ?? throw new ArgumentException(nameof(action));
        }
    }
}