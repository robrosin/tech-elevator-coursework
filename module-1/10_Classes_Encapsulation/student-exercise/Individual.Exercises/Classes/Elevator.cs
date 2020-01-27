using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        public int CurrentLevel { get; private set; }
        public int NumberOfLevels { get; }
        public bool DoorIsOpen { get; private set; }

        //Constructor
        public Elevator(int numberOfLevels)
        {
            CurrentLevel = 1;
            NumberOfLevels = numberOfLevels;
        }

        // Methods
        public void OpenDoor() // Opens elevator door
        {
            DoorIsOpen = true;
        }
        public void CloseDoor() // Closes elevator door
        {
            DoorIsOpen = false;
        }
        public void GoUp(int desiredFloor) // +1 to floor as long as < numberOfLevels
        {
            if (!DoorIsOpen && (desiredFloor <= NumberOfLevels) && (desiredFloor > CurrentLevel))
            {
                CurrentLevel = desiredFloor;
            }
        }
        public void GoDown(int desiredFloor) // -1 to floor as long as > 1
        {
            if (!DoorIsOpen && (desiredFloor >= 1) && (desiredFloor < CurrentLevel))
            {
                CurrentLevel = desiredFloor;
            }
        }
    }
}
