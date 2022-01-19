using System;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			InitializeComponent();
		}

		private AppData _appData;

		public bool Run(IWin32Window owner, AppData appData)
		{
			_appData = appData;

			ckbMidiThru.Checked = appData.MidiThru;
			numPassDelaySecs.Value = appData.CorrectAnswerWaitSecs;
			numFailDelaySecs.Value = appData.WrongAnswerWaitSecs;
			numNoteOnVelocity.Value = appData.NoteOnVelocity;
			txtBackupFolder.Text = appData.BackupFolder;

			return ShowDialog(owner) == DialogResult.OK;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			_appData.MidiThru = ckbMidiThru.Checked;
			_appData.CorrectAnswerWaitSecs = (int)numPassDelaySecs.Value;
			_appData.WrongAnswerWaitSecs = (int)numFailDelaySecs.Value;
			_appData.NoteOnVelocity = (int)numNoteOnVelocity.Value;
			_appData.BackupFolder = folderBrowserDlg.SelectedPath;

			this.DialogResult = DialogResult.OK;
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}