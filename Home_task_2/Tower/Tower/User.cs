using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tower
{
    internal class User
    {// Де метод, який споживає воду.
        private int _consumption;
        private int _used;

        public int Consumption 
        { 
            get { return _consumption; } 
            set 
            {
                if(!Validator.LessThanZero(_consumption) && Validator.LessThanHundred(_consumption))
                {
                    _consumption = value;
                } 
            } 
        }

        public int Used
        {
            get { return _used; }
            set 
            {
                if (!Validator.LessThanZero(_used) && Validator.LessThanHundred(_used))
                {
                    _used = value;
                }
            }
        }

        public User() { }
        public User(int consumption, int used)
        {
            if (!Validator.LessThanZero(consumption) && !Validator.LessThanZero(used) 
                && Validator.LessThanHundred(consumption) && Validator.LessThanHundred(used))
            {
                _consumption = consumption;
                _used = used;
            }
        }

        public override string ToString()
        {
            return "User: " + Consumption + " " + Used; 
        }
    }
}
