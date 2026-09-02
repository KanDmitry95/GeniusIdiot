using System.Text;

namespace GeniyIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Здравствуйте! Как вас зовут?");
                var userName = Console.ReadLine();

                var questions = GetQuestions();
                var answers = GetAnswers();
                var questionsCount = questions.Count;

                var correctAnswersCount = 0;

                var random = new Random();

                for (var i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex]);
                    var userAnswer = GetUserAnswer();

                    var rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        correctAnswersCount++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
                    answers.RemoveAt(randomQuestionIndex);
                }

                Console.WriteLine("Количество правильных ответов: " + correctAnswersCount);

                var diagnose = CalculateDiagnose(questionsCount, correctAnswersCount);

                Console.WriteLine($"{userName}, Ваш диагноз:" + diagnose);

                SaveUserResult(userName, correctAnswersCount, diagnose);

                bool userChoise = GetUserChoice("Хотите посмотреть предыдущие результаты игры ?");
                if (userChoise)
                {
                    ShowUserResult();
                }

                userChoise = GetUserChoice("Хотите начать сначала?");
                if (userChoise == false)
                {
                    break;
                }
            }
        }

        private static void ShowUserResult()
        {
            var reader = new StreamReader("userResault.txt", Encoding.UTF8);

            Console.WriteLine("{0,-20}{1,18}{2,15}", "Имя", "Кол-во правильных ответов", "Диагноз");
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split("#");
                var name = values[0];
                var countRightAnswer = Convert.ToInt32(values[1]);
                var diagnose = values[2];

                Console.WriteLine("{0,-20}{1,18}{2,15}", name, countRightAnswer, diagnose);
            }
            reader.Close();
        }

        static void SaveUserResult(string userName, int correctAnswersCount, string diagnose)
        {
            string value = $"{userName}#{correctAnswersCount}#{diagnose}";
            AppendToFile("userResault.txt", value);
        }

        static void AppendToFile(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        static string CalculateDiagnose(int questionsCount, int correctAnswersCount)
        {
            var diagnoses = GetDiagnoses();
            var percentRightAnswer = correctAnswersCount * 100 / questionsCount;

            return diagnoses[percentRightAnswer / 20];
        }

        private static int GetUserAnswer()
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слишком большое число");
                }
            }
        }

        static bool GetUserChoice(string message)
        {
            while (true)
            {
                Console.WriteLine($"{message} Введите Да или Нет");
                var userInput = Console.ReadLine();

                if (userInput.ToLower() == "нет")
                {
                    return false;
                }
                if (userInput.ToLower() == "да")
                {
                    return true;
                }
            }
        }

        static string[] GetDiagnoses()
        {
            string[] diagnoses =
            [
                "Идиот",
                "Кретин",
                "Дурак",
                "Нормальный",
                "Талант",
                "Гений"
            ];
            return diagnoses;
        }

        static List<int> GetAnswers()
        {
            var answers = new List<int>();
            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);
            return answers;
        }

        static List<string> GetQuestions()
        {
            var questions = new List<string>();
            questions.Add("Сколько будет два плюс два умноженное на два?");
            questions.Add("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках?");
            questions.Add("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?");
            questions.Add("Пять свечей горело, две потухли. Сколько свечей осталось?");
            return questions;
        }
    }
}