using System;
using System.Collections.Generic;

class QuizApp
{
    // Class to represent a question with multiple choices
    public class Question
    {
        public string Text { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Question(string text, List<string> choices, int correctAnswerIndex)
        {
            Text = text;
            Choices = choices;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        // Method to display the question and choices
        public void Display()
        {
            Console.WriteLine(Text);
            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Choices[i]}");
            }
        }

        // Method to check if the given answer is correct
        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer - 1 == CorrectAnswerIndex;
        }
    }

    static void Main(string[] args)
    {
        // Create a list of questions
        var questions = new List<Question>
        {
            new Question(
                "What is the capital of France?",
                new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
                2
            ),
            new Question(
                "What is the largest planet in our solar system?",
                new List<string> { "Earth", "Jupiter", "Mars", "Venus" },
                1
            ),
            new Question(
                "What is the square root of 64?",
                new List<string> { "6", "7", "8", "9" },
                2
            )
        };

        int score = 0;

        // Iterate through each question
        foreach (var question in questions)
        {
            question.Display();
            Console.Write("Enter your answer (1-4): ");
            
            // Get user input and validate it
            if (int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer >= 1 && userAnswer <= 4)
            {
                if (question.CheckAnswer(userAnswer))
                {
                    Console.WriteLine("Correct!\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.\n");
            }
        }

        // Display the final score
        Console.WriteLine($"Quiz completed! Your score is: {score}/{questions.Count}");
    }
}
