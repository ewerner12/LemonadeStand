using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Cup : Item
    {
        public int[] cupsToAdd;
        public double[] cupPrices;

        public Cup()
        {
            cupsToAdd = new int[] { 5, 10, 20 };
            cupPrices = new double[] { 0.35, 0.71, 1.41 };
        }

    }
}
