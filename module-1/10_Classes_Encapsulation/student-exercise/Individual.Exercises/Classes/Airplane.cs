using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        public string PlaneNumber { get; }
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats // derived from subtracting BookedFirstClassSeats from TotalFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }


        public int TotalFirstClassSeats { get; }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats // derived from subtracting BookedCoachSeats from TotalCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }
        }

        public int TotalCoachSeats { get; }

        // Constructor
        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }
        // Method
        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass && AvailableFirstClassSeats > totalNumberOfSeats)
            {
                BookedFirstClassSeats += totalNumberOfSeats;
                return true;
            }
            if (!forFirstClass && AvailableCoachSeats > totalNumberOfSeats)
            {
                BookedCoachSeats += totalNumberOfSeats;
                return true;
            }
            return false;
        }
    }
}