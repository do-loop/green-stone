namespace GreenStone.StateMachine.Registration
{
    using System;
    using System.Reflection;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;

    /// <summary>
    /// Методы расширения для <see cref="IWindsorContainer" />.
    /// </summary>
    public static class WindsorContainerExtensions
    {
        /// <summary>
        /// Добавляет машину состояний в <see cref="IWindsorContainer" />.
        /// </summary>
        public static StateMachineRegistrationSyntax<TSubject> AddStateMachine<TSubject>(this IWindsorContainer container, Assembly[] assemblies) where TSubject : class
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddBasedOn(assemblies, typeof(IState<TSubject>));
            container.AddBasedOn(assemblies, typeof(IStateMachine<TSubject>));

            return new StateMachineRegistrationSyntax<TSubject>(container, assemblies);
        }

        public static void AddBasedOn(this IWindsorContainer container, Assembly[] assemblies, Type type)
        {
            if (container.Kernel.HasComponent(type))
                return;

            foreach (var assembly in assemblies)
            {
                var registration = Classes.FromAssembly(assembly)
                    .BasedOn(type).WithService.FromInterface()
                    .LifestyleTransient();

                container.Register(registration);
            }
        }
    }
}