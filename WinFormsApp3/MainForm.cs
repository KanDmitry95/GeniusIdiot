using GeniyIdiotConsoleApp;
using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp3
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private User user;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionsStorage.GetAll();
            user = new User("Неизвестно");

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            questionTextLabel.Text = currentQuestion.Text;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = currentQuestion.Answer;
            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.RemoveAt(randomQuestionIndex);
        }
    }
}
