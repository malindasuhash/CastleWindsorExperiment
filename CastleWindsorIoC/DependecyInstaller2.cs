using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public class DependecyInstaller2 : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // basic registrations
            container.Register(Component.For<ILogger>().ImplementedBy<Logger>().LifestyleSingleton());

            container.Register(Component.For<IFeatureConfig>().ImplementedBy<FeatureConfig>().LifestyleSingleton());
            
            // Register only when the feature is enabled.
            container.Register(Component.For<IAnimal>()
                .RegisterWhen(typeof(Bat), FeatureKey.BatFeature, When.Enabled, container)
                .LifestyleSingleton());
        }

        public enum When
        {
            Enabled = 1,    
            Disabled 
        }
    }

    public class Installer2
    {
        public IWindsorContainer Install()
        {
            var container = new WindsorContainer();
            container.Install(new DependecyInstaller2());

            return container;
        }
    }
}