using System;
using System.Windows.Forms;
using KeysTeacher.Tests.VoicingLibs;

namespace KeysTeacher.Tests.VoicingTests
{
	public partial class VoicingTestResultsForm : Form, IVoicingTestResultsForm
	{
		#region Fields

		private bool _saveResults;

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingTestResultsForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		public bool Run(TestResult testResult, VoicingTest test)
		{
			lblName.Text = test.Name;
			lblQuestionCount.Text = testResult.TotalQuestions.ToString();
			lblCorrect.Text = testResult.TotalCorrect.ToString();
			lblScore.Text = testResult.Score.ToString("#0 %");

			ShowDialog();

			testResult.AddWrongAnswersToErrorsTest = ckbAddWrongAnswers.Checked;

			return _saveResults;
		}

		private void btnSaveResults_Click(object sender, EventArgs e)
		{
			_saveResults = true;
			Hide();
		}

		private void btnDiscardResults_Click(object sender, EventArgs e)
		{
			Hide();
		}

		#endregion
	}
}