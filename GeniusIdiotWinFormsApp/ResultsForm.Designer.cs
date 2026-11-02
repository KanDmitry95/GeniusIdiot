namespace GeniusIdiotWinFormsApp
{
    partial class ResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultsDataGridView = new DataGridView();
            UserNameColumn = new DataGridViewTextBoxColumn();
            CountRightAnswersColumn = new DataGridViewTextBoxColumn();
            DiagnosColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { UserNameColumn, CountRightAnswersColumn, DiagnosColumn });
            resultsDataGridView.Location = new Point(12, 12);
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.Size = new Size(352, 329);
            resultsDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            UserNameColumn.HeaderText = "Имя";
            UserNameColumn.Name = "UserNameColumn";
            // 
            // CountRightAnswersColumn
            // 
            CountRightAnswersColumn.HeaderText = "Кол-во правильных ответов";
            CountRightAnswersColumn.Name = "CountRightAnswersColumn";
            // 
            // DiagnosColumn
            // 
            DiagnosColumn.HeaderText = "Диагноз";
            DiagnosColumn.Name = "DiagnosColumn";
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 354);
            Controls.Add(resultsDataGridView);
            Name = "ResultsForm";
            Text = "ResultsForm";
            Load += ResultsForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn UserNameColumn;
        private DataGridViewTextBoxColumn CountRightAnswersColumn;
        private DataGridViewTextBoxColumn DiagnosColumn;
    }
}