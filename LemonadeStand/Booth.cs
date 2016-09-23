using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Booth
    {
        public bool isBoothOpen;
        public Pitcher pitcher;

        public Booth()
        {
            isBoothOpen = false;
            pitcher = new Pitcher();
        }

        public bool GetBoothStatus()
        {
            return isBoothOpen;
        }

        public void OpenBooth()
        {
            isBoothOpen = true;
            //Console.WriteLine("\nNow OPEN for business!");
        }

        public void CloseBooth()
        {
            isBoothOpen = false;
            Console.WriteLine("\nBooth is now CLOSED for the day!");
        }

        public void OpenForBidness(Day day, Player player)
        {
            while (isBoothOpen)
            {
                foreach (Customer customer in day.customerList)
                {
                    while ((!player.inventory.CheckCupInventory()) && 
                        (!player.inventory.CheckRecipeIngredientsInventory(pitcher.recipe)))
                    {
                        customer.GaugeInterest(day.weather.todayTemp);
                        customer.DetermineIfThirstyOrNot();
                        customer.BuyLemonadeIfThirsty(pitcher, player);
                    }
                    break;
                }
                CloseBooth();
            }
        }


        // pass in customerList and pitcher>glass
        // have method to actually sell glass of lemonade to customer
        // decrement glass of lemonade from pitcher
        // add money to wallet
    }
}
