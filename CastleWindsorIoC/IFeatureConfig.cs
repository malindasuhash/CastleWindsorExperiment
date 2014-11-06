namespace CastleWindsorIoC
{
    public interface IFeatureConfig
    {
        bool CatFeatureEnabled { get; }

        bool BatFeatureEnabled { get; }

        bool DogFeatureEnabled { get; }

        bool IsFeatureEnabled(FeatureKey featureKey);
    }

    public enum FeatureKey
    {
        CatFeature,

        BatFeature,

        DogFeature
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

        public bool IsFeatureEnabled(FeatureKey featureKey)
        {
            switch (featureKey)
            {
                case FeatureKey.BatFeature:
                    return true;

                case FeatureKey.DogFeature:
                    return false;

                case FeatureKey.CatFeature:
                    return false;

                default:
                    return false;
            }
        }
    }
}