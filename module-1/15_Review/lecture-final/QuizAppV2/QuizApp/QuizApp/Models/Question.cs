using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    /// <summary>
    /// Question is an abstract class, meaning an instance of type Question can never be created;
    /// only instances of derived types.  
    /// </summary>
    abstract public class Question
    {
        /************************************
        * Read-only properties: These can be set at construction time, but not changed after that.  
        * There is no need to change a questions's text or correct answer during its lifetime.
        *************************************/
        /// <summary>
        /// Text of the question
        /// </summary>
        public string QuestionText { get; }         // Only settable during construction
        /// <summary>
        /// Text of the correct response
        /// </summary>
        public string CorrectResponse { get; }      // Only settable during construction
        /// <summary>
        /// Whether the user's response must match the correct response exactly, or allow mixed case
        /// </summary>
        public bool IsCaseSensitive { get; }        // Only settable during construction

        /// <summary>
        /// Virtual property to say what the prompt is to the user. Default implementation is 
        /// to just display questiontext, but some question types need to do more, so they will override
        /// </summary>
        virtual public string QuestionToDisplay
        {
            get
            {
                return QuestionText;
            }
        }

        private string responseText;
        /// <summary>
        /// This is an example of "old-style" non-automatice property.
        /// We did this because we needed special logic in our setter.
        /// Only allow Response to be modified if the question is not complete
        /// </summary>
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

        /// <summary>
        /// This is an example of an automatic property
        /// </summary>
        public double Correctness { get; set; }     // Scale of 0.0 - 1.0, allows for partial credit


        /// <summary>
        /// Here is an example of a get-private-set.  Anyone can see if the questino has been completed or not,
        /// but only the question can mark itself as complete.
        /// </summary>
        public bool IsComplete { get; private set; }

        /// <summary>
        /// A constructor to set initial values, especialy the read-only ones.
        /// </summary>
        /// <param name="questionText"></param>
        /// <param name="correctResponse"></param>
        /// <param name="isCaseSensitive"></param>
        public Question(string questionText, string correctResponse, bool isCaseSensitive)
        {
            // This constructor should take arguments needed to completely define the question
            this.QuestionText = questionText;
            this.CorrectResponse = correctResponse;
            this.IsCaseSensitive = isCaseSensitive;
            this.IsComplete = false;
            this.Correctness = 0.0;
        }

        /// <summary>
        /// Method to ask the question to grade itself. Marked virtual because different 
        /// types of question may have different types of grading.
        /// </summary>
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

        /// <summary>
        /// So QuizTaker knows how to prompt the user for an answer.
        /// </summary>
        virtual public string AnswerPrompt
        {
            get
            {
                return "Answer: ";
            }
        }

        /// <summary>
        /// Pass in the user's response, validate it and grade it.
        /// </summary>
        /// <param name="answer">User's response</param>
        /// <returns>True if the response was valid for this type of question. False if the user should be re-prompted.</returns>
        virtual public bool ValidateAnswerAndSetResponse(string answer)
        {
            ResponseText = answer;
            GradeQuestion();
            this.IsComplete = true;
            return true;
        }
    }
}
