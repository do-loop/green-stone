namespace GreenStone.StateMachine
{
    using System;

    /// <summary>
    /// Атрибут, определяющий поддержку состоянием указанного типа действия.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class StateActionAttribute : Attribute
    {
        /// <summary>
        /// Тип действия.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="StateActionAttribute" />.
        /// </summary>
        /// <param name="type">Тип действия.</param>
        public StateActionAttribute(Type type) => Type = type;
    }
}