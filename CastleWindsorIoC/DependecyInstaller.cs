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
            // In the parent container perhaps.
            container.Register(Component.For<IFeatureConfig>().ImplementedBy<FeatureConfig>());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<IAnimal>()
                .Record<Bat>()
                .WhenFeature(FeatureKey.BatFeatureEnabled)
                .IsEnabled()
                .Or<Bat>()
                .WhenDisabled()
                .If(f => {
                    var featureConfig = container.Resolve<IFeatureConfig>();
                    if (featureConfig.BatFeatureEnabled)
                    {
                        return f.Name.EndsWith("Bat");
                    }
                    return f.Name.EndsWith("Dog");
                })
                .WithServiceBase());

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
            
            container.Register(Classes.FromThisAssembly().BasedOn<Logger>());
        }
    }

    public class Config : IConfiguration
    {

        public ConfigurationAttributeCollection Attributes
        {
            get { throw new System.NotImplementedException(); }
        }

        public ConfigurationCollection Children
        {
            get { throw new System.NotImplementedException(); }
        }

        public object GetValue(System.Type type, object defaultValue)
        {
            throw new System.NotImplementedException();
        }

        public string Name
        {
            get { throw new System.NotImplementedException(); }
        }

        public string Value
        {
            get { throw new System.NotImplementedException(); }
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