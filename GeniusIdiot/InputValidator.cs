using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusIdiot
{
    public class InputValidator
    {
        public static bool TryParseToNumber(string input, out int number, out string errorMessage)
        {
            try
            {
                number = int.Parse(input);
                errorMessage = "";
                return true;
            }
            catch (FormatException)
            {
                errorMessage = "Введите число!";
                number = 0;
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "Введите число от -2*10^9 до 2*10^9 !";
                number = 0; 
                return false;
            }
        }
    }
}
