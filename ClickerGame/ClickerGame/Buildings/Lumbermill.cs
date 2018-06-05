using System;

namespace ClickerGame.Buildings
{
    public class Lumbermill
    {
        private const Int32 UpgradeCostGrowth = 10;

        private Int32 _level;
        private Int32 _upgradeCost;

        public Lumbermill()
        {
            _level = 0;
            _upgradeCost = 10;
        }

        public Int32 ResourceGrowth => _level; // Per 5 seconds, this may change.
        public Int32 Level => _level;
        public Int32 UpgradeCost => _upgradeCost;

        public void Upgrade()
        {
            _level++;
            _upgradeCost = (_level + 1) * UpgradeCostGrowth;
        }
    }
}