using System;
using System.Collections.Generic;
using System.Text;

namespace ParksAPI
{
    public class Park
    {
        /// <summary>
        /// API: parkCode
        /// </summary>
        public string ParkCode { get; set; }
        /// <summary>
        /// API: fullName (or name)
        /// </summary>
        public string ParkName { get; set; }
        /// <summary>
        /// API: states (comma-separated)
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int Acreage { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int Elevation { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int MilesOfTrail { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int NumberOfCampsites { get; set; }
        /// <summary>
        /// API: weatherInfo
        /// </summary>
        public string Climate { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int YearFounded { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int AnnualVistorCount { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public string Quote { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public string QuoteSource { get; set; }
        /// <summary>
        /// API: description
        /// </summary>
        public string ParkDescription { get; set; }
        /// <summary>
        /// API: entranceFees (complex structure) NON_DEFAULT field
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// API: none!
        /// </summary>
        public int NumberOfAnimalSpecies { get; set; }
        /// <summary>
        /// API: images (complex structure) NON DEFAULT
        /// </summary>
        public string Image { get; set; }

        /*************
         * Could be added or modified (good things in the API)
         * 
         * States is an array (park can be in more than one state)
         *      Or we just take the first from the API
         *  
         *  Directions or DirectionsUrl
         *  
         *  ParkHours
         *  
         *  Url - Park web site
         *  
         *  EntrancePasses
         *  
         *  Designation: national park, national monument, national recreation area, etc
         *  
         *  Images is an array
         *  
         *  LatLong: GPS coordinates
         *  
         *  From the Campground API (we can get a list of CG for any park)
         *      Name
         *      Description
         *      Campsites/totalsites
         *      Images
         *  ****/

        public Park()
        {
        }

        public Park(string parkCode, string parkName, string state, int acreage, int elevation, int mileOfTrails, int numberOfCampsites, string climate, int yearFounded, int annualVistorCount, string quote, string quoteSource, string parkDescription, decimal entryFee, int numberOfAnimalSpecies)
        {
            ParkCode = parkCode;
            ParkName = parkName;
            State = state;
            Acreage = acreage;
            Elevation = elevation;
            MilesOfTrail = mileOfTrails;
            NumberOfCampsites = numberOfCampsites;
            Climate = climate;
            YearFounded = yearFounded;
            AnnualVistorCount = annualVistorCount;
            Quote = quote;
            QuoteSource = quoteSource;
            ParkDescription = parkDescription;
            EntryFee = entryFee;
            NumberOfAnimalSpecies = numberOfAnimalSpecies;
        }
    }
}
 