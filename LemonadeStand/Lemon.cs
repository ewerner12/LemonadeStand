using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Item
    {
        public int[] lemonsToAdd;
        public double[] lemonPrices;

        public Lemon()
        {
            lemonsToAdd = new int[] { 10, 20, 30 };
            lemonPrices = new double[] { 3.35, 6.71, 13.41 };
        }

    }
}
