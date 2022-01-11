namespace KeysTeacher.Tests.ProgressionTests
{
	partial class ProgExamForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgExamForm));
			this.lblQuestionTimeLbl = new System.Windows.Forms.Label();
			this.lblQuestionTimeRemaining = new System.Windows.Forms.Label();
			this.lblExamTimeLbl = new System.Windows.Forms.Label();
			this.lblExamTimeRemaining = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblMessage = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblForm = new System.Windows.Forms.Label();
			this.btnResume = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.voicingCtl2 = new KeysTeacher.VoicingExamCtl();
			this.voicingCtl1 = new KeysTeacher.VoicingExamCtl();
			this.voicingCtl0 = new KeysTeacher.VoicingExamCtl();
			this.keySymbol1 = new KeysTeacher.KeySymbol();
			this.SuspendLayout();
			// 
			// lblQuestionTimeLbl
			// 
			this.lblQuestionTimeLbl.AutoSize = true;
			this.lblQuestionTimeLbl.Location = new System.Drawing.Point(6, 6);
			this.lblQuestionTimeLbl.Name = "lblQuestionTimeLbl";
			this.lblQuestionTimeLbl.Size = new System.Drawing.Size(122, 13);
			this.lblQuestionTimeLbl.TabIndex = 17;
			this.lblQuestionTimeLbl.Text = "Question time remaining:";
			this.lblQuestionTimeLbl.Visible = false;
			// 
			// lblQuestionTimeRemaining
			// 
			this.lblQuestionTimeRemaining.AutoSize = true;
			this.lblQuestionTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuestionTimeRemaining.Location = new System.Drawing.Point(126, 3);
			this.lblQuestionTimeRemaining.Name = "lblQuestionTimeRemaining";
			this.lblQuestionTimeRemaining.Size = new System.Drawing.Size(36, 18);
			this.lblQuestionTimeRemaining.TabIndex = 16;
			this.lblQuestionTimeRemaining.Text = "3:00";
			this.lblQuestionTimeRemaining.Visible = false;
			// 
			// lblExamTimeLbl
			// 
			this.lblExamTimeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblExamTimeLbl.AutoSize = true;
			this.lblExamTimeLbl.Location = new System.Drawing.Point(755, 7);
			this.lblExamTimeLbl.Name = "lblExamTimeLbl";
			this.lblExamTimeLbl.Size = new System.Drawing.Size(101, 13);
			this.lblExamTimeLbl.TabIndex = 19;
			this.lblExamTimeLbl.Text = "Test time remaining:";
			this.lblExamTimeLbl.Visible = false;
			// 
			// lblExamTimeRemaining
			// 
			this.lblExamTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblExamTimeRemaining.AutoSize = true;
			this.lblExamTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExamTimeRemaining.Location = new System.Drawing.Point(853, 4);
			this.lblExamTimeRemaining.Name = "lblExamTimeRemaining";
			this.lblExamTimeRemaining.Size = new System.Drawing.Size(36, 18);
			this.lblExamTimeRemaining.TabIndex = 18;
			this.lblExamTimeRemaining.Text = "3:00";
			this.lblExamTimeRemaining.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.ForeColor = System.Drawing.Color.Teal;
			this.lblMessage.Location = new System.Drawing.Point(250, 406);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(489, 28);
			this.lblMessage.TabIndex = 41;
			this.lblMessage.Text = "lblMessage";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMessage.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.LightGray;
			this.panel2.Location = new System.Drawing.Point(13, 390);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(863, 2);
			this.panel2.TabIndex = 45;
			// 
			// lblForm
			// 
			this.lblForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForm.AutoSize = true;
			this.lblForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblForm.Location = new System.Drawing.Point(484, 33);
			this.lblForm.Name = "lblForm";
			this.lblForm.Size = new System.Drawing.Size(79, 28);
			this.lblForm.TabIndex = 47;
			this.lblForm.Text = "A form";
			// 
			// btnResume
			// 
			this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnResume.Enabled = false;
			this.btnResume.Image = ((System.Drawing.Image)(resources.GetObject("btnResume.Image")));
			this.btnResume.Location = new System.Drawing.Point(106, 402);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(89, 37);
			this.btnResume.TabIndex = 31;
			this.btnResume.Text = "Resume";
			this.btnResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
			// 
			// btnPause
			// 
			this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
			this.btnPause.Location = new System.Drawing.Point(12, 402);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(88, 37);
			this.btnPause.TabIndex = 28;
			this.btnPause.Text = "  Pause";
			this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
			this.btnQuit.Location = new System.Drawing.Point(791, 402);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(88, 37);
			this.btnQuit.TabIndex = 22;
			this.btnQuit.Text = "I Quit!";
			this.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// voicingCtl2
			// 
			this.voicingCtl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.voicingCtl2.Location = new System.Drawing.Point(12, 289);
			this.voicingCtl2.Name = "voicingCtl2";
			this.voicingCtl2.PlayButtonEnabled = true;
			this.voicingCtl2.Size = new System.Drawing.Size(877, 86);
			this.voicingCtl2.SymbolVisible = true;
			this.voicingCtl2.TabIndex = 44;
			this.voicingCtl2.Visible = false;
			// 
			// voicingCtl1
			// 
			this.voicingCtl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.voicingCtl1.Location = new System.Drawing.Point(12, 192);
			this.voicingCtl1.Name = "voicingCtl1";
			this.voicingCtl1.PlayButtonEnabled = true;
			this.voicingCtl1.Size = new System.Drawing.Size(877, 86);
			this.voicingCtl1.SymbolVisible = true;
			this.voicingCtl1.TabIndex = 43;
			this.voicingCtl1.Visible = false;
			// 
			// voicingCtl0
			// 
			this.voicingCtl0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.voicingCtl0.Location = new System.Drawing.Point(12, 95);
			this.voicingCtl0.Name = "voicingCtl0";
			this.voicingCtl0.PlayButtonEnabled = true;
			this.voicingCtl0.Size = new System.Drawing.Size(877, 86);
			this.voicingCtl0.SymbolVisible = true;
			this.voicingCtl0.TabIndex = 42;
			// 
			// keySymbol1
			// 
			this.keySymbol1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.keySymbol1.BackColor = System.Drawing.SystemColors.Control;
			this.keySymbol1.Location = new System.Drawing.Point(378, 12);
			this.keySymbol1.Name = "keySymbol1";
			this.keySymbol1.Size = new System.Drawing.Size(89, 67);
			this.keySymbol1.TabIndex = 48;
			// 
			// ProgExamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(891, 447);
			this.Controls.Add(this.keySymbol1);
			this.Controls.Add(this.lblForm);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.voicingCtl2);
			this.Controls.Add(this.voicingCtl1);
			this.Controls.Add(this.voicingCtl0);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.btnResume);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.lblExamTimeLbl);
			this.Controls.Add(this.lblExamTimeRemaining);
			this.Controls.Add(this.lblQuestionTimeLbl);
			this.Controls.Add(this.lblQuestionTimeRemaining);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.Name = "ProgExamForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Voicing Test";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoicingExamForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblQuestionTimeLbl;
		private System.Windows.Forms.Label lblQuestionTimeRemaining;
		private System.Windows.Forms.Label lblExamTimeLbl;
		private System.Windows.Forms.Label lblExamTimeRemaining;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lblMessage;
		private VoicingExamCtl voicingCtl0;
		private VoicingExamCtl voicingCtl1;
		private VoicingExamCtl voicingCtl2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblForm;
		private KeySymbol keySymbol1;
	}
}