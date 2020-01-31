using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    abstract public class Question
    {
        public string QuestionText { get; }         // Only settable during construction
        public string CorrectResponse { get; }      // Only settable during construction
        public bool IsCaseSensitive { get; }        // Only settable during construction

        virtual public string QuestionToDisplay
        {
            get
            {
                return QuestionText;
            }
        }

        // Only allow Response to be modified if the question is not complete
        private string responseText;
        public string ResponseText
        {
            get { return this.responseText; }
            set
            {
                if (!IsComplete)
                {
                    this.responseText = value;
                }
            }
        }
        public double Correctness { get; set; }     // Scale of 0.0 - 1.0, allows for partial credit
        public bool IsComplete { get; private set; }
        public Question(string questionText, string correctResponse, bool isCaseSensitive)
        {
            // This constructor should take arguments needed to completely define the question
            this.QuestionText = questionText;
            this.CorrectResponse = correctResponse;
            this.IsCaseSensitive = isCaseSensitive;
            this.IsComplete = false;
            this.Correctness = 0.0;
        }

        virtual protected void GradeQuestion()
        {
            // By default, simply compare the user's response to the correct response
            if (IsCaseSensitive)
            {
                Correctness = (ResponseText == CorrectResponse) ? 1.0 : 0.0;
            }
            else
            {
                Correctness = (ResponseText.ToLower() == CorrectResponse.ToLower()) ? 1.0 : 0.0;
            }
        }

        virtual public string AnswerPrompt
        {
            get
            {
                return "Answer: ";
            }
        }

        virtual public bool ValidateAnswerAndSetResponse(string answer)
        {
            ResponseText = answer;
            GradeQuestion();
            this.IsComplete = true;
            return true;
        }
    }
}
