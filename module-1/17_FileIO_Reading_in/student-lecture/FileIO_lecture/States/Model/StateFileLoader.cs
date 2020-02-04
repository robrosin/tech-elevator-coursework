﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace States.Model
{
    class StateFileLoader
    {
        public List<State> StateList { get; set; }
        public StateFileLoader(string filePath)
        {
            // TODO 21: Open the file, read each line, parse it, and load up a list of states.
            StateList = new List<State>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    // Read in the raw data for the next state
                    string stateString = sr.ReadLine();

                    // Split on the pipe
                    string[] fields = stateString.Split("|");

                    // Assign individual fields
                    string stateCode = fields[1];
                    string stateName = fields[0];
                    string stateCapital = fields[2];
                    string city = fields[3];

                    // Create new state
                    State state = new State(stateCode, stateName, stateCapital, city);
                    // Add the state to the list
                    StateList.Add(state);


                }
            }
        }
    }
}
