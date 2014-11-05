using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorIoC
{
    public static class BaseOnDescriptorExtension
    {
        public static BasedOnDescriptor WhenFeature<T>(this BasedOnDescriptor desc) where T : IFeatureConfig
        {
            return desc;
        }
    }
}
