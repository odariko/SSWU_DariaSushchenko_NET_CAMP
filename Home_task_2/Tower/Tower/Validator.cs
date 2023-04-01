using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Validator
    {
        public static bool LessThanZero(int value)
        {
            if (value < 0)
            {
                return true;
            }
            else return false;
        }

        public static bool LessThanHundred(int value)
        {
            if (value < 100)
            {
                return true;
            }
            else return false;
        }

        public static bool LessThanMaximum(int current, int maximum)
        {
            if (current < maximum)
            {
                return true;
            }
            else return false;
        }
    }
}

