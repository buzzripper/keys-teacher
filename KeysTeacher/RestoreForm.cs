using System;
using System.Windows.Forms;

namespace KeysTeacher
{
    public partial class RestoreForm : Form
    {
        public RestoreForm()
        {
            InitializeComponent();
        }

        public string BackupFilepath => txtBackupFilepath.Text;
        public bool IncludeVoicingLibs => ckbIncludeVoicingLibs.Checked;
        public bool IncludeVoicingTests => ckbIncludeVoicingTests.Checked;
        public bool IncludeTestResults => ckbIncludeTestResults.Checked;
        public bool IncludeSettings => ckbIncludeSettings.Checked;

        public bool Run(IWin32Window owner, string initialDirectory)
        {
            openFileDlg.InitialDirectory = initialDirectory;
            return ShowDialog(owner) == DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK) {
                txtBackupFilepath.Text = openFileDlg.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBackupFilepath.Text)) {
                MessageBox.Show(this, $"Please supply a backup file path.", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ckbIncludeVoicingLibs.Checked && !ckbIncludeVoicingTests.Checked && !ckbIncludeTestResults.Checked && !ckbIncludeSettings.Checked) {
                MessageBox.Show(this, $"Please select at least one item to restore.", "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
