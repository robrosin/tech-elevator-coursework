using QuizApp.Models;
using QuizApp.Views;
using System;
using System.Collections.Generic;

namespace QuizApp
{
    class Program
    {
        private static Dictionary<Quiz, double?> quizzes = new Dictionary<Quiz, double?>()
        {
            { SampleQuizzes.VariablesAndDataTypes, null},
            { SampleQuizzes.TheBridgeOfDeath, null},
        };


        static void Main(string[] args)
        {
            SelectAQuiz();

            Console.WriteLine();
            Console.WriteLine("Thanks for playing - Please come back soon!");
            Console.ReadLine();
        }

        static void SelectAQuiz()
        {
            // Loop until the user is done
            bool quit = false;

            while (!quit)
            {
                Console.Clear();

                // Print heading

                // Show the user the list of quizzes
                //Print each quiz
                Dictionary<int, Quiz> choices = new Dictionary<int, Quiz>();
                int choice = 1;
                Console.WriteLine($"{"Choice",6} {"Name",-40} {"Score",6}");
                Console.WriteLine("=========================================================");
                foreach (KeyValuePair<Quiz, double?> kvp in quizzes)
                {
                    Quiz quiz = kvp.Key;
                    choices.Add(choice, quiz);
                    string scoreString = "---";
                    double? score = kvp.Value;
                    if (score.HasValue)
                    {
                        scoreString = $"{Math.Round(score.Value)}%";
                    }
                    Console.WriteLine($"{choice,5}) {quiz.Name,-40} {scoreString,6}");
                    choice++;

                }

                // Allow user to select one to take
                bool validSelection = false;
                int selection = 0;
                while (!validSelection)
                {
                    Console.WriteLine();
                    Console.Write("Select a quiz (Q to quit): ");
                    string input = Console.ReadLine().ToLower();

                    if (input.StartsWith("q"))
                    {
                        quit = true;
                        return;
                    }
                    if (!int.TryParse(input, out selection))
                    {
                        // try again
                        continue;
                    }
                    if (!choices.ContainsKey(selection))
                    {
                        continue;
                    }
                    validSelection = true;

                }
                // Ok, take the quiz
                Quiz quizToTake = choices[selection];
                QuizTaker quizTaker = new QuizTaker(quizToTake);
                quizTaker.TakeQuiz(true);
                // Record the score
                quizzes[quizToTake] = quizToTake.Score;

                Console.ReadLine();
            }
        }
    }
}
