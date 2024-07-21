using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    internal abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public Question[] Questions { get; set; }

        protected Exam(int time, int numberOfQuestions, Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ShowExam();

        public abstract void Asc();


        public override string ToString()
        {
            return $"{this.GetType().Name} - time: {Time} minutes, Number of Questions: {NumberOfQuestions}";
        }

    }
}
