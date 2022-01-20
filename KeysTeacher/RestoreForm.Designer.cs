namespace KeysTeacher
{
    partial class RestoreForm
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
            if (disposing && (components != null)) {
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
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.ckbIncludeSettings = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtBackupFilepath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ckbIncludeVoicingLibs = new System.Windows.Forms.CheckBox();
            this.ckbIncludeVoicingTests = new System.Windows.Forms.CheckBox();
            this.ckbIncludeTestResults = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDlg
            // 
            this.openFileDlg.DefaultExt = "ktb";
            this.openFileDlg.Filter = "Backup files|*.ktb|All files|*.*";
            // 
            // ckbIncludeSettings
            // 
            this.ckbIncludeSettings.AutoSize = true;
            this.ckbIncludeSettings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbIncludeSettings.Location = new System.Drawing.Point(268, 208);
            this.ckbIncludeSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbIncludeSettings.Name = "ckbIncludeSettings";
            this.ckbIncludeSettings.Size = new System.Drawing.Size(154, 24);
            this.ckbIncludeSettings.TabIndex = 39;
            this.ckbIncludeSettings.Text = "Include Settings:";
            this.ckbIncludeSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Select Backup File";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(615, 216);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 48);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(462, 216);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 48);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBackupFilepath
            // 
            this.txtBackupFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupFilepath.Location = new System.Drawing.Point(33, 57);
            this.txtBackupFilepath.Name = "txtBackupFilepath";
            this.txtBackupFilepath.Size = new System.Drawing.Size(673, 26);
            this.txtBackupFilepath.TabIndex = 40;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(713, 54);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(32, 32);
            this.btnBrowse.TabIndex = 41;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ckbIncludeVoicingLibs
            // 
            this.ckbIncludeVoicingLibs.AutoSize = true;
            this.ckbIncludeVoicingLibs.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbIncludeVoicingLibs.Checked = true;
            this.ckbIncludeVoicingLibs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIncludeVoicingLibs.Location = new System.Drawing.Point(211, 106);
            this.ckbIncludeVoicingLibs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbIncludeVoicingLibs.Name = "ckbIncludeVoicingLibs";
            this.ckbIncludeVoicingLibs.Size = new System.Drawing.Size(211, 24);
            this.ckbIncludeVoicingLibs.TabIndex = 42;
            this.ckbIncludeVoicingLibs.Text = "Include Voicing Libraries:";
            this.ckbIncludeVoicingLibs.UseVisualStyleBackColor = true;
            // 
            // ckbIncludeVoicingTests
            // 
            this.ckbIncludeVoicingTests.AutoSize = true;
            this.ckbIncludeVoicingTests.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbIncludeVoicingTests.Checked = true;
            this.ckbIncludeVoicingTests.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIncludeVoicingTests.Location = new System.Drawing.Point(231, 140);
            this.ckbIncludeVoicingTests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbIncludeVoicingTests.Name = "ckbIncludeVoicingTests";
            this.ckbIncludeVoicingTests.Size = new System.Drawing.Size(191, 24);
            this.ckbIncludeVoicingTests.TabIndex = 43;
            this.ckbIncludeVoicingTests.Text = "Include Voiding Tests:";
            this.ckbIncludeVoicingTests.UseVisualStyleBackColor = true;
            // 
            // ckbIncludeTestResults
            // 
            this.ckbIncludeTestResults.AutoSize = true;
            this.ckbIncludeTestResults.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbIncludeTestResults.Checked = true;
            this.ckbIncludeTestResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIncludeTestResults.Location = new System.Drawing.Point(238, 174);
            this.ckbIncludeTestResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbIncludeTestResults.Name = "ckbIncludeTestResults";
            this.ckbIncludeTestResults.Size = new System.Drawing.Size(184, 24);
            this.ckbIncludeTestResults.TabIndex = 44;
            this.ckbIncludeTestResults.Text = "Include Test Results:";
            this.ckbIncludeTestResults.UseVisualStyleBackColor = true;
            // 
            // RestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 290);
            this.ControlBox = false;
            this.Controls.Add(this.ckbIncludeTestResults);
            this.Controls.Add(this.ckbIncludeVoicingTests);
            this.Controls.Add(this.ckbIncludeVoicingLibs);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtBackupFilepath);
            this.Controls.Add(this.ckbIncludeSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "RestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.CheckBox ckbIncludeSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtBackupFilepath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox ckbIncludeVoicingLibs;
        private System.Windows.Forms.CheckBox ckbIncludeVoicingTests;
        private System.Windows.Forms.CheckBox ckbIncludeTestResults;
    }
}