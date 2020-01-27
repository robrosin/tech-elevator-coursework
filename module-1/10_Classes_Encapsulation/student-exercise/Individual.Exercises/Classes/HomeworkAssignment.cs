using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }

        public int PossibleMarks { get; }

        public string SubmitterName { get; }

        public string LetterGrade
        {
            get
            {
                double letterGrade = (double)EarnedMarks / (double)PossibleMarks;

                if (letterGrade >= .90)
                {
                    return "A";
                }
                if (letterGrade >= .80)
                {
                    return "B";
                }
                if (letterGrade >= .70)
                {
                    return "C";
                }
                if (letterGrade >= .60)
                {
                    return "D";
                }
                return "F";
            }
        }
        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }
    }
}