using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Question[] questions)
        : base(time, numberOfQuestions, questions) { }

        public override void Asc()
        {
            int totalScore = 0;
            int totalMark = 0;

            foreach (Question question in Questions)
            {
                totalMark += question.Mark;
                question.DisplayQuestion();

                int answerId;
                Console.Write("Your Answer: ");

                if (question.Header == "true or false")
                {
                    while (!int.TryParse(Console.ReadLine(), out answerId) || (answerId < 1 || answerId > 2))
                    {
                        Console.WriteLine("Please enter a valid answer between 1 and 2:");
                    }
                }
                else
                {
                    while (!int.TryParse(Console.ReadLine(), out answerId) || (answerId < 1 || answerId > question.AnswerList.Length))
                    {
                        Console.WriteLine($"Please enter a valid answer between 1 and {question.AnswerList.Length}:");
                    }
                }

                if (question.ValidateAnswer(answerId))
                {
                    totalScore += question.Mark;
                }
                Console.Clear();
            }

            foreach (Question question in Questions)
            {
                string correctAnswerText = question.AnswerList[question.RightAnswerId - 1].AnswerText;
                Console.WriteLine($"Correct answer for \"{question.Body}\": {correctAnswerText}");
            }

            Console.WriteLine($"Your Total Grade: {totalScore}/{totalMark}");
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
                Console.WriteLine("Your Answer: ");
            }
        }
    }
}
