using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public int menuOut;
        public List<List<Item>> itemList;
        public List<string> itemNames;
        List<Item> listOfItems;
        private List<Item> cupList;
        private List<Item> lemonList;
        private List<Item> sugarList;
        private List<Item> iceList;
        private Cup cup;
        private Lemon lemon;
        private Sugar sugar;
        private Ice ice;
        public double pricePerGlass;
        private double dailyProfit;
        private double overallProfit = 0.00;
        private bool itemsOutOfStock;


        public Inventory()
        {
            itemList = new List<List<Item>>();
            itemNames = new List<string>();
            listOfItems = new List<Item>();
            cupList = new List<Cup>().Cast<Item>().ToList();
            lemonList = new List<Lemon>().Cast<Item>().ToList();
            sugarList = new List<Sugar>().Cast<Item>().ToList();
            iceList = new List<Ice>().Cast<Item>().ToList();
            cup = new Cup();
            lemon = new Lemon();
            sugar = new Sugar();
            ice = new Ice();
            dailyProfit = 0.00;
            //overallProfit = 0.00;
            itemsOutOfStock = false;

            itemList.Add(cupList);
            itemList.Add(lemonList);
            itemList.Add(sugarList);
            itemList.Add(iceList);

            itemNames.Add("plastic cups");
            itemNames.Add("lemons");
            itemNames.Add("cups of sugar");
            itemNames.Add("ice cubes");

            listOfItems.Add(cup);
            listOfItems.Add(lemon);
            listOfItems.Add(sugar);
            listOfItems.Add(ice);
        }

        public void DisplayPurchaseOptions(Player player, int menuOutput)
        {
            switch (menuOutput)
            {
                case 1:
                    ListItemQuantitiesAndPrices(cup.cupsToAdd, cup.cupPrices, menuOutput);
                    player.wallet.SubtractPurchase(cup.cupPrices, menuOut);
                    AddPurchaseToList(cupList, cup, cup.cupsToAdd, cup.cupPrices, menuOut, player.wallet);
                    break;
                case 2:
                    ListItemQuantitiesAndPrices(lemon.lemonsToAdd, lemon.lemonPrices, menuOutput);
                    player.wallet.SubtractPurchase(lemon.lemonPrices, menuOut);
                    AddPurchaseToList(lemonList, lemon, lemon.lemonsToAdd, lemon.lemonPrices, menuOut, player.wallet);
                    break;
                case 3:
                    ListItemQuantitiesAndPrices(sugar.sugarToAdd, sugar.sugarPrices, menuOutput);
                    AddPurchaseToList(sugarList, sugar, sugar.sugarToAdd, sugar.sugarPrices, menuOut, player.wallet);
                    break;
                case 4:
                    ListItemQuantitiesAndPrices(ice.iceToAdd, ice.icePrices, menuOutput);
                    AddPurchaseToList(iceList, ice, ice.iceToAdd, ice.icePrices, menuOut, player.wallet);
                    player.wallet.SubtractPurchase(ice.icePrices, menuOut);
                    break;
                default:
                    DisplayPurchaseOptions(player, menuOut);
                    break;
            }
        }

        public void ListItemQuantitiesAndPrices(int[] itemNumber, double[] itemPrice, int menuOutput)
        {
            string userInput;

            Console.WriteLine("\nSelect amount to purchase: ");

            for(int i = 0; i < itemNumber.Length; i++)
            {
                Console.WriteLine("[{0}] {1} {2} for ${3}", (i+1), itemNumber[i], 
                    itemNames[menuOutput - 1], itemPrice[i]);
            }
            userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out menuOut))
            {
                Console.WriteLine("\nPlease select from the available options!");
                ListItemQuantitiesAndPrices(itemNumber, itemPrice, menuOutput);
            }
        }

        public virtual void AddPurchaseToList(List<Item> list, Item item, int[] itemNumber, 
            double[] itemPrice, int menuOut, Wallet wallet)
        {
            if (wallet.CheckWalletForSufficientFunds())
            {
                for (int i = 0; i < itemNumber[menuOut - 1]; i++)
                {
                    list.Add(item);
                }
            }
        }

        public void SetPricePerGlassSold()
        {
            string input;
            double price;

            Console.WriteLine("\nPlease set the price per glass of lemonade sold: $");
            input = Console.ReadLine();

            if (!double.TryParse(input, out price))
            {
                SetPricePerGlassSold();
            }
            else if(price < 0.00)
            {
                SetPricePerGlassSold();
            }
            pricePerGlass = price;
        }

        public bool CheckCupInventory()
        {
            bool cupsOutOfStock = false;

            if (cupList.Count < 1)
            {
                cupsOutOfStock = true;
                Console.WriteLine("\nSOLD OUT of cups! Buy more and try again tomorrow!");
            }
            return cupsOutOfStock;
        }

        public void SubtractCupSaleFromInventory()
        {
            cupList.Remove(cup);
        }

        public bool CheckRecipeIngredientsInventory(Recipe recipe)
        {
            itemsOutOfStock = false;

            for (int i = 1; i < itemList.Count; i++)
            {
                if ((itemList[i].Count - recipe.ingredients[i - 1]) < 0)
                {
                    itemsOutOfStock = true;
                    Console.WriteLine("\nNot enough ingredients available!");
                }
            }
            return itemsOutOfStock;
        }

        public void SubtractPitcherIngredients(Recipe recipe)
        {
            for (int i = 1; i < itemList.Count; i++)
            {
                for (int j = 0; j < recipe.ingredients[i - 1]; j++)
                {
                    itemList[i].Remove(listOfItems[i]);
                }
            }
        }

        public void AddSaleToDailyProfit()
        {
            dailyProfit += pricePerGlass;
        }

        public double GetTotalDailyProfit()
        {
            return dailyProfit;

        }

        public void ResetDailyProfit()
        {
            dailyProfit = 0.00;
        }

        public void AddDailyProfitToTotalProfit()
        {
            overallProfit += dailyProfit;
        }

        public double GetOverallProfit()
        {
            return overallProfit;
        }

    }
}
