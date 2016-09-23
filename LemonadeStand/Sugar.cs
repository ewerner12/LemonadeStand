using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Sugar : Item
    {
        public int[] sugarToAdd;
        public double[] sugarPrices;

        public Sugar()
        {
            sugarToAdd = new int[] { 5, 10, 15 };
            sugarPrices = new double[] { 1.65, 3.31, 6.61 };
        }

    }
}
