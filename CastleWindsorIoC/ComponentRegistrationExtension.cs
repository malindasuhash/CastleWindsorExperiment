using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public static class ComponentRegistrationExtension
    {
        public static ComponentRegistration<T> RegisterWhen<T>(this ComponentRegistration<T> cr, Type givenType, FeatureKey featureKey, DependecyInstaller2.When when, IWindsorContainer container) where T : class
        {
            cr.DependsOn(Dependency.OnComponent<IFeatureConfig, FeatureConfig>());

            var feature = container.Resolve<IFeatureConfig>();

            var result = feature.IsFeatureEnabled(featureKey);

            if (when == DependecyInstaller2.When.Enabled && result)
            {
                cr.ImplementedBy(givenType);
            }

            if (when == DependecyInstaller2.When.Disabled && !result)
            {
                cr.ImplementedBy(givenType);
            }

            return cr;
        }
    }
}