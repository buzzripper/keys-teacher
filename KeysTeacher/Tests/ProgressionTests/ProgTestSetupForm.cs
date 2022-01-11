using System;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class ProgTestSetupForm : Form
	{
		#region Fields

		#endregion

		#region Constructors

		public ProgTestSetupForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		public ProgTest Test { get; set; }

		public bool SaveFirst { get; set; }

		#endregion

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (ValidEntries()) {
				this.DialogResult = DialogResult.OK;
				Hide();
			}
		}

		private void btnRunNow_Click(object sender, EventArgs e)
		{
			if (ValidEntries()) {
				this.SaveFirst = ckbSaveFirst.Checked;
				this.DialogResult = DialogResult.Yes;
				Hide();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Hide();
		}

		#endregion

		#region Methods

		public DialogResult Run(IWin32Window owner, ProgTest test)
		{
			this.Test = test;

			// Populate
			txtName.Text = test.Name;
			txtDescription.Text = test.Description;
			numQuestionDuration.Value = test.QuestionDurationSecs;
			numTestDuration.Value = test.ExamDurationSecs;

			ckbIncludeAForms.Checked = test.IncludeAForm;
			ckbIncludeBForms.Checked = test.IncludeBForm;
			ckbIncludeOpenForms.Checked = test.IncludeOpenForm;
			ckbIncludeAABForms.Checked = test.IncludeAABForm;
			ckbIncludeBBAForms.Checked = test.IncludeBBAForm;

			DialogResult dialogResult = ShowDialog(owner);
			if (dialogResult == DialogResult.OK || dialogResult == DialogResult.Yes) {
				this.Test.Name = txtName.Text;
				this.Test.Description = txtDescription.Text;
				this.Test.QuestionDurationSecs = (int) numQuestionDuration.Value;
				this.Test.ExamDurationSecs = (int) numTestDuration.Value;

				test.IncludeAForm = ckbIncludeAForms.Checked;
				test.IncludeBForm = ckbIncludeBForms.Checked;
				test.IncludeOpenForm = ckbIncludeOpenForms.Checked;
				test.IncludeAABForm = ckbIncludeAABForms.Checked;
				test.IncludeBBAForm = ckbIncludeBBAForms.Checked;
			}

			return this.DialogResult;
		}

		private bool ValidEntries()
		{
			if (string.IsNullOrEmpty(txtName.Text)) {
				MessageBox.Show("You must enter a name.");
				txtName.Focus();
				return false;
			}
			if (!ckbIncludeAForms.Checked && ckbIncludeBForms.Checked && ckbIncludeOpenForms.Checked && ckbIncludeAABForms.Checked && ckbIncludeBBAForms.Checked) {
				MessageBox.Show("You must select at least 1 voicing form.");
				txtName.Focus();
				return false;
			}
			return true;
		}

		#endregion
	}
}