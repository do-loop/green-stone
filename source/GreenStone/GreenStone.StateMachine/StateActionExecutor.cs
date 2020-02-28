namespace GreenStone.StateMachine
{
    using System;

    /// <summary>
    /// Средство для выполнения действия.
    /// </summary>
    public interface IStateActionExecutor<in TSubject, TState>
        where TSubject: class
        where TState : class, IState<TSubject>
    {
        /// <summary>
        /// Тип состояния.
        /// </summary>
        Type StateType { get; }

        /// <summary>
        /// Тип события.
        /// </summary>
        Type ActionType { get; }

        /// <summary>
        /// Выполняет указанное действие над субъектом.
        /// </summary>
        void ExecuteAction(TSubject subject, object action);
    }

    /// <summary>
    /// Средство для выполнения действия.
    /// </summary>
    public interface IStateActionExecutor<in TSubject, TState, in TStateAction> : IStateActionExecutor<TSubject, TState>
        where TSubject: class
        where TState : class, IState<TSubject>
        where TStateAction : class, IStateAction
    {
        /// <summary>
        /// Выполняет указанное действие над субъектом.
        /// </summary>
        void ExecuteAction(TSubject subject, TStateAction action);
    }

    /// <inheritdoc />
    public abstract class StateActionExecutor<TSubject, TState, TStateAction> : IStateActionExecutor<TSubject, TState, TStateAction>
        where TSubject: class
        where TState : class, IState<TSubject>
        where TStateAction : class, IStateAction
    {
        /// <inheritdoc />
        public Type StateType => typeof(TState);

        /// <inheritdoc />
        public Type ActionType => typeof(TStateAction);

        /// <summary>
        /// Контекст выполенния действия.
        /// </summary>
        protected StateActionExecutionContext<TSubject, TStateAction> ExecutionContext { get; private set; }

        /// <inheritdoc />
        public void ExecuteAction(TSubject subject, object action)
        {
            ExecuteAction(subject, (TStateAction) action);
        }

        /// <inheritdoc />
        public void ExecuteAction(TSubject subject, TStateAction action)
        {
            ExecutionContext = new StateActionExecutionContext<TSubject, TStateAction>(subject, action);

            try
            {
                BeforeExecute();
                Execute();
                AfterExecute();
            }
            catch (Exception exception)
            {
                OnException(exception);
                throw;
            }
        }

        /// <summary>
        /// Выполняет некоторые действия (до основого).
        /// </summary>
        protected virtual void BeforeExecute() { }

        /// <summary>
        /// Выполняет некоторые действия (основное).
        /// </summary>
        protected virtual void Execute() { }

        /// <summary>
        /// Выполняет некоторые действия (после основного).
        /// </summary>
        protected virtual void AfterExecute() { }

        /// <summary>
        /// Выполняет некоторые действия, если возникло исключения.
        /// </summary>
        protected virtual void OnException(Exception exception) { }
    }
}