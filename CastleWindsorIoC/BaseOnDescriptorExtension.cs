using Castle.MicroKernel.Registration;

namespace CastleWindsorIoC
{
    public static class BaseOnDescriptorExtension
    {
        public static BasedOnDescriptor RegisterForFeature(this BasedOnDescriptor desc, RegistrationConfig config)
        {
            desc.If(t =>
            {
                foreach (var registration in config.Registrations)
                {
                    var registeredType = registration.WhenEnable ?? registration.WhenDisabled;

                    desc.Configure(nameSetter => nameSetter.Named(registration.UseWith));

                    return registeredType == t;
                }

                return false;
            });


            return desc;
        }
    }
}
