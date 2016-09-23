using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        private int recipeLemons = 0;
        private int recipeSugarCups = 0;
        private int recipeIceCubes = 0;
        public int[] ingredients;
        // has ingredients
        // set recipe method - will have to pass inventory list of lists

        public Recipe()
        {
            ingredients = new int[] { recipeLemons, recipeSugarCups, recipeIceCubes };
        }

        public void SetRecipe(Inventory inventory)
        {
            Console.WriteLine("\nSelect amount of ingredients per PITCHER of lemonade: ");
            for (int i = 1; i < inventory.itemNames.Count; i++)
            {
                Console.Write("{0} = ", inventory.itemNames[i]);

                string userInput = Console.ReadLine();
                int userOutput;

                if (!int.TryParse(userInput, out userOutput))
                {
                    SetRecipe(inventory);
                }
                else
                {
                    while ((userOutput < 1) || (userOutput > 10))
                    {
                        if (userOutput < 1)
                        {
                            Console.WriteLine("\nNeeds more {0}!", inventory.itemNames[i]);
                        }
                        else if (userOutput > 10)
                        {
                            Console.WriteLine("\nLess {0}!", inventory.itemNames[i]);
                        }
                        SetRecipe(inventory);
                    }

                    ingredients[i - 1] = userOutput;
                }
            }
        }



    }
}
