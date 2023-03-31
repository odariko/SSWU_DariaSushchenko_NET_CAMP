using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Pump
    {
        private double _power;
        private bool isOn = false;

        public bool IsOn
        {
            set { isOn = value; }
            get { return isOn; }
        }
        public double Power
        {
            set { _power = value; }
            get { return _power; }
        }

        public Pump() { }
        public Pump(double power)
        {
            _power = power;
        }

        public override string ToString()
        {
            return "WaterTower: " + Power + " " + IsOn;
        }
    }
}
