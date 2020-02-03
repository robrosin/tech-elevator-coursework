using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class FillInQuestion : Question
    {
        /// <summary>
        /// Should the user's response be trimmed before testing for correctness?
        /// </summary>
        public bool TrimResponse { get; set; }
        public FillInQuestion(string questionText, string correctResponse, bool isCaseSensitive, bool trimResponse) : base(questionText, correctResponse, isCaseSensitive)
        {
            this.TrimResponse = trimResponse;
        }

        /// <summary>
        /// Override of Validate... If needed, the response is trimmed, and then the base class version is called.
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        override public bool ValidateAnswerAndSetResponse(string answer)
        {
            if (TrimResponse)
            {
                answer = answer.Trim();
            }
            return base.ValidateAnswerAndSetResponse(answer);
        }


    }
}
