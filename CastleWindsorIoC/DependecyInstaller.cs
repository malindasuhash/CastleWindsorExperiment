using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public class DependecyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // In the parent container perhaps.
            container.Register(Component.For<IFeatureConfig>().ImplementedBy<FeatureConfig>());

            container.Register(Classes.FromThisAssembly().BasedOn<IAnimal>().ConfigureIf( c => true, registration => { }));

            // Register each individually
            //container.Register(Component.For<IAnimal>().ImplementedBy<Bat>());
            //container.Register(Component.For<IAnimal>().ImplementedBy<Cat>());
            //container.Register(Component.For<IAnimal>().ImplementedBy<Dog>());

            // Register all in one go 
            // container.Register(Classes.FromThisAssembly().BasedOn<IAnimal>().WithService.FromInterface());
            
            container.Register(Classes.FromThisAssembly().BasedOn<Logger>());
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