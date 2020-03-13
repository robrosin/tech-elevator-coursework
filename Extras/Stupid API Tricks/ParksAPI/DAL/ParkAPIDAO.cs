using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ParksAPI.DAL
{
    class ParkAPIDAO : IParkDAO
    {
        // Parts of the URL required for all calls
        private string baseurl = "https://developer.nps.gov/api/v1";
        string apiKeyPair = "api_key=YOURkeyGOEShere";

        public List<Park> GetAllParks()
        {
            string endpoint_parks = $"{baseurl}/parks?fields=entranceFees,images,operatingHours&{apiKeyPair}";
            return DoAPI(endpoint_parks);
        }

        public Park GetPark(string parkCode)
        {
            string endpoint_park = $"{baseurl}/parks?parkCode={parkCode}&fields=entranceFees,images,operatingHours&{apiKeyPair}";
            List<Park> parks = DoAPI(endpoint_park);
            if (parks.Count == 0) return null;
            return parks[0];
        }

        private List<Park> DoAPI(string url)
        {
            List<Park> parks = new List<Park>();

            WebClient client = new WebClient();
            // one park string url = "https://developer.nps.gov/api/v1/parks?parkCode=acad&api_key=YourKey";

            // Parts of the URL required for all calls
            //string baseurl = "https://developer.nps.gov/api/v1";
            //string apiKeyPair = "api_key=YourKey";

            //// Individual endpoints
            //string endpoint_parks = $"{baseurl}/parks?{apiKeyPair}";
            //string endpoint_park = $"{baseurl}/parks?{apiKeyPair}&parkCode={parkCode}";   // 0 = parkcode
            // Individual endpoints
            //string endpoint_parks = "parks?fields=entranceFees,images,operatingHours";
            //string endpoint_park = "parks?parkCode={0}";   // 0 = parkcode
            //// Create a url
            //string url;

            //// Get all parks
            //url = endpoint_park;

            // Get a park (cuva)
            //url = $"{baseurl}/{string.Format(endpoint_park, "cuva")}&{apiKeyPair}";

            //url = $"{baseurl}/{endpoint_parks}&{apiKeyPair}";

            string response = client.DownloadString(url);

            NPS_ParkAPI root = JsonConvert.DeserializeObject<NPS_ParkAPI>(response);
            Random random = new Random();
            foreach (NPS_Park npsPark in root.data)
            {
                int index = random.Next(0, npsPark.images.Length);
                Console.WriteLine($"Image index is {index}");
                Park park = new Park()
                {
                    // entranceFees,images,operatingHours
                    ParkCode = npsPark.parkCode,
                    State = npsPark.states.Split(",")[0],
                    Climate = npsPark.weatherInfo,
                    // Choose a random image
                    Image = npsPark.images[index].url,
                    ParkDescription = npsPark.description,
                    ParkName = npsPark.fullName
                };

                // EntranceFees is a collection
                if (npsPark.entranceFees.Length > 0)
                {
                    decimal entryFee;
                    if (decimal.TryParse(npsPark.entranceFees[0].cost, out entryFee))
                    {
                        park.EntryFee = entryFee;
                    }
                }
                parks.Add(park);
            }
            return parks;
        }
    }
}
