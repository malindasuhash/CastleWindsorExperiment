using Castle.Components.DictionaryAdapter.Xml;
using Castle.MicroKernel.Registration;
using System;
using Castle.Windsor;

namespace CastleWindsorIoC
{
    public static class BaseOnDescriptorExtension
    {
        public static BasedOnDescriptor RegisterForFeature<T>(this BasedOnDescriptor desc, RegistrationConfig<T> config)
        {
            desc.If(t =>
            {
                foreach (var registration in config.Registrations)
                {
                    var registeredType = registration.WhenEnable != null ? registration.WhenEnable : registration.WhenDisabled;

                    desc.Configure(nameSetter => nameSetter.Named(registration.UseWith));

                    return registeredType.Equals(t);
                }

                return false;
            });


            return desc;
        }
    }
}
