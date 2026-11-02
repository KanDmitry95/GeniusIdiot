using GeniusIdiot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeniusIdiotWinFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            var results = UsersResultStorage.GetUserResult();
            foreach (var result in results)
            {
                resultsDataGridView.Rows.Add(result.Name, result.CountRightAnswers, result.Diagnose);
            }
        }
    }
}
