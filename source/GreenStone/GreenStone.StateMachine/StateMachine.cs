namespace GreenStone.StateMachine
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Машина состояний.
    /// </summary>
    public interface IStateMachine<in TSubject> where TSubject : class
    {
        /// <summary>
        /// Выполняет указанное действие.
        /// </summary>
        IStateMachine<TSubject> Execute(TSubject subject, IStateAction action);
    }

    /// <inheritdoc />
    public abstract class StateMachine<TSubject> : IStateMachine<TSubject> where TSubject : class
    {
        protected readonly IEnumerable<IState<TSubject>> States;

        /// <inheritdoc />
        protected StateMachine(IEnumerable<IState<TSubject>> states)
        {
            States = states;
        }

        /// <inheritdoc />
        public IStateMachine<TSubject> Execute(TSubject subject, IStateAction action)
        {
            var states = States
                .Where(x => x.Descriptor.Selectable(subject))
                .ToArray();

            if (states.Length == 0 || states.Length > 1)
                throw new StateMachineException("Не удалось получить состояние.");

            states.First().Execute(subject, action);

            return this;
        }
    }
}