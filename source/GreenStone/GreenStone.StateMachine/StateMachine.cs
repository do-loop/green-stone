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
        /// Дескриптор машины состояний.
        /// </summary>
        IStateMachineDescriptor<TSubject> Descriptor { get; }

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
        protected StateMachine(IEnumerable<IState<TSubject>> states, IStateMachineDescriptor<TSubject> descriptor)
        {
            States = states;
            Descriptor = descriptor;
        }

        /// <inheritdoc />
        public IStateMachineDescriptor<TSubject> Descriptor { get; }

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