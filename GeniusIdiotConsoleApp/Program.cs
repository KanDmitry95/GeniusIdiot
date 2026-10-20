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
                var user = new User(userName);
                var questionsCount = questions.Count;

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
                        user.AcceptRightAnswer();
                    }

                    questions.RemoveAt(randomQuestionIndex);
                }

                Console.WriteLine("Количество правильных ответов: " + user.CountRightAnswers);

                var diagnose = CalculateDiagnose(questionsCount, user.CountRightAnswers);
                user.Diagnose = diagnose;

                Console.WriteLine($"{userName}, Ваш диагноз: " + diagnose);

                UsersResultStorage.Save(user);

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
            var result = UsersResultStorage.GetUserResult();
            Console.WriteLine("{0,-20}{1,18}{2,15}", "Имя", "Кол-во правильных ответов", "Диагноз");
            foreach (var user in result)
            {
                Console.WriteLine("{0,-20}{1,18}{2,15}", user.Name, user.CountRightAnswers, user.Diagnose);
            }
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