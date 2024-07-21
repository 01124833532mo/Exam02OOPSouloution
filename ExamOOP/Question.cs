using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    internal abstract class Question
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswerId { get; set; }

        protected Question(string header, string body, int mark, Answer[] answerList, int rightAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswerId = rightAnswerId;
        }

        public abstract void DisplayQuestion();

        public bool ValidateAnswer(int answerId)
        {
            return RightAnswerId == answerId;
        }



        public override string ToString()
        {
            return $"{Header} - {Body} (Mark: {Mark})";
        }


    }
}
