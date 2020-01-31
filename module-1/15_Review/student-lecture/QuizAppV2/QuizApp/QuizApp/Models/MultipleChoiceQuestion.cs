using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public Dictionary<string, string> PossibleResponses { get; }

        public MultipleChoiceQuestion(string questionText, string correctResponse, Dictionary<string, string> possibleResponses) : base(questionText, correctResponse, false)
        {
            this.PossibleResponses = possibleResponses;
        }

        override public string QuestionToDisplay
        {
            get
            {
                string question = base.QuestionToDisplay + "\r\n";

                foreach (KeyValuePair<string, string> pr in PossibleResponses)
                {
                    question += $"\t{pr.Key} - {pr.Value}\r\n";
                }
                return question;
            }
        }

        override public string AnswerPrompt
        {
            get
            {
                return "Select One: ";
            }
        }

        override public bool ValidateAnswerAndSetResponse(string answer)
        {
            if (!this.PossibleResponses.ContainsKey(answer))
            {
                return false;
            }
            base.ValidateAnswerAndSetResponse(answer);
            return true;
        }
    }
}
