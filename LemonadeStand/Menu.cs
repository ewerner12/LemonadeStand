using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Menu
    {
        private List<string> mainMenu;
        private int mainMenuOutput;

        public Menu()
        {
            mainMenu = new List<string>();
            mainMenu.Add(">>>What would you like to do (select number)?<<<");
            mainMenu.Add("[1] View Inventory");
            mainMenu.Add("[2] Purchase More Inventory");
            mainMenu.Add("[3] Set Recipe and Open Shop for the day!");
            mainMenu.Add("[4] Print Current Sales Report");
            mainMenu.Add("[5] Clear console");
        }

        public void WelcomeMessage(Player player)
        {
            Console.WriteLine("\nWelcome, {0}!", player.GetName());
        }

        public void DisplayGameBanner()
        {
            Console.WriteLine("\n**********************");
            Console.WriteLine("*   LEMONADE STAND   *");
            Console.WriteLine("**********************");
        }

        public void DisplayMainMenu(Day day, Player player)
        {
            DisplayGameBanner();
            day.DisplayDay();
            day.weather.DisplayForecast();
            Console.WriteLine("Wallet = ${0:0.00}", player.wallet.GetCashOnHand());

            foreach (string option in mainMenu)
            {
                Console.WriteLine(option);
            }
            string userInput = Console.ReadLine(); ;

            if (!int.TryParse(userInput, out mainMenuOutput))
            {
                Console.WriteLine("\nPlease select from the available options!");
                DisplayMainMenu(day, player);
            }
        }

        public void MainMenuAction(Day day, Player player, Booth lemonadeStand)
        {
            switch(mainMenuOutput)
            {
                case 1:
                    // view inventory
                    player.DisplayInventory();
                    break;
                case 2:
                    // purchase inventory
                    player.DisplayInventory();
                    player.AskForPurchase(player);
                    break;
                case 3:
                    // set recipe
                    lemonadeStand.pitcher.recipe.SetRecipe(player.inventory);
                    player.inventory.SetPricePerGlassSold();
                    player.inventory.CheckRecipeIngredientsInventory(lemonadeStand.pitcher.recipe);
                    lemonadeStand.OpenBooth();
                    break;
                case 4:
                    // print sales report
                    DisplayMainMenu(day, player);
                    break;
                case 5:
                    //clear console
                    Console.Clear();
                    DisplayMainMenu(day, player);
                    break;
                default:
                    Console.WriteLine("\nPlease select from the available options!");
                    DisplayMainMenu(day, player);
                    break;
            }
        }

    }
}
