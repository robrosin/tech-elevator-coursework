using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class TrueFalseQuestion : Question
    {
        /// <summary>
        /// Constructor, defers to the base class (Question)
        /// </summary>
        /// <param name="questionText"></param>
        /// <param name="correctResponse"></param>
        public TrueFalseQuestion(string questionText, string correctResponse) : base(questionText, correctResponse, false)
        {
        }

        /// <summary>
        /// Override of the prompt to the user.
        /// </summary>
        override public string AnswerPrompt
        {
            get
            {
                return "Answer (true or false): ";
            }
        }

        /// <summary>
        /// Override of Validate... Tests for various possible versions of true (T, t, True, Yes, y Y...) or false.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        override public bool ValidateAnswerAndSetResponse(string answer)
        {
            switch (answer.ToLower())
            {
                case "y":
                case "t":
                case "yes":
                case "true":
                    answer = "true";
                    break;
                case "n":
                case "no":
                case "f":
                case "false":
                    answer = "false";
                    break;
                default:
                    return false;
            }
            base.ValidateAnswerAndSetResponse(answer);
            return true;
        }
    }
}
