namespace GreenStone.StateMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Провайдер для средств выполнения действий.
    /// </summary>
    public interface IStateActionExecutionProvider<in TSubject, TState>
        where TSubject: class
        where TState: class, IState<TSubject>
    {
        /// <summary>
        /// Возвращает средство для выполнения действия.
        /// </summary>
        /// <typeparam name="TStateAction">Тип действия.</typeparam>
        /// <param name="action">Действие.</param>
        /// <returns>Средство для выполнения действия.</returns>
        IStateActionExecutor<TSubject, TState> GetExecutor<TStateAction>(TStateAction action)
            where TStateAction : class, IStateAction;
    }

    /// <inheritdoc />
    public sealed class StateActionExecutionProvider<TSubject, TState> : IStateActionExecutionProvider<TSubject, TState>
        where TSubject : class
        where TState : class, IState<TSubject>
    {
        private readonly IEnumerable<IStateActionExecutor<TSubject, TState>> _executors;

        /// <inheritdoc />
        public StateActionExecutionProvider(IEnumerable<IStateActionExecutor<TSubject, TState>> executors)
        {
            _executors = executors;
        }

        /// <inheritdoc />
        public IStateActionExecutor<TSubject, TState> GetExecutor<TStateAction>(TStateAction action) where TStateAction : class, IStateAction
        {
            var type = action.GetType();

            return _executors.FirstOrDefault(x => x.StateType == typeof(TState) && x.ActionType == type) ??
                throw new Exception($"Не удалось получить средство для выполения действия {type.Name} в состоянии {typeof(TState).Name}.");
        }
    }
}