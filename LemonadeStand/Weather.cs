using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        public int todayTemp;
        private int tomorrowTemp;
        private string todayWeather;
        private string tomorrowWeather;
        private string[] conditions = { "sunny", "overcast", "rainy" };

        public void SetForecast()
        {
            Random randomTemp = new Random();
            Random randomWeather = new Random();

            todayTemp = randomTemp.Next(10, 100);
            tomorrowTemp = randomTemp.Next(10, 100);
            todayWeather = conditions[randomWeather.Next(0, 3)];
            tomorrowWeather = conditions[randomWeather.Next(0, 3)];
        }

        public void DisplayForecast()
        {
            // forecast for today and tomorrow
            Console.WriteLine("Today's forecast is: {0} and {1}.", todayWeather, todayTemp);
            Console.WriteLine("Tomorrow's forecast is: {0} and {1}.", tomorrowWeather, tomorrowTemp);
        }
    }
}
