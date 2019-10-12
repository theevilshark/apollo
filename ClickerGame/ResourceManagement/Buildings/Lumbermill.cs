using ResourceManagement.Exceptions;

namespace ResourceManagement.Buildings
{
    public class Lumbermill : IResourceGenerator
    {
        private const int UpgradeCostGrowth = 10;

        private readonly ResourceAdjustmentFactory _adjustmentFactory;
        private readonly IResourceCache _resourceCache;

        public Lumbermill(IResourceCache resourceCache, ResourceAdjustmentFactory adjustmentFactory)
        {
            _adjustmentFactory = adjustmentFactory;
            _resourceCache = resourceCache;
            Level = 0;
        }

        public int Level { get; private set; }

        public bool CanBeUpgraded => _resourceCache.Quantity >= UpgradeCost;
        public int UpgradeCost => (Level + 1) * UpgradeCostGrowth;

        private double GrowthPerSecond => Level / 5d;

        public void Generate(double generationPeriod)
        {
            var adjustment = _adjustmentFactory.CreateIncreaseEqualTo(GrowthPerSecond * generationPeriod);
            _resourceCache.Apply(adjustment);
        }

        public void Upgrade()
        {
            if (!CanBeUpgraded)
                throw new UpgradeException("Insufficient resources");

            var adjustment = _adjustmentFactory.CreateDecreaseEqualTo(UpgradeCost);
            // For now ensure level is adjusted before the resource cache is updated
            // to keep the UI responsive as updates only trigger off the back of resource
            // updates currently.
            Level++;
            _resourceCache.Apply(adjustment);
        }
    }
}
