using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    internal class McqQuestion : Question
    {
        public McqQuestion(string header, string body, int _mark, Answer[] answerList, int rightAnswer) : base(header, body, _mark, answerList, rightAnswer) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\n{Body}");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            }
        }
    }
}
