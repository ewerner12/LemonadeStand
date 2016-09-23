using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : Item
    {
        public int[] iceToAdd;
        public double[] icePrices;

        public Ice()
        {
            iceToAdd = new int[] { 20, 40, 60 };
            icePrices = new double[] { 0.21, 0.41, 0.61 };
        }

    }
}
