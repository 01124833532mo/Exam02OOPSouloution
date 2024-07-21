using System.Diagnostics;

namespace ExamOOP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string head = "true or false";

            Console.Write("Enter type of exam (1-Practical, 2-Final): ");
            int examType;
            bool flag1 = int.TryParse(Console.ReadLine(), out examType);
            while (!flag1 || (examType < 1 || examType > 2))
            {
                Console.Write("Please enter a valid type of exam (1-Practical, 2-Final): ");
                flag1 = int.TryParse(Console.ReadLine(), out examType);
            }

            int time;
            do
            {
                Console.Write("Enter time of exam in minutes: ");
            } while (!int.TryParse(Console.ReadLine(), out time));

            int numberOfQuestions;
            do
            {
                Console.Write("Enter the number of questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions));

            Question[] questions = new Question[numberOfQuestions];

            if (examType == 1)
            {
                head = "true or false";
                Answer[] tfAnswers = new Answer[]
                {
                    new Answer(1, "True"),
                    new Answer(2, "False")
                };

                Console.WriteLine($"Question type is: {head}");
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    string body;
                    do
                    {
                        Console.Write($"Please enter the body of the question {i + 1}: ");
                        body = Console.ReadLine() ?? string.Empty;
                    } while (string.IsNullOrEmpty(body));

                    int mark;
                    do
                    {
                        Console.Write($"Please enter the mark of the question {i + 1}: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    Console.Write("Please enter the right answer of the question (1 for True, 2 for False): ");
                    int rightAnswerId;
                    bool flag2 = int.TryParse(Console.ReadLine(), out rightAnswerId);
                    while (!flag2 || (rightAnswerId < 1 || rightAnswerId > 2))
                    {
                        Console.Write("Please enter the right answer of the question (1 for True, 2 for False): ");
                        flag2 = int.TryParse(Console.ReadLine(), out rightAnswerId);
                    }

                    questions[i] = new TfQuestion(head, body, mark, tfAnswers, rightAnswerId);
                }
            }
            else
            {
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    Console.WriteLine($"Please choose type of question number({i + 1}) (1- True or False, 2- MCQ): ");
                    int questionType;

                    flag1 = int.TryParse(Console.ReadLine(), out questionType);
                    while (!flag1 || (questionType < 1 || questionType > 2))
                    {
                        Console.WriteLine($"Please choose valid type of question number({i + 1}) (1- True or False, 2- MCQ): ");
                        flag1 = int.TryParse(Console.ReadLine(), out questionType);
                    }

                    string header;
                    if (questionType == 1)
                    {
                        header = head;



                    }
                    else
                    {
                        header = "MCQ";
                    }
                    Console.WriteLine($"Type of question is: {header}");

                    string body;
                    do
                    {
                        Console.Write("Please enter the body of the question: ");
                        body = Console.ReadLine() ?? string.Empty;
                    } while (string.IsNullOrEmpty(body));

                    int mark;
                    do
                    {
                        Console.Write("Please enter the mark of the question: ");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    if (questionType == 1)
                    {
                        Answer[] tfAnswers = new Answer[]
                        {
                            new Answer(1, "True"),
                            new Answer(2, "False")
                        };

                        Console.Write("Please enter the right answer of the question (1 for True, 2 for False): ");
                        int rightAnswerId;
                        bool flag3 = int.TryParse(Console.ReadLine(), out rightAnswerId);
                        while (!flag3 || (rightAnswerId < 1 || rightAnswerId > 2))
                        {
                            Console.Write("Please enter the right answer of the question (1 for True, 2 for False): ");
                            flag3 = int.TryParse(Console.ReadLine(), out rightAnswerId);
                        }

                        questions[i] = new TfQuestion(header, body, mark, tfAnswers, rightAnswerId);
                    }
                    else if (questionType == 2)
                    {
                        Console.WriteLine("Please enter the number of options for the MCQ: ");
                        int optionsCount;
                        while (!int.TryParse(Console.ReadLine(), out optionsCount) || optionsCount < 2)
                        {
                            Console.WriteLine("Please enter a valid number of options for the MCQ (at least 2): ");
                        }

                        Answer[] mcqAnswers = new Answer[optionsCount];
                        for (int j = 0; j < optionsCount; j++)
                        {
                            Console.Write($"Please enter text for option {j + 1}: ");
                            string answerText = Console.ReadLine() ?? string.Empty;
                            while (string.IsNullOrEmpty(answerText))
                            {
                                Console.Write($"Please enter valid text for option {j + 1}: ");
                                answerText = Console.ReadLine() ?? string.Empty;

                            };
                            mcqAnswers[j] = new Answer(j + 1, answerText);
                        }

                        Console.Write("Please enter the right answer of the question: ");
                        int rightAnswerId;
                        while (!int.TryParse(Console.ReadLine(), out rightAnswerId) || rightAnswerId < 1 || rightAnswerId > optionsCount)
                        {
                            Console.Write($"Please enter a valid right answer of the question (1-{optionsCount}): ");
                        }

                        questions[i] = new McqQuestion(header, body, mark, mcqAnswers, rightAnswerId);
                    }
                }
            }

            Console.Clear();
            Exam exam;
            if (examType == 1)
            {
                exam = new PracticalExam(time, numberOfQuestions, questions);
            }
            else
            {
                exam = new FinalExam(time, numberOfQuestions, questions);
            }
            Subject subject = new Subject(10, "C#");


            subject.CreateExam(exam);

            Console.WriteLine(subject.ToString());

            Console.Write("Do You Want To Start The Exam (y | n): ");
            if (char.Parse(Console.ReadLine() ?? "y") == 'y')
            {
                Console.WriteLine("**************");
                Console.WriteLine("Preview of the Exam:");
                exam.ShowExam();
                Console.WriteLine("Start exam \n \n \n");
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();

                exam.Asc();

                sw.Stop();

                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
        }

    }
}
