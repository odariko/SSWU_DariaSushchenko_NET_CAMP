using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tower
{
    internal class User
    {
        private int _consumption;
        private int _used;

        public int Consumption 
        { 
            get { return _consumption; } 
            set { _consumption = value; } 
        }

        public int Used
        {
            get { return _used; }
            set { _used = value; }
        }

        public User() { }
        public User(int consumption, int used)
        {
            _consumption = consumption;
            _used = used;
        }

        public override string ToString()
        {
            return "User: " + Consumption + " " + Used; 
        }
    }
}
