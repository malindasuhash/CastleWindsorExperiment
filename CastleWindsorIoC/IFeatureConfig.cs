namespace CastleWindsorIoC
{
    public interface IFeatureConfig
    {
        bool CatFeatureEnabled { get; }

        bool BatFeatureEnabled { get; }

        bool DogFeatureEnabled { get; } 
    }

    public enum FeatureKey
    {
        CatFeatureEnabled,

        BatFeatureEnabled,

        DogFeatureEnabled
    }

    public class FeatureConfig : IFeatureConfig
    {
        public bool CatFeatureEnabled
        {
            get
            {
                return false;
            }
        }

        public bool BatFeatureEnabled
        {
            get
            {
                return true;
            }
        }

        public bool DogFeatureEnabled
        {
            get
            {
                return false;
            }
        }
    }
}