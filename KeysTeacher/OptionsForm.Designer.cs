namespace KeysTeacher
{
	partial class OptionsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numNoteOnVelocity = new System.Windows.Forms.NumericUpDown();
            this.ckbMidiThru = new System.Windows.Forms.CheckBox();
            this.numPassDelaySecs = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numFailDelaySecs = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numNoteOnVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPassDelaySecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFailDelaySecs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(584, 221);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 48);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(445, 221);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(130, 48);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Answer Note Velocity:";
            // 
            // numNoteOnVelocity
            // 
            this.numNoteOnVelocity.Location = new System.Drawing.Point(260, 122);
            this.numNoteOnVelocity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numNoteOnVelocity.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numNoteOnVelocity.Name = "numNoteOnVelocity";
            this.numNoteOnVelocity.Size = new System.Drawing.Size(81, 26);
            this.numNoteOnVelocity.TabIndex = 34;
            this.numNoteOnVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckbMidiThru
            // 
            this.ckbMidiThru.AutoSize = true;
            this.ckbMidiThru.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbMidiThru.Location = new System.Drawing.Point(170, 18);
            this.ckbMidiThru.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbMidiThru.Name = "ckbMidiThru";
            this.ckbMidiThru.Size = new System.Drawing.Size(103, 24);
            this.ckbMidiThru.TabIndex = 35;
            this.ckbMidiThru.Text = "Midi Thru:";
            this.ckbMidiThru.UseVisualStyleBackColor = true;
            // 
            // numPassDelaySecs
            // 
            this.numPassDelaySecs.Location = new System.Drawing.Point(260, 72);
            this.numPassDelaySecs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numPassDelaySecs.Name = "numPassDelaySecs";
            this.numPassDelaySecs.Size = new System.Drawing.Size(81, 26);
            this.numPassDelaySecs.TabIndex = 38;
            this.numPassDelaySecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Wait after a correct answer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "sec.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "sec.";
            // 
            // numFailDelaySecs
            // 
            this.numFailDelaySecs.Location = new System.Drawing.Point(596, 71);
            this.numFailDelaySecs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numFailDelaySecs.Name = "numFailDelaySecs";
            this.numFailDelaySecs.Size = new System.Drawing.Size(81, 26);
            this.numFailDelaySecs.TabIndex = 41;
            this.numFailDelaySecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Wait after a wrong answer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "Backup Folder:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBrowse.Location = new System.Drawing.Point(673, 167);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(41, 29);
            this.btnBrowse.TabIndex = 45;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtBackupFolder
            // 
            this.txtBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupFolder.Location = new System.Drawing.Point(258, 168);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(407, 26);
            this.txtBackupFolder.TabIndex = 46;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(747, 294);
            this.Controls.Add(this.txtBackupFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numFailDelaySecs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPassDelaySecs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckbMidiThru);
            this.Controls.Add(this.numNoteOnVelocity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numNoteOnVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPassDelaySecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFailDelaySecs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numNoteOnVelocity;
		private System.Windows.Forms.CheckBox ckbMidiThru;
		private System.Windows.Forms.NumericUpDown numPassDelaySecs;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numFailDelaySecs;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
    }
}