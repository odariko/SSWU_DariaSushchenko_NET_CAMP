using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Simulator
    {
        private Pump _pump;
        private WaterTower _waterTower;
        private User _user;

        public Pump Pump 
        { 
            get { return _pump; } 
            set { _pump = value; }
        }  
        public  WaterTower WaterTower 
        { 
            get { return _waterTower; }
            set { _waterTower = value; }
        }
        public User User 
        { 
            get { return _user; } 
            set 
            {
                if (Validator.LessThanMaximum(_user.Consumption, _waterTower.MaxLevelWater))
                {
                    _user = value;
                }
            }
        }
// ось такого точно не треба. Краще, щоб сам симулятор створював ці об'єкти, а не вони приходили ззовні.
        public Simulator() { }
        public Simulator(Pump pump, WaterTower waterTower, User user)
        {
            if (Validator.LessThanMaximum(user.Consumption, waterTower.MaxLevelWater))
            {
                _pump = pump;
                _waterTower = waterTower;
                _user = user;
            }
        }

        public override string ToString()
        {
            return "User: " + Pump + " " + WaterTower + " " + User;
        }
    }
}
