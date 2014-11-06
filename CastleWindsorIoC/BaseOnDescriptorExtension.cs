using Castle.Components.DictionaryAdapter.Xml;
using Castle.MicroKernel.Registration;
using System;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public static class BaseOnDescriptorExtension
    {
        public static BasedOnDescriptor RegisterForFeature<T>(this BasedOnDescriptor desc, FeatureKey featureKey, When state, IWindsorContainer container)
        {
            desc.ConfigureIf(component =>
            {

                component.DependsOn(Dependency.OnComponent<IFeatureConfig, FeatureConfig>());
                var feature = container.Resolve<IFeatureConfig>();
                var enabled = feature.IsFeatureEnabled(featureKey);

                if (state == When.Enabled && enabled)
                {
                    var implementTypeName = component.Implementation.Name;
                    var registerTypeName = typeof(T).Name;
                    var result = implementTypeName.Equals(registerTypeName);
                    return result;
                }

                return false;
            },
                registration => registration.LifestyleSingleton());
           return desc;
        }
    }
}
