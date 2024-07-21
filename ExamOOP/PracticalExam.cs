using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions, Question[] questions)
       : base(time, numberOfQuestions, questions) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine("**********************************************");
                question.DisplayQuestion();

                Console.WriteLine("your anser is   ");

                Console.WriteLine("*****************");
            }
        }
        public override void Asc()
        {
            int totalmark = 0;

            int totalScore = 0;
            foreach (Question question in Questions)
            {
                totalmark += question.Mark;

                question.DisplayQuestion();

                Console.Write("Your Answer: ");

                int answerId;
                bool flag1 = int.TryParse(Console.ReadLine(), out answerId);
                while (!flag1 || (answerId < 1 || answerId > 2))
                {
                    Console.WriteLine("please enter valid anser betwan 1 and 2 :");
                    flag1 = int.TryParse(Console.ReadLine(), out answerId);

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
                Console.WriteLine($"Correct answer for {question.Body}: {correctAnswerText}");
            }


            Console.WriteLine($"Your Total Grade: {totalScore}/{totalmark}");

        }



    }
}
