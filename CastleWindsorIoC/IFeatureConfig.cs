namespace CastleWindsorIoC
{
    public interface IFeatureConfig
    {
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