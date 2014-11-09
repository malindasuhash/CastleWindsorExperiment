using Castle.Components.DictionaryAdapter.Xml;
using Castle.MicroKernel.Registration;
using System;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public static class BaseOnDescriptorExtension
    {
        public static BasedOnDescriptor RegisterForFeature<T>(this BasedOnDescriptor desc, RegistrationConfig<T> config, IWindsorContainer container)
        {
            desc.If(t =>
            {
                foreach (var registration in config.Registrations)
                {
                    var currentType = t.Name;

                    if ((registration.When == When.Enabled) || (registration.When == When.Disabled))
                    {
                        var registeredType = registration.Type.Name;

                        return registeredType.Equals(currentType);
                    }
                }

                return false;
            });

            return desc;

            #region Attemp to use ConfigureId

            // desc.ConfigureIf(component =>
           // {

           //     component.DependsOn(Dependency.OnComponent<IFeatureConfig, FeatureConfig>());
           //     var feature = container.Resolve<IFeatureConfig>();
           //     var enabled = feature.IsFeatureEnabled(featureKey);

           //     if (state == When.Enabled && enabled)
           //     {
           //         var implementTypeName = component.Implementation.Name;
           //         var registerTypeName = typeof(T).Name;
           //         var result = implementTypeName.Equals(registerTypeName);
           //         return result;
           //     }

           //     return false;
           // },
           //     registration => registration.LifestyleSingleton());
            //return desc;

            #endregion
        }
    }
}
