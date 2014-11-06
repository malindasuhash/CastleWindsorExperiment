using System.Runtime.InteropServices.ComTypes;
using Castle.Core.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public class DependecyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Somewhere in the container.
            container.Register(Component.For<IFeatureConfig>().ImplementedBy<FeatureConfig>());

            container.Register(Component.For<ILogger>()
                .ImplementedBy<Logger>()
                .LifestyleSingleton());

            container.Register(Classes
                .FromThisAssembly()
                .BasedOn<IAnimal>()
                .RegisterForFeature<Bat>(FeatureKey.BatFeature, When.Enabled, container)
                .WithService.AllInterfaces()
                .LifestyleSingleton());

            //container.Register(Classes.FromThisAssembly()
            //    .BasedOn<IAnimal>()
            //    .RegisterForFeature<Bat>(FeatureKey.BatFeature, When.Enabled, container)
            //    .RegisterForFeature<Cat>(FeatureKey.BatFeature, When.Disabled, container)
            //    .ConfigureIf(f => { f.DependsOn(Dependency.OnComponent<IFeatureConfig, FeatureConfig>());
            //                          return true;
            //    }, registration => { })
            //    .If(f => {
            //        var featureConfig = container.Resolve<IFeatureConfig>();
            //        if (featureConfig.BatFeatureEnabled)
            //        {
            //            return f.Name.EndsWith("Bat");
            //        }
            //        return f.Name.EndsWith("Dog");
            //    })
            //    .WithServiceBase());

            //container.Register(Component.For<IAnimal>()
            //    .ImplementedBy<Bat>()
            //    .DependsOn(Property.));

            //container.Register(Classes.FromThisAssembly()
            //    .BasedOn<IAnimal>().ConfigureIf( c => 
            //        {
            //            c.DependsOn(Dependency.OnComponent<IFeatureConfig, FeatureConfig>());
            //            c.ImplementedBy<Dog>();
            //            return true; 
            //        }
            //    , registration => { }));

            // Register each individually
            //container.Register(Component.For<IAnimal>().ImplementedBy<Bat>());
            //container.Register(Component.For<IAnimal>().ImplementedBy<Cat>());
            //container.Register(Component.For<IAnimal>().ImplementedBy<Dog>());

            // Register all in one go 
            // container.Register(Classes.FromThisAssembly().BasedOn<IAnimal>().WithService.FromInterface());

            
        }
    }

    public enum When
    {
        Enabled = 1,

        Disabled = 0
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