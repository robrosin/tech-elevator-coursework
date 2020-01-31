using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string questionText, string correctResponse) : base(questionText, correctResponse, false)
        {
        }

        override public string AnswerPrompt
        {
            get
            {
                return "Answer (true or false): ";
            }
        }

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
