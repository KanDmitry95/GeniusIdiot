namespace GeniyIdiotConsoleApp
{
    public class User
    {
        public string Name { get; set; }
        public int CountRightAnswers { get; set; }
        public string Diagnose { get; set; }
        public User(string name)
        {
            Name = name;
            Diagnose = "Неизвестно";
        }

        public void AcceptRightAnswer()
        {
            CountRightAnswers++;
        }
    }
}