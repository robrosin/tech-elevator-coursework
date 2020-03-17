using Newtonsoft.Json;
using System;
using System.Net;

namespace WeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TE Weather!");
            Console.WriteLine("Press Enter to get the weather.");
            Console.ReadLine();

            // Execute the query to get a grid point from a lat/long
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Weather-api-tester");
            string response = client.DownloadString("https://api.weather.gov/points/41.2808,-81.5678");

            WeatherLatLongToPoint root = JsonConvert.DeserializeObject<WeatherLatLongToPoint>(response);

            client = new WebClient();
            client.Headers.Add("user-agent", "Weather-api-tester");
            response = client.DownloadString(root.properties.forecast);
            WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(response);
            Console.WriteLine("Weather for Tech Elevator (41.2808,-81.5678)");
            Console.WriteLine();
            foreach (WeatherForecast.Period period in forecast.properties.periods)
            {
                Console.WriteLine($"{period.name,-15} {period.temperature,4}{period.temperatureUnit} {(period.windDirection + " " + period.windSpeed), 15} {period.shortForecast}");
            }

            Console.ReadLine();
        }
    }
}
