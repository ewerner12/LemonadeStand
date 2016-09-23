using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitcher
    {
        public List<Glass> glassesInPitcher;
        public Glass glass;
        public Recipe recipe;
        public int cupsSoldPerDay;
        private int totalCupsSold;

        public Pitcher()
        {
            glassesInPitcher = new List<Glass>();
            glass = new Glass();
            recipe = new Recipe();
            cupsSoldPerDay = 0;
            totalCupsSold = 0;
        }

        //public void FillPitcher()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        glassesInPitcher.Add(glass);
        //    }
        //}

        public void RemoveGlassOfLemonadeFromPitcher(Inventory inventory)
        {
            if (glassesInPitcher.Count > 0)
            {
                glassesInPitcher.Remove(glass);
                inventory.SubtractCupSaleFromInventory();
            }
            else if (glassesInPitcher.Count == 0)
            {
                inventory.CheckRecipeIngredientsInventory(recipe);
            }
            else
            {
                inventory.CheckRecipeIngredientsInventory(recipe);
                RefillPitcher();
                // subtract recipe from inventory!!!!!!!!!!!!!!!!!!!
                inventory.SubtractPitcherIngredients(recipe);
                glassesInPitcher.Remove(glass);
                inventory.SubtractCupSaleFromInventory();
            }
        }

        public void RefillPitcher()
        {
            for (int i = 0; i < 10; i++)
            {
                glassesInPitcher.Add(glass);
            }
            Console.WriteLine("Pitcher was empty but has now been refilled!");
        }

        public void AddCupToDailySalesTotal()
        {
            cupsSoldPerDay++;
        }

        public int GetTotalCupsSold()
        {
            return cupsSoldPerDay;
        }

        public void ResetCupsPerDaySold()
        {
            cupsSoldPerDay = 0;
        }

        public void AddDailyCupsSoldToTotalCupsSold()
        {
            totalCupsSold += cupsSoldPerDay;
        }

        public int GetOverallCupsSold()
        {
            return totalCupsSold;
        }


    }
}
