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

                var questions = QuestionsStorage.GetAll();
                var questionsCount = questions.Count;

                var correctAnswersCount = 0;

                var random = new Random();

                for (var i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex].Text);
                    var userAnswer = GetUserAnswer();

                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        correctAnswersCount++;
                    }

                    questions.RemoveAt(randomQuestionIndex);
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
            while (!reader.EndOfStream)
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

    }
}