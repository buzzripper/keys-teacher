namespace KeysTeacher.Tests.VoicingTests
{
	partial class VoicingExamForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoicingExamForm));
			this.lblQuestionTimeLbl = new System.Windows.Forms.Label();
			this.lblQuestionTimeRemaining = new System.Windows.Forms.Label();
			this.lblExamTimeLbl = new System.Windows.Forms.Label();
			this.lblExamTimeRemaining = new System.Windows.Forms.Label();
			this.btnQuit = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnResume = new System.Windows.Forms.Button();
			this.btnPlayVoicing = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.picResult = new System.Windows.Forms.PictureBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.lblTestName = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.voicingSymbol1 = new KeysTeacher.VoicingSymbol();
			this.pianoControl1 = new KeysTeacher.Controls.PianoControl();
			((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
			this.SuspendLayout();
			// 
			// lblQuestionTimeLbl
			// 
			this.lblQuestionTimeLbl.AutoSize = true;
			this.lblQuestionTimeLbl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.lblQuestionTimeLbl.Location = new System.Drawing.Point(5, 9);
			this.lblQuestionTimeLbl.Name = "lblQuestionTimeLbl";
			this.lblQuestionTimeLbl.Size = new System.Drawing.Size(122, 13);
			this.lblQuestionTimeLbl.TabIndex = 17;
			this.lblQuestionTimeLbl.Text = "Question time remaining:";
			this.lblQuestionTimeLbl.Visible = false;
			// 
			// lblQuestionTimeRemaining
			// 
			this.lblQuestionTimeRemaining.AutoSize = true;
			this.lblQuestionTimeRemaining.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.lblQuestionTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuestionTimeRemaining.Location = new System.Drawing.Point(125, 6);
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
			this.lblExamTimeLbl.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.lblExamTimeLbl.Location = new System.Drawing.Point(656, 11);
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
			this.lblExamTimeRemaining.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.lblExamTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExamTimeRemaining.Location = new System.Drawing.Point(754, 8);
			this.lblExamTimeRemaining.Name = "lblExamTimeRemaining";
			this.lblExamTimeRemaining.Size = new System.Drawing.Size(36, 18);
			this.lblExamTimeRemaining.TabIndex = 18;
			this.lblExamTimeRemaining.Text = "3:00";
			this.lblExamTimeRemaining.Visible = false;
			// 
			// btnQuit
			// 
			this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
			this.btnQuit.Location = new System.Drawing.Point(697, 258);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(88, 37);
			this.btnQuit.TabIndex = 22;
			this.btnQuit.Text = "I Quit!";
			this.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.Location = new System.Drawing.Point(14, 245);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(766, 2);
			this.panel1.TabIndex = 25;
			// 
			// btnPause
			// 
			this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
			this.btnPause.Location = new System.Drawing.Point(12, 258);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(88, 37);
			this.btnPause.TabIndex = 28;
			this.btnPause.Text = "  Pause";
			this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnPause.UseVisualStyleBackColor = true;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnResume
			// 
			this.btnResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnResume.Enabled = false;
			this.btnResume.Image = ((System.Drawing.Image)(resources.GetObject("btnResume.Image")));
			this.btnResume.Location = new System.Drawing.Point(117, 258);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(89, 37);
			this.btnResume.TabIndex = 31;
			this.btnResume.Text = "Resume";
			this.btnResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
			// 
			// btnPlayVoicing
			// 
			this.btnPlayVoicing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPlayVoicing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnPlayVoicing.Enabled = false;
			this.btnPlayVoicing.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayVoicing.Image")));
			this.btnPlayVoicing.Location = new System.Drawing.Point(14, 135);
			this.btnPlayVoicing.Name = "btnPlayVoicing";
			this.btnPlayVoicing.Size = new System.Drawing.Size(38, 35);
			this.btnPlayVoicing.TabIndex = 39;
			this.btnPlayVoicing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPlayVoicing.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnPlayVoicing.UseVisualStyleBackColor = true;
			this.btnPlayVoicing.Click += new System.EventHandler(this.btnPlayVoicing_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// picResult
			// 
			this.picResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.picResult.Location = new System.Drawing.Point(520, 57);
			this.picResult.Name = "picResult";
			this.picResult.Size = new System.Drawing.Size(48, 48);
			this.picResult.TabIndex = 40;
			this.picResult.TabStop = false;
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMessage.ForeColor = System.Drawing.Color.Teal;
			this.lblMessage.Location = new System.Drawing.Point(221, 265);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(470, 23);
			this.lblMessage.TabIndex = 41;
			this.lblMessage.Text = "lblMessage";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMessage.Visible = false;
			// 
			// lblTestName
			// 
			this.lblTestName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTestName.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.lblTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestName.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.lblTestName.Location = new System.Drawing.Point(166, 4);
			this.lblTestName.Name = "lblTestName";
			this.lblTestName.Size = new System.Drawing.Size(486, 28);
			this.lblTestName.TabIndex = 42;
			this.lblTestName.Text = "label1";
			this.lblTestName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(797, 36);
			this.panel2.TabIndex = 43;
			// 
			// voicingSymbol1
			// 
			this.voicingSymbol1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.voicingSymbol1.Location = new System.Drawing.Point(352, 44);
			this.voicingSymbol1.Name = "voicingSymbol1";
			this.voicingSymbol1.Size = new System.Drawing.Size(125, 85);
			this.voicingSymbol1.TabIndex = 30;
			this.voicingSymbol1.Voicing = null;
			// 
			// pianoControl1
			// 
			this.pianoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pianoControl1.BassNoteOnColor = System.Drawing.Color.LightSteelBlue;
			this.pianoControl1.HighNoteID = 92;
			this.pianoControl1.Location = new System.Drawing.Point(60, 135);
			this.pianoControl1.LowNoteID = 28;
			this.pianoControl1.Name = "pianoControl1";
			this.pianoControl1.NoteOnColor = System.Drawing.Color.DodgerBlue;
			this.pianoControl1.Size = new System.Drawing.Size(730, 95);
			this.pianoControl1.StickyKeys = false;
			this.pianoControl1.TabIndex = 29;
			this.pianoControl1.Text = "pianoControl1";
			// 
			// VoicingExamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(797, 305);
			this.Controls.Add(this.lblTestName);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.picResult);
			this.Controls.Add(this.btnPlayVoicing);
			this.Controls.Add(this.btnResume);
			this.Controls.Add(this.voicingSymbol1);
			this.Controls.Add(this.pianoControl1);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.lblExamTimeLbl);
			this.Controls.Add(this.lblExamTimeRemaining);
			this.Controls.Add(this.lblQuestionTimeLbl);
			this.Controls.Add(this.lblQuestionTimeRemaining);
			this.Controls.Add(this.panel2);
			this.ForeColor = System.Drawing.Color.Navy;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.Name = "VoicingExamForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Voicing Test";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoicingExamForm_KeyDown);
			this.Resize += new System.EventHandler(this.VoicingExamForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblQuestionTimeLbl;
		private System.Windows.Forms.Label lblQuestionTimeRemaining;
		private System.Windows.Forms.Label lblExamTimeLbl;
		private System.Windows.Forms.Label lblExamTimeRemaining;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPause;
		private Controls.PianoControl pianoControl1;
		private VoicingSymbol voicingSymbol1;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.Button btnPlayVoicing;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox picResult;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Label lblTestName;
		private System.Windows.Forms.Panel panel2;
	}
}