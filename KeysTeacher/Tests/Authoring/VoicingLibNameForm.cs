using System;
using System.Windows.Forms;
using KeysTeacher.Data;
using KeysTeacher.Misc;

namespace KeysTeacher.Tests.Authoring
{
	public partial class VoicingLibNameForm : Form, IVoicingLibNameForm
	{
		#region Fields

		private readonly IVoicingLibRepository _voicingLibRepository;
		private readonly IMsgBox _msgBox;
		
		#endregion

		public VoicingLibNameForm(IMsgBox msgBox, IVoicingLibRepository voicingLibRepository)
		{
			_msgBox = msgBox;
			_voicingLibRepository = voicingLibRepository;
			InitializeComponent();
		}

		public DialogResult Run(string name)
		{
			txtName.Text = name;
			txtName.SelectAll();
			txtName.Focus();

			return ShowDialog();
		}

		public string LibName => txtName.Text;

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!ValidEntries())
				return;

			this.DialogResult = DialogResult.OK;
			Hide();
		}

		private bool ValidEntries()
		{
			if (string.IsNullOrWhiteSpace(txtName.Text)) {
				_msgBox.ShowError("You must enter a library name.", "Input Error");
				txtName.Focus();
				return false;
			}

			string name = txtName.Text.Trim();

			if (_voicingLibRepository.NameExists(name)) {
				_msgBox.ShowError("A library with this name already exists. Try another.", "Input Error");
				txtName.Focus();
				return false;
			}

			return true;
		}
	}
}