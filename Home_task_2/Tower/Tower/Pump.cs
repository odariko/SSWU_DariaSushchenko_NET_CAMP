using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Pump
    {
        private int _power;
        private bool isOn = false;

        public bool IsOn
        {
            set { isOn = value; }
            get { return isOn; }
        }
        public int Power
        {
            set 
            { 
                if (!Validator.LessThanZero(_power) && Validator.LessThanHundred(_power))
                {
                    _power = value;
                }  
            }
            get { return _power; }
        }

        public Pump() { }
        public Pump(int power)
        {
            if (!Validator.LessThanZero(power) && Validator.LessThanHundred(power))
            {
                _power = power;
            }
        }

        public override string ToString()
        {
            return "WaterTower: " + Power + " " + IsOn;
        }
    }
}
