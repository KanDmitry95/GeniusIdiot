using System.Text;

namespace GeniyIdiotConsoleApp
{
    public class UsersResultStorage
    {
        public static void Save(User user)
        {
            string value = $"{user.Name}#{user.CountRightAnswers}#{user.Diagnose}";
            FileProvider.Append("userResault.txt", value);
        }

        public static List<User> GetUserResult()
        {
            var value = FileProvider.GetValue("userResault.txt");
            var lines = value.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var result = new List<User>();
            foreach(var line in lines)
            {
                var values = line.Split('#');
                var name = values[0];
                var countRightAnswer = Convert.ToInt32(values[1]);
                var diagnose = values[2];

                var user = new User(name);
                user.CountRightAnswers = countRightAnswer;
                user.Diagnose = diagnose;

                result.Add(user);
            }

            return result;
        }
    }
}