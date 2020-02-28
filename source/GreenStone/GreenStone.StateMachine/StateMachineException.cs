namespace GreenStone.StateMachine
{
    using System;

    /// <summary>
    /// Исключение, выбрасываемое при исключительной ситуации в ходе работы машины состояний.
    /// </summary>
    public sealed class StateMachineException : Exception
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="StateMachineException" />.
        /// </summary>
        public StateMachineException() { }

        /// <summary>
        /// Инициализирует экземпляр <see cref="StateMachineException" />.
        /// </summary>
        public StateMachineException(string message) : base(message) { }

        /// <summary>
        /// Инициализирует экземпляр <see cref="StateMachineException" />.
        /// </summary>
        public StateMachineException(string message, Exception inner) : base(message, inner) { }
    }
}