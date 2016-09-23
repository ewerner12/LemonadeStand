using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Wallet
    {
        public double cash;
        public bool hasEnoughCash;

        public Wallet()
        {
            cash = 40.00;
            hasEnoughCash = true;
        }

        public void MakePurchase(double cost)
        {
            cash -= cost;
        }

        public double GetCashOnHand()
        {
            return cash;
        }

        public void SubtractPurchase(double[] itemPrices, int menuOut)
        {
            if ((cash - itemPrices[menuOut - 1]) > 0)
            {
                hasEnoughCash = true;
                cash -= itemPrices[menuOut - 1];
            }
            else
            {
                hasEnoughCash = false;
                Console.WriteLine("\nInsufficient funds! Make more money first!");
            }
        }

        public bool CheckWalletForSufficientFunds()
        {
            return hasEnoughCash;
        }

    }
}
