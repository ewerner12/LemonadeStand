using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        private int dayCounter;
        private bool status;
        public List<Customer> customerList;
        public Weather weather;

        public Day(Random random)
        {
            dayCounter = 1;
            status = true;
            weather = new Weather();
            customerList = new List<Customer>();

            for (int i = 0; i < 20; i++)
            {
                Customer customer = new Customer(random);
                customerList.Add(customer);
            }
        }

        public int GetDay()
        {
            return dayCounter;
        }

        public void IsOver()
        {
            status = false;
        }

        public bool IsCurrent()
        {
            return status;
        }

        public void NextDay(Booth lemonadeStand, Inventory inventory)
        {
            dayCounter++;
            //Console.WriteLine("On to the NEXT DAY!!!");
            lemonadeStand.pitcher.ResetCupsPerDaySold();
            inventory.ResetDailyProfit();
        }

        public void DisplayDay()
        {
            Console.WriteLine("Day = {0}", dayCounter);
        }

        public void PrintDailySalesReport(Booth lemonadeStand, Inventory inventory)
        {
            Console.WriteLine("\n>>>>>DAILY SALES REPORT<<<<< ");
            Console.WriteLine("You sold {0} cups of lemonade for a profit of ${1:0.00}!", 
                lemonadeStand.pitcher.GetTotalCupsSold(), inventory.GetTotalDailyProfit());
        }
    }
}
