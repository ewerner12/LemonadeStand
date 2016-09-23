using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory inventory;
        public Wallet wallet;
        private string name;

        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
        }

        public void SetName()
        {
            Console.WriteLine("\nPlease enter your name: ");
            name = Console.ReadLine();
        }

        public string GetName()
        {
            return name;
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\nYOU HAVE:");

            for (int i = 0; i < inventory.itemList.Count; i++)
            {
                Console.WriteLine("{0} {1} - [{2}]", inventory.itemList[i].Count,
                    inventory.itemNames[i], (i + 1));
            }
        }

        public void AskForPurchase(Player player)
        {
            string userInput;
            int menuOutput;

            Console.WriteLine("\nSelect the [item number] to purchase: ");
            userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out menuOutput))
            {
                Console.WriteLine("\nPlease select from the available options!");
                AskForPurchase(player);
            }
            else
            {
                inventory.DisplayPurchaseOptions(player, menuOutput);
            }
        }
        

    }
}
