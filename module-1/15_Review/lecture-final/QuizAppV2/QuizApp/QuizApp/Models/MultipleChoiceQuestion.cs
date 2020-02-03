using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    /// <summary>
    /// Multiple Choice Question derives from Question.
    /// </summary>
    public class MultipleChoiceQuestion : Question
    {
        /// <summary>
        /// This is an additional read-only property defined on MC Question but not on Question.
        /// </summary>
        public Dictionary<string, string> PossibleResponses { get; }

        /// <summary>
        /// Constructor for MC Question. Notice it takes more parameters than the Question constructor takes,
        /// but passes the appropriate params to the base class using the  : base() syntax.
        /// </summary>
        /// <param name="questionText"></param>
        /// <param name="correctResponse"></param>
        /// <param name="possibleResponses"></param>
        public MultipleChoiceQuestion(string questionText, string correctResponse, Dictionary<string, string> possibleResponses) : base(questionText, correctResponse, false)
        {
            this.PossibleResponses = possibleResponses;
        }

        /// <summary>
        /// Overrides the property in Question, because a MC Question must list all the possible responses
        /// </summary>
        override public string QuestionToDisplay
        {
            get
            {
                // Calls the base class to get the default prompt.
                string question = base.QuestionToDisplay + "\r\n";

                // Tack on the list of choices.
                foreach (KeyValuePair<string, string> pr in PossibleResponses)
                {
                    question += $"\t{pr.Key} - {pr.Value}\r\n";
                }
                return question;
            }
        }

        /// <summary>
        /// Override of the prompt.  Insteadof "Answer:" use "Select One:"
        /// </summary>
        override public string AnswerPrompt
        {
            get
            {
                return "Select One: ";
            }
        }

        /// <summary>
        /// Override base because we first need to validate that the user types a response that is in our PossibleResponses.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        override public bool ValidateAnswerAndSetResponse(string answer)
        {

            if (!this.PossibleResponses.ContainsKey(answer))
            {
                return false;
            }

            // Once we have validated the response, the base class implementation does the rest.
            base.ValidateAnswerAndSetResponse(answer);
            return true;
        }
    }
}
