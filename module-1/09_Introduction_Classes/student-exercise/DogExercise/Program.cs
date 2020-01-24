using System;

namespace DogExercise
{
    public class Dog
    {
        public Dog()
        {
        }
        public bool IsSleeping { get; }
        public string MakeSound()
        {
            if (IsSleeping == true)
            {
                return "Zzzzz...";
            }
            else
            {
                return "Woof!";
            }
        }
    }
}