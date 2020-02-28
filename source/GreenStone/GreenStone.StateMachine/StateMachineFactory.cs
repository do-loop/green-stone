namespace GreenStone.StateMachine
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Фабрика машин состояний.
    /// </summary>
    public interface IStateMachineFactory<in TSubject> where TSubject : class
    {
        /// <summary>
        /// Создает машину состояний для указанного субъекта.
        /// </summary>
        IStateMachine<TSubject> Create(TSubject subject);
    }

    /// <inheritdoc />
    public abstract class StateMachineFactory<TSubject> : IStateMachineFactory<TSubject> where TSubject : class
    {
        private readonly IEnumerable<IStateMachine<TSubject>> _machines;

        /// <inheritdoc />
        protected StateMachineFactory(IEnumerable<IStateMachine<TSubject>> machines)
        {
            _machines = machines;
        }

        /// <inheritdoc />
        public IStateMachine<TSubject> Create(TSubject subject)
        {
            var machines = _machines
                .Where(x => x.Descriptor.Selectable(subject))
                .ToArray();

            if (machines.Length == 0 || machines.Length > 1)
                throw new StateMachineException("Не удалось получить машину состояний.");

            return machines.First();
        }
    }
}