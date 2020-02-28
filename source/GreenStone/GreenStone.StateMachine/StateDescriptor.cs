namespace GreenStone.StateMachine
{
    /// <summary>
    /// Дескриптор состояния.
    /// </summary>
    public interface IStateDescriptor<in TSubject> where TSubject : class
    {
        /// <summary>
        /// Проверяет и возвращает признак того, что состояние может быть выбрано для обработки.
        /// </summary>
        bool Selectable(TSubject subject);
    }

    /// <summary>
    /// Дескриптор состояния.
    /// </summary>
    public interface IStateDescriptor<in TSubject, TState> : IStateDescriptor<TSubject>
        where TSubject : class
        where TState : class, IState<TSubject>
    { }

    /// <inheritdoc />
    public abstract class StateDescriptor<TSubject, TState> : IStateDescriptor<TSubject, TState>
        where TSubject : class
        where TState : class, IState<TSubject>
    {
        /// <inheritdoc />
        public abstract bool Selectable(TSubject subject);
    }
}