using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParksAPI.DAL;
using System;
using System.Collections.Generic;
using System.Net;

namespace ParksAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            const string lumbergh = @"{
    firstName: ""Bill"",
    lastName: ""Lumbergh"",
    age: 42,
    employees: [
      ""Peter Gibbons"",
      ""Milton Waddams"",
      ""Samir Nagheenanajar"",
      ""Michael Bolton""
    ]
}
";
            Person person = JsonConvert.DeserializeObject<Person>(lumbergh);


            WebClient client = new WebClient();
            //client.Headers.Add(HttpRequestHeader.Accept, "*/*");
            client.Headers.Add("user-agent", "Only a test!");
            string response = client.DownloadString("https://api.weather.gov/points/41.2808,-81.5678");




            WeatherLatToPoint root = JsonConvert.DeserializeObject<WeatherLatToPoint>(response);
            client = new WebClient();
            client.Headers.Add("user-agent", "Only a test!");
            response = client.DownloadString(root.properties.forecast);
            Forecast_Root forecast = JsonConvert.DeserializeObject<Forecast_Root>(response);


            //Console.WriteLine("Hello World!");

            IParkDAO dao = new ParkAPIDAO();
            Park park = dao.GetPark("yell");
            Console.ReadLine();

            List<Park> parks = dao.GetAllParks();
            Console.ReadLine();

            //WebClient client = new WebClient();
            //// one park            string url = "https://developer.nps.gov/api/v1/parks?parkCode=acad&api_key=YourKey";


            //// Parts of the URL required for all calls
            //string baseurl = "https://developer.nps.gov/api/v1";
            //string apiKeyPair = "api_key=YourKey";

            //// Individual endpoints
            //string endpoint_parks = "parks?fields=entranceFees,images,operatingHours";
            //string endpoint_park = "parks?parkCode={0}";   // 0 = parkcode

            //// Create a url
            //string url;

            //// Get all parks
            //url = $"{baseurl}/{endpoint_parks}&{apiKeyPair}";

            //// Get a park (cuva)
            ////url = $"{baseurl}/{string.Format(endpoint_park, "cuva")}&{apiKeyPair}";

            //string response = client.DownloadString(url);

            //NPS_ParkAPI root = JsonConvert.DeserializeObject<NPS_ParkAPI>(response);

            //JArray array = (JArray)JsonConvert.DeserializeObject(response);
            //foreach (JObject obj in array)
            //{
            //    Console.WriteLine($"{obj["name"]}: {obj["street"]}");
            //}

            Console.ReadKey();
        }
    }


}
