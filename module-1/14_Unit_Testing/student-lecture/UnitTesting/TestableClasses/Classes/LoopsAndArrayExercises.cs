using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes
{
    public class LoopsAndArrayExercises
    {
        /*
         Given 2 int arrays, a and b, each length 3, return a new array length 2 containing their middle 
         elements.
         middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
         middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
         middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]
         */
        public int[] MiddleWay(int[] a, int[] b)
        {
            return new int[] { a[1], b[1] };
        }

        /*
         Given an array of ints length 3, figure out which is larger between the first and last elements 
         in the array, and set all the other elements to be that value. Return the changed array.
         maxEnd3([1, 2, 3]) → [3, 3, 3]
         maxEnd3([11, 5, 9]) → [11, 11, 11]
         maxEnd3([2, 11, 3]) → [3, 3, 3]
         */
        public int[] MaxEnd3(int[] nums)
        {
            int largerNum = (nums[0] > nums[nums.Length - 1]) ? nums[0] : nums[nums.Length - 1];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = largerNum;
            }

            return nums;
        }

        /*
            Return the sum of the numbers in the array, returning 0 for an empty array. Except the number
            13 is very unlucky, so it does not count and numbers that come immediately after a 13 also do
            not count.
            Sum13([1, 2, 2, 1]) → 6
            Sum13([1, 1]) → 2
            Sum13([1, 2, 2, 1, 13]) → 6
        */
        public int Sum13(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 13)
                {
                    sum += nums[i];
                }
            }
            return sum;
        }
    }
}
