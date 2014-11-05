namespace CastleWindsorIoC
{
    public interface IFeatureConfig
    {
        bool CatFeatureEnabled { get; }

        bool BatFeatureEnabled { get; }

        bool DogFeatureEnabled { get; } 
    }

    public class FeatureConfig : IFeatureConfig
    {
        public bool CatFeatureEnabled
        {
            get
            {
                return true;
            }
        }

        public bool BatFeatureEnabled
        {
            get
            {
                return false;
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