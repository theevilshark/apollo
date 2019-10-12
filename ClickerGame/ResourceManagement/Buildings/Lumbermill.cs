using ResourceManagement.Exceptions;

namespace ResourceManagement.Buildings
{
    public class Lumbermill : IResourceGenerator
    {
        private const int UpgradeCostGrowth = 10;

        private readonly IResourceCache _resourceCache;

        public Lumbermill(IResourceCache resourceCache)
        {
            _resourceCache = resourceCache;
            Level = 0;
        }

        public int Level { get; private set; }

        public bool CanBeUpgraded => _resourceCache.Quantity >= UpgradeCost;

        private double GrowthPerSecond => Level / 5d;
        private int UpgradeCost => (Level + 1) * UpgradeCostGrowth;

        public void Generate(double generationPeriod)
        {
            var generatedQuantity = GrowthPerSecond * generationPeriod;
            _resourceCache.Apply(generatedQuantity);
        }

        public void Upgrade()
        {
            if (!CanBeUpgraded)
                throw new UpgradeException("Insufficient resources");

            _resourceCache.Apply(UpgradeCost * -1);
            Level++;
        }
    }
}
