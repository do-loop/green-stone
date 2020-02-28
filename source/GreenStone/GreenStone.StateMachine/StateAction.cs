namespace GreenStone.StateMachine
{
    using System;

    public interface IStateAction
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Дата и время выполнения (UTC).
        /// </summary>
        DateTime Date { get; }
    }

    /// <summary>
    /// Действие.
    /// </summary>
    public interface IStateAction<out TIn>
    {
        /// <summary>
        /// Данные для выполнения действия.
        /// </summary>
        TIn Data { get; }
    }

    /// <summary>
    /// Действие.
    /// </summary>
    public interface IStateAction<out TIn, out TOut> : IStateAction<TIn> where TOut: new()
    {
        /// <summary>
        /// Результат выполнения действия.
        /// </summary>
        TOut Result { get; }
    }

    /// <inheritdoc />
    public abstract class StateAction : IStateAction
    {
        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public DateTime Date { get; }

        /// <inheritdoc />
        protected StateAction(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }
    }

    /// <inheritdoc cref="StateAction" />
    public abstract class StateAction<TData> : StateAction, IStateAction<TData>
    {
        /// <inheritdoc />
        public TData Data { get; }

        /// <inheritdoc />
        protected StateAction(TData data, string name, DateTime date) : base(name, date)
        {
            Data = data;
        }
    }

    /// <inheritdoc cref="StateAction" />
    public abstract class StateAction<TData, TResult> : StateAction<TData>, IStateAction<TData, TResult> where TResult : new()
    {
        /// <inheritdoc />
        public TResult Result { get; } = new TResult();

        /// <inheritdoc />
        protected StateAction(TData data, string name, DateTime date) : base(data, name, date) { }
    }
}