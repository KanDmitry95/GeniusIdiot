using GeniusIdiot.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GeniusIdiotWinFormsApp
{
    public partial class MainForm : Form
    {
        User user;
        List<Question> questions;
        Question currentQuestion;
        int questionNumer = 1;
        int countQuestion;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
            user = new User(welcomeForm.userNameTextBox.Text);

            questions = QuestionsStorage.GetAll();
            countQuestion = questions.Count;
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            questionTextLabel.Text = currentQuestion.Text;

            questionNumberLabel.Text = "Вопрос №" + questionNumer;
            questionNumer++;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);

            var rightAnswer = currentQuestion.Answer;
            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.Remove(currentQuestion);

            if (questions.Count == 0)
            {
                var diagnose = DiagnoseCalculator.Calculate(countQuestion, user.CountRightAnswers);
                user.Diagnose = diagnose;

                UsersResultStorage.Save(user);

                var message = user.Name + ", Ваш диагноз: " + diagnose;
                MessageBox.Show(message);
            }
            else
            {
                ShowNextQuestion();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void показатьПредыдущийРезультатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }
    }
}
