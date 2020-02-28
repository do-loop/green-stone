namespace GreenStone.StateMachine
{
    using System.Reflection;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Registration;

    /// <summary>
    /// Синтаксис для регистрации машины состояний.
    /// </summary>
    public sealed class StateMachineRegistrationSyntax<TSubject> where TSubject : class
    {
        private readonly Assembly[] _assemblies;
        private readonly IWindsorContainer _container;

        public StateMachineRegistrationSyntax(IWindsorContainer container, Assembly[] assemblies)
        {
            _container = container;
            _assemblies = assemblies;
        }

        /// <summary>
        /// Регестрирует состояние.
        /// </summary>
        public StateMachineRegistrationSyntax<TSubject> AddState<TState>() where TState : class, IState<TSubject>
        {
            _container.AddBasedOn(_assemblies, typeof(TState));
            _container.AddBasedOn(_assemblies, typeof(IStateDescriptor<TSubject, TState>));
            _container.AddBasedOn(_assemblies, typeof(IStateActionExecutor<TSubject, TState>));

            var registration = Component
                .For(typeof(IStateActionExecutionProvider<TSubject, TState>))
                .ImplementedBy(typeof(StateActionExecutionProvider<TSubject, TState>))
                .LifestyleTransient();

            _container.Register(registration);

            return this;
        }
    }
}