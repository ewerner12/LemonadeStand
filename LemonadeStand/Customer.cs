using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        bool isThirsty;
        double willingnessToPay;

        public Customer(Random random)
        {
            isThirsty = true;
            willingnessToPay = random.Next(40, 70);
        }

        public void GaugeInterest(int todayTemp)
        {
            if (todayTemp > 90)
            {
                willingnessToPay *= 2.5;
            }
            else if ((todayTemp > 80) && (todayTemp <= 90))
            {
                willingnessToPay *= 2.1;
            }
            else if ((todayTemp > 70) && (todayTemp <= 80))
            {
                willingnessToPay *= 1.5;
            }
            else if ((todayTemp > 60) && (todayTemp <= 70))
            {
                willingnessToPay *= 1.0;
            }
            else if ((todayTemp > 50) && (todayTemp <= 60))
            {
                willingnessToPay *= 0.88;
            }
            else if ((todayTemp > 40) && (todayTemp <= 50))
            {
                willingnessToPay *= 0.77;
            }
            else if ((todayTemp > 30) && (todayTemp <= 40))
            {
                willingnessToPay *= 0.66;
            }
            else if (todayTemp <= 30)
            {
                willingnessToPay *= 0.55;
            }
        }

        public bool DetermineIfThirstyOrNot()
        {
            if(willingnessToPay < 51)
            {
                isThirsty = false;
            }
            return isThirsty;
        }

        public void BuyLemonadeIfThirsty(Pitcher pitcher, Player player)
        {
            player.wallet.cash += player.inventory.pricePerGlass;
            player.inventory.AddSaleToDailyProfit();
            pitcher.RemoveGlassOfLemonadeFromPitcher(player.inventory);
            pitcher.AddCupToDailySalesTotal();
        }


    }
}
