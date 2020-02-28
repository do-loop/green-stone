namespace GreenStone.StateMachine
{
    /// <summary>
    /// Дескриптор машины состояний.
    /// </summary>
    public interface IStateMachineDescriptor<in TSubject> where TSubject : class
    {
        /// <summary>
        /// Проверяет и возвращает признак того, что машина состояний может быть выбрано для обработки.
        /// </summary>
        bool Selectable(TSubject subject);
    }

    /// <inheritdoc />
    public abstract class StateMachineDescriptor<TSubject> : IStateMachineDescriptor<TSubject> where TSubject : class
    {
        /// <inheritdoc />
        public abstract bool Selectable(TSubject subject);
    }
}