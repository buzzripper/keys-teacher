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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestionTimeLbl
            // 
            this.lblQuestionTimeLbl.AutoSize = true;
            this.lblQuestionTimeLbl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblQuestionTimeLbl.Location = new System.Drawing.Point(8, 14);
            this.lblQuestionTimeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionTimeLbl.Name = "lblQuestionTimeLbl";
            this.lblQuestionTimeLbl.Size = new System.Drawing.Size(184, 20);
            this.lblQuestionTimeLbl.TabIndex = 17;
            this.lblQuestionTimeLbl.Text = "Question time remaining:";
            this.lblQuestionTimeLbl.Visible = false;
            // 
            // lblQuestionTimeRemaining
            // 
            this.lblQuestionTimeRemaining.AutoSize = true;
            this.lblQuestionTimeRemaining.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblQuestionTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionTimeRemaining.Location = new System.Drawing.Point(1041, 14);
            this.lblQuestionTimeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionTimeRemaining.Name = "lblQuestionTimeRemaining";
            this.lblQuestionTimeRemaining.Size = new System.Drawing.Size(54, 26);
            this.lblQuestionTimeRemaining.TabIndex = 16;
            this.lblQuestionTimeRemaining.Text = "3:00";
            this.lblQuestionTimeRemaining.Visible = false;
            // 
            // lblExamTimeLbl
            // 
            this.lblExamTimeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExamTimeLbl.AutoSize = true;
            this.lblExamTimeLbl.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lblExamTimeLbl.Location = new System.Drawing.Point(150, 22);
            this.lblExamTimeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExamTimeLbl.Name = "lblExamTimeLbl";
            this.lblExamTimeLbl.Size = new System.Drawing.Size(151, 20);
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
            this.lblExamTimeRemaining.Location = new System.Drawing.Point(1124, 14);
            this.lblExamTimeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExamTimeRemaining.Name = "lblExamTimeRemaining";
            this.lblExamTimeRemaining.Size = new System.Drawing.Size(54, 26);
            this.lblExamTimeRemaining.TabIndex = 18;
            this.lblExamTimeRemaining.Text = "3:00";
            this.lblExamTimeRemaining.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Location = new System.Drawing.Point(1046, 397);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(132, 57);
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
            this.panel1.Location = new System.Drawing.Point(21, 377);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1149, 3);
            this.panel1.TabIndex = 25;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.Location = new System.Drawing.Point(18, 397);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(132, 57);
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
            this.btnResume.Location = new System.Drawing.Point(176, 397);
            this.btnResume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(134, 57);
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
            this.btnPlayVoicing.Location = new System.Drawing.Point(21, 208);
            this.btnPlayVoicing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlayVoicing.Name = "btnPlayVoicing";
            this.btnPlayVoicing.Size = new System.Drawing.Size(57, 54);
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
            this.picResult.Location = new System.Drawing.Point(780, 88);
            this.picResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(72, 74);
            this.picResult.TabIndex = 40;
            this.picResult.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Teal;
            this.lblMessage.Location = new System.Drawing.Point(332, 408);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(705, 35);
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
            this.lblTestName.Location = new System.Drawing.Point(268, 6);
            this.lblTestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(729, 43);
            this.lblTestName.TabIndex = 42;
            this.lblTestName.Text = "label1";
            this.lblTestName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTestName);
            this.panel2.Controls.Add(this.lblQuestionTimeRemaining);
            this.panel2.Controls.Add(this.lblExamTimeLbl);
            this.panel2.Controls.Add(this.lblExamTimeRemaining);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1196, 55);
            this.panel2.TabIndex = 43;
            // 
            // voicingSymbol1
            // 
            this.voicingSymbol1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.voicingSymbol1.Location = new System.Drawing.Point(528, 68);
            this.voicingSymbol1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.voicingSymbol1.Name = "voicingSymbol1";
            this.voicingSymbol1.Size = new System.Drawing.Size(188, 131);
            this.voicingSymbol1.TabIndex = 30;
            this.voicingSymbol1.Voicing = null;
            // 
            // pianoControl1
            // 
            this.pianoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pianoControl1.BassNoteOnColor = System.Drawing.Color.LightSteelBlue;
            this.pianoControl1.HighNoteID = 92;
            this.pianoControl1.Location = new System.Drawing.Point(90, 208);
            this.pianoControl1.LowNoteID = 28;
            this.pianoControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pianoControl1.Name = "pianoControl1";
            this.pianoControl1.NoteOnColor = System.Drawing.Color.DodgerBlue;
            this.pianoControl1.Size = new System.Drawing.Size(1095, 146);
            this.pianoControl1.StickyKeys = false;
            this.pianoControl1.TabIndex = 29;
            this.pianoControl1.Text = "pianoControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1098, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 26);
            this.label1.TabIndex = 43;
            this.label1.Text = "/";
            // 
            // VoicingExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 469);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.btnPlayVoicing);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.voicingSymbol1);
            this.Controls.Add(this.pianoControl1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblQuestionTimeLbl);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VoicingExamForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voicing Test";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoicingExamForm_KeyDown);
            this.Resize += new System.EventHandler(this.VoicingExamForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label label1;
    }
}