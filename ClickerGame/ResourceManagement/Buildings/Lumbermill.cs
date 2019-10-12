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
            UpgradeCost = 10;
        }

        public int Level { get; private set; }
        public int UpgradeCost { get; private set; }

        public void Generate(double generationPeriod)
        {
            var generatedQuantity = Level / generationPeriod;
            _resourceCache.Apply(generatedQuantity);
        }

        public void Upgrade()
        {
            Level++;
            UpgradeCost = (Level + 1) * UpgradeCostGrowth;
            _resourceCache.Apply(UpgradeCost * -1);
        }
    }
}
