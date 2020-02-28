namespace GreenStone.StateMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Состояние.
    /// </summary>
    public interface IState<in TSubject> where TSubject: class
    {
        /// <summary>
        /// Дескриптор состояния.
        /// </summary>
        IStateDescriptor<TSubject> Descriptor { get; }

        /// <summary>
        /// Выполняет указанное действие.
        /// </summary>
        void Execute(TSubject subject, IStateAction action);
    }

    /// <inheritdoc />
    public abstract class State<TSubject, TState> : IState<TSubject>
        where TSubject : class
        where TState : class, IState<TSubject>
    {
        protected readonly IReadOnlyCollection<Type> AvailableActionTypesForExecute;
        protected readonly IStateActionExecutionProvider<TSubject, TState> Provider;

        /// <inheritdoc />
        protected State(IStateDescriptor<TSubject> descriptor, IStateActionExecutionProvider<TSubject, TState> provider)
        {
            Provider = provider;
            Descriptor = descriptor;
            AvailableActionTypesForExecute = typeof(TState).GetCustomAttributes<StateActionAttribute>()
                .Select(x => x.Type)
                .ToArray();
        }

        /// <inheritdoc />
        public IStateDescriptor<TSubject> Descriptor { get; }

        /// <inheritdoc />
        public void Execute(TSubject subject, IStateAction action)
        {
            _ = subject ?? throw new ArgumentException(nameof(subject));
            _ = action ?? throw new ArgumentNullException(nameof(action));

            if (AvailableActionTypesForExecute.Contains(action.GetType()) == false)
                throw new StateMachineException("Выполнение действия не разрешено.");

            Provider.GetExecutor(action).ExecuteAction(subject, action);
        }
    }
}