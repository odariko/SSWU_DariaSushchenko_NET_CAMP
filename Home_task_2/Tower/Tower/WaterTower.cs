using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class WaterTower
    {
        private int _maxLevelWater;
        private int _currentLevel;
        private Pump _pump;

        public int MaxLevelWater
        {
            get { return _maxLevelWater; }
            set { _maxLevelWater = value; }
        }

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }

        public Pump Pump
        {
            get { return _pump; }
            set { _pump = value; }
        }

        public WaterTower() { }
        public WaterTower(int maxLevelWater, int currentLevel, Pump pump)
        {
            _maxLevelWater = maxLevelWater;
            _currentLevel = currentLevel;
            _pump = pump;
        }

        public override string ToString()
        {
            return "WaterTower: " + MaxLevelWater + " " + CurrentLevel + " " + Pump;
        }
    }
}
