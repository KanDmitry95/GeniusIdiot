using System;
using System.Collections.Generic;
using System.Text;

namespace GeniusIdiot.Common
{
    public class DiagnoseCalculator
    {
        public static string Calculate(int questionsCount, int correctAnswersCount)
        {
            var diagnoses = GetDiagnoses();
            var percentRightAnswer = correctAnswersCount * 100 / questionsCount;

            return diagnoses[percentRightAnswer / 20];
        }

        public static string[] GetDiagnoses()
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
        }
    }
}
