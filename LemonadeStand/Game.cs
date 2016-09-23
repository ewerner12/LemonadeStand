using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        Booth lemonadeStand;
        Day day;
        Menu menu;
        Player player;
        Random random = new Random();

        public Game()
        {
            lemonadeStand = new Booth();
            day = new Day(random);
            menu = new Menu();
            player = new Player();
        }
        
        /* MAIN PROGRAM */
        public void Run()
        {
            player.SetName();

            for (int d = 0; d < 2; d++)
            {
                menu.WelcomeMessage(player);
                day.weather.SetForecast();

                while (!lemonadeStand.GetBoothStatus())
                {
                    menu.DisplayMainMenu(day, player);
                    menu.MainMenuAction(day, player, lemonadeStand);
                }

                // run through customer list
                while (lemonadeStand.GetBoothStatus())
                {
                    //Console.WriteLine("\n[run through customer list]");
                    lemonadeStand.OpenForBidness(day, player);
                } 
                
                // print sales for the day
                //Console.WriteLine("\n[print daily sales report]");
                day.PrintDailySalesReport(lemonadeStand, player.inventory);
                player.inventory.AddDailyProfitToTotalProfit();
                lemonadeStand.pitcher.AddDailyCupsSoldToTotalCupsSold();

                //lemonadeStand.CloseBooth();
                day.NextDay(lemonadeStand, player.inventory);
            }
            Console.WriteLine("\nThanks for playing!!");
            Console.WriteLine("You sold {0} total cups for an overall profit of ${1:0.00}", 
                lemonadeStand.pitcher.GetOverallCupsSold(), player.inventory.GetOverallProfit());

            // two weeks are up! thanks for playing! print report!
        }
    }
}
