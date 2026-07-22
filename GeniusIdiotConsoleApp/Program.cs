namespace GeniyIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Здравствуйте! Как вас зовут?");
                string userName = Console.ReadLine();

                int questionsCount = 5;
                string[] questions = GetQuestions(questionsCount);
                int[] answers = GetAnswers(questionsCount);

                int correctAnswersCount = 0;

                Random random = new Random();
                for (int i = questionsCount - 1; i > 0; i--)
                {
                    int index = random.Next(0, i);
                    string tempQuestion = questions[index];
                    questions[index] = questions[i];
                    questions[i] = tempQuestion;

                    int tempAnswers = answers[index];
                    answers[index] = answers[i];
                    answers[i] = tempAnswers;
                }

                for (int i = 0; i < questionsCount; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    Console.WriteLine(questions[i]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());

                    int rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        correctAnswersCount++;
                    }
                }

                Console.WriteLine("Количество правильных ответов: " + correctAnswersCount);
                string[] diagnoses = GetDiagnoses();
                Console.WriteLine($"{userName}, Ваш диагноз:" + diagnoses[correctAnswersCount]);

                var userChoise = GetUserChoice("Хотите начать сначала?");
                if (!userChoise)
                {
                    break;
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

        static int[] GetAnswers(int questionCount)
        {
            int[] answers = new int[questionCount];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string[] GetQuestions(int questionCount)
        {
            string[] questions = new string[questionCount];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
    }
}