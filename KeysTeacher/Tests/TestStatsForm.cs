using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeysTeacher.Tests;

namespace KeysTeacher
{
	public partial class TestStatsForm : Form
	{
		public TestStatsForm()
		{
			InitializeComponent();
		}

		public void Run(List<TestResult> testResults, string testName)
		{
			int totQuestions = 0;
			int totCorrectAnswers = 0;

			foreach (TestResult testResult in testResults) {
				totQuestions += testResult.TotalQuestions;
				totCorrectAnswers += testResult.TotalCorrect;
				listBox1.Items.Add(string.Format("{0}: {1}/{2} ({3})", testResult.StartTime.Date.ToString("M/d/yy"), testResult.TotalCorrect, testResult.TotalQuestions, testResult.Score > -1 ? testResult.Score.ToString("0# %") : "n/a"));
			}

			lblTotQuestions.Text = totQuestions.ToString();
			lblTotCorrect.Text = totCorrectAnswers.ToString();
			if (totQuestions > 0)
				lblScore.Text = (totCorrectAnswers / (decimal) totQuestions).ToString("#0 %");
			else
				lblScore.Text = "n/a";

			ShowDialog();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}