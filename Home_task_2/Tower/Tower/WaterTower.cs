using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class WaterTower
    {
        private int _maxLevel;
        private int _currentLevel;
        private Pump _pump;

        public int MaxLevelWater
        {
            get { return _maxLevel; }
            set 
            {
                if (!Validator.LessThanZero(_maxLevel) && Validator.LessThanHundred(_maxLevel))
                {
                    _maxLevel = value;
                }
            }
        }

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set 
            {
                if (!Validator.LessThanZero(_currentLevel) && Validator.LessThanHundred(_currentLevel) 
                    && Validator.LessThanMaximum(_currentLevel, _maxLevel))
                {
                    _currentLevel = value;
                }
            }
        }

        public Pump Pump
        {
            get { return _pump; }
            set { _pump = value; }
        }

        public WaterTower() { }
        public WaterTower(int maxLevel, int currentLevel, Pump pump)
        {
            if (!Validator.LessThanZero(currentLevel) && Validator.LessThanHundred(currentLevel)
                    && Validator.LessThanMaximum(currentLevel, maxLevel) && !Validator.LessThanZero(maxLevel) 
                    && Validator.LessThanHundred(maxLevel))
            {
                _maxLevel = maxLevel;
                _currentLevel = currentLevel;
                _pump = pump;
            }
        }

        public override string ToString()
        {
            return "WaterTower: " + MaxLevelWater + " " + CurrentLevel + " " + Pump;
        }
    }
}
