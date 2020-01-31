using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class FillInQuestion : Question
    {
        public bool TrimResponse { get; set; }
        public FillInQuestion(string questionText, string correctResponse, bool isCaseSensitive, bool trimResponse) : base(questionText, correctResponse, isCaseSensitive)
        {
            this.TrimResponse = trimResponse;
        }

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
