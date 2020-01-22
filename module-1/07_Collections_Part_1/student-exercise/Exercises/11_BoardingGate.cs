﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given a list of Integers representing seat numbers, group them into ranges 1-10, 11-20, and 21-30.
         (Any seat number less than 1, or greater than 30 is invalid, and can be ignored.) Preserve the order
         in which the seat number entered their associated group. Return a list of the grouped Integers 1-10,
         11-20, and 21-30. (Hint: Think multiple queues)
         DIFFICULTY: HARD
		 BoardingGate( [1, 13, 43, 22, 8, 11, 30, 2, 4, 14, 21] ) -> [1, 8, 2, 4, 13, 11, 14, 22, 30, 21]
         BoardingGate( [29, 19, 9, 21, 11, 1, 0, 25, 15, 5, 31] ) -> [9, 1, 5, 19, 11, 15, 29, 21, 25]
         BoardingGate( [0, -1, 44, 31, 17, 7, 27, 16, 26, 6] ) -> [7, 6, 17, 16, 27, 26]
         */
        public List<int> BoardingGate(List<int> seatNumberList)
        {
            List<int> row1 = new List<int>();
            List<int> row2 = new List<int>();
            List<int> row3 = new List<int>();

            while (seatNumberList.Count >= 1)
            {
                if ((seatNumberList[0] >= 1) && (seatNumberList[0] <= 10))
                {
                    row1.Add(seatNumberList[0]);
                    seatNumberList.RemoveAt(0);
                }
                else if ((seatNumberList[0] >= 11) && (seatNumberList[0] <= 20))
                {
                    row2.Add(seatNumberList[0]);
                    seatNumberList.RemoveAt(0);
                }
                else if ((seatNumberList[0] >= 21) && (seatNumberList[0] <= 30))
                {
                    row3.Add(seatNumberList[0]);
                    seatNumberList.RemoveAt(0);
                }
                else
                {
                    seatNumberList.RemoveAt(0);
                }
            }
            row1.AddRange(row2);
            row1.AddRange(row3);
            return row1;
        }

    }
}