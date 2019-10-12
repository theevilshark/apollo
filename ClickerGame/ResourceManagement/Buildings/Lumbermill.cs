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
        public int UpgradeCost => (Level + 1) * UpgradeCostGrowth;

        private double GrowthPerSecond => Level / 5d;

        public void Generate(double generationPeriod)
        {
            var generatedQuantity = GrowthPerSecond * generationPeriod;
            _resourceCache.Apply(generatedQuantity);
        }

        public void Upgrade()
        {
            if (!CanBeUpgraded)
                throw new UpgradeException("Insufficient resources");

            var upgradeCost = UpgradeCost;
            Level++;
            _resourceCache.Apply(upgradeCost * -1);
        }
    }
}
