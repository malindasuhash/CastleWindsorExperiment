using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;

namespace CastleWindsorIoC
{
    public class DependecyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Get current configuration = Web serivce call or somewhere perhaps.
            var currentConfig = new RegistrationConfig();

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
                .WithService.Base()
                .LifestyleSingleton());
        }
    }

    public class Registration
    {
        public Type WhenEnable { get; set; }

        public Type WhenDisabled { get; set; }

        public FeatureKey Key { get; set; }

        public string UseWith { get; set; } 
    }

    public class RegistrationConfig
    {
        public IEnumerable<Registration> Registrations
        {
            get
            {
                yield return new Registration() 
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