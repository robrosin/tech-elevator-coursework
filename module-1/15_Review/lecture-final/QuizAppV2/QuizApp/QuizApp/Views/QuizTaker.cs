using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

namespace QuizApp.Views
{
    /// <summary>
    /// QuizTaker is the class which communicates with the user.  It uses the Quiz and Question classes to get
    /// the prompts and do all the work, but the user conversation is all within QuizTaker. This makes Quiz and
    /// Question (and subclasses) completely testable (no Console.Reads and Console.Writes).
    /// </summary>
    public class QuizTaker
    {
        // A reference to the Quiz to be taken.
        private Quiz quiz;

        /// <summary>
        /// The constructor. YOu cannot have a QuizTaker without a Quiz.
        /// </summary>
        /// <param name="quiz">The Quiz to be taken.</param>
        public QuizTaker(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new NullReferenceException("You must pass a Quiz into QuizTaker");
            }
            this.quiz = quiz;
        }

        /// <summary>
        /// Starts the conversation with the user, presenting Quiz Questions one by one, and
        /// asking the Question class to Grade the user's response.
        /// </summary>
        /// <param name="immediateFeedback"></param>
        public void TakeQuiz(bool immediateFeedback)
        {
            Console.Clear();

            //Console.WriteLine(FiggleFonts.Contessa.Render(quiz.Name));
            Console.WriteLine(FiggleFonts.ThreePoint.Render(quiz.Name));
            Console.WriteLine("Press ENTER to start...");
            Console.ReadLine();

            int questionNumber = 1;
            foreach (Question question in quiz.Questions)
            {
                Console.Clear();
                Console.Write($"{questionNumber}) ");
                Console.WriteLine(question.QuestionToDisplay);

                bool validAnswer = false;
                while (!validAnswer)
                {
                    Console.Write(question.AnswerPrompt);
                    string input = Console.ReadLine();
                    validAnswer = question.ValidateAnswerAndSetResponse(input);
                }

                if (immediateFeedback == true)
                {
                    string feedback;
                    if (question.Correctness == 0.0)
                    {
                        feedback = $"Wrong! The correct answer is '{question.CorrectResponse}'.";
                    }
                    else if (question.Correctness < 1.0)
                    {
                        feedback = $"Partially correct: {question.Correctness}. The correct answer is '{question.CorrectResponse}'.";
                    }
                    else
                    {
                        feedback = "Correct!";
                    }
                    Console.WriteLine(feedback);
                    Console.Write("Press enter to continue...");
                    Console.ReadLine();
                    questionNumber++;
                }
            }

            // Quiz is complete, give a final score
            Console.WriteLine($"Quiz is COMPLETE. Your score was {Math.Round(quiz.Score)}%");
        }
    }
}
