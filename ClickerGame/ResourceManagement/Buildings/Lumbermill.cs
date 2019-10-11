namespace ResourceManagement.Buildings
{
    public class Lumbermill : IResourceGenerator
    {
        private const int UpgradeCostGrowth = 10;

        public Lumbermill()
        {
            Level = 0;
            UpgradeCost = 10;
        }

        public int Level { get; private set; }
        public int UpgradeCost { get; private set; }

        public double Generate(double generationPeriod)
        {
            return Level / generationPeriod;
        }

        public void Upgrade()
        {
            Level++;
            UpgradeCost = (Level + 1) * UpgradeCostGrowth;
        }
    }
}
