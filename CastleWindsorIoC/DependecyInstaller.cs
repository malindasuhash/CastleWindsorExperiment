using System.Runtime.InteropServices.ComTypes;
using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CastleWindsorIoC
{
    public class DependecyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Get current configuration = Web serivce call or somewhere perhaps.
            var currentConfig = new RegistrationConfig<IAnimal>();

            // Somewhere in the container.
            container.Register(Component.For<IFeatureConfig>()
                .ImplementedBy<FeatureConfig>()
                .LifestyleSingleton());

            container.Register(Component.For<ILogger>()
                .DependsOn(Dependency.OnComponent(typeof(IAnimal), "Logger"))
                .ImplementedBy<Logger>()
                .LifestyleSingleton());

            // Register the types based on the configuration.
            container.Register(Classes
                .FromThisAssembly()
                .BasedOn<IAnimal>()
                .RegisterForFeature<IAnimal>(currentConfig)
                .WithService.AllInterfaces()
                .LifestyleSingleton());
        }
    }

    public class Registration<T>
    {
        public Type WhenEnable { get; set; }

        public Type WhenDisabled { get; set; }

        public FeatureKey Key { get; set; }

        public string UseWith { get; set; } 
    }

    public class RegistrationConfig<T>
    {
        public IEnumerable<Registration<T>> Registrations
        {
            get
            {
                yield return new Registration<T>() 
                {  
                    WhenEnable = typeof(Bat), 
                    WhenDisabled = typeof(Cat), 
                    Key = FeatureKey.BatFeature,
                    UseWith = "Logger" // Use the the types defined here to resolve Logger.
                };
            }
        }
    }

    public class Installer
    {
        public IWindsorContainer Install()
        {
            var container = new WindsorContainer();
            container.Install(new DependecyInstaller());

            return container;
        }
    }
}