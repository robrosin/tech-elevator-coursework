using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp.Models
{
    /// <summary>
    /// Quiz is mostly a collection of questions.  Also includes a name (of the quiz) and possibly a score.
    /// </summary>
    public class Quiz
    {
        /// <summary>
        /// This is a common pattern.  We keep the list of questions private, and make an array public, so that
        /// it may not be added to or removed from.
        /// </summary>
        private List<Question> questions;
        /// <summary>
        /// The list of questions "exposed" to the public.
        /// </summary>
        public Question[] Questions
        {
            get
            {
                return questions.ToArray();
            }
        }
        /// <summary>
        /// Name of the quiz.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If the quiz has be taken, the score achieved by the user.
        /// </summary>
        public double Score
        {
            get
            {
                int numQuestions = 0;
                double total = 0.0;
                foreach (Question q in Questions)
                {
                    if (q.IsComplete)
                    {
                        numQuestions++;
                        total += q.Correctness;
                    }
                }
                return (numQuestions > 0) ? total * 100 / numQuestions : 0.0;
            }
        }   // 0.0 - 100.0
        
        /// <summary>
        /// IsComplete is a derived property. A quiz is complete when all the questions on it are complete.
        /// </summary>
        public bool IsComplete
        {
            get
            {
                // This is the long way to write it.....
                // Look for ANY incomplete question and return false if found
                //foreach(Question q in Questions)
                //{
                //    if (!q.IsComplete)
                //    {
                //        return false;
                //    }
                //}
                //return true;

                // This is a shortcut way using LINQ
                return Questions.Where(q => !q.IsComplete).Count() == 0;
            }

        }

        /// <summary>
        /// Constructor which has the initial list of questions.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="questions"></param>
        public Quiz(string name, List<Question> questions)
        {
            this.Name = name;
            this.questions = questions;
        }
    }
}
