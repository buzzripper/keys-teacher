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
            this.lblQuestionTimeRemaining = new System.Windows.Forms.Label();
            this.lblExamTimeRemaining = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlayVoicing = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picResult = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTestName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.voicingSymbol1 = new KeysTeacher.VoicingSymbol();
            this.pianoControl1 = new KeysTeacher.Controls.PianoControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestionTimeRemaining
            // 
            this.lblQuestionTimeRemaining.AutoSize = true;
            this.lblQuestionTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionTimeRemaining.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblQuestionTimeRemaining.Location = new System.Drawing.Point(1, 22);
            this.lblQuestionTimeRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionTimeRemaining.Name = "lblQuestionTimeRemaining";
            this.lblQuestionTimeRemaining.Size = new System.Drawing.Size(97, 46);
            this.lblQuestionTimeRemaining.TabIndex = 16;
            this.lblQuestionTimeRemaining.Text = "3:00";
            this.lblQuestionTimeRemaining.Visible = false;
            // 
            // lblExamTimeRemaining
            // 
            this.lblExamTimeRemaining.AutoSize = true;
            this.lblExamTimeRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblExamTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamTimeRemaining.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblExamTimeRemaining.Location = new System.Drawing.Point(5, 4);
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
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Location = new System.Drawing.Point(1006, 444);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(231, 83);
            this.btnQuit.TabIndex = 22;
            this.btnQuit.Text = "I Quit!";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(12, 333);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1208, 0);
            this.panel1.TabIndex = 25;
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPause.Location = new System.Drawing.Point(253, 444);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(745, 83);
            this.btnPause.TabIndex = 28;
            this.btnPause.Text = "Pause";
            this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlayVoicing
            // 
            this.btnPlayVoicing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlayVoicing.Enabled = false;
            this.btnPlayVoicing.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayVoicing.Image")));
            this.btnPlayVoicing.Location = new System.Drawing.Point(17, 264);
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
            this.picResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picResult.Location = new System.Drawing.Point(664, 132);
            this.picResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(109, 101);
            this.picResult.TabIndex = 40;
            this.picResult.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMessage.Location = new System.Drawing.Point(285, 410);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(764, 29);
            this.lblMessage.TabIndex = 41;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // lblTestName
            // 
            this.lblTestName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTestName.BackColor = System.Drawing.Color.Transparent;
            this.lblTestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTestName.Location = new System.Drawing.Point(311, 13);
            this.lblTestName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(738, 36);
            this.lblTestName.TabIndex = 42;
            this.lblTestName.Text = "lblTestName";
            this.lblTestName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(10, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1233, 5);
            this.panel2.TabIndex = 55;
            // 
            // voicingSymbol1
            // 
            this.voicingSymbol1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.voicingSymbol1.Location = new System.Drawing.Point(473, 117);
            this.voicingSymbol1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.voicingSymbol1.Name = "voicingSymbol1";
            this.voicingSymbol1.Size = new System.Drawing.Size(160, 134);
            this.voicingSymbol1.TabIndex = 30;
            this.voicingSymbol1.Voicing = null;
            // 
            // pianoControl1
            // 
            this.pianoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pianoControl1.BassNoteOnColor = System.Drawing.Color.LightSteelBlue;
            this.pianoControl1.HighNoteID = 92;
            this.pianoControl1.Location = new System.Drawing.Point(90, 262);
            this.pianoControl1.LowNoteID = 28;
            this.pianoControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pianoControl1.Name = "pianoControl1";
            this.pianoControl1.NoteOnColor = System.Drawing.Color.DodgerBlue;
            this.pianoControl1.Size = new System.Drawing.Size(1147, 143);
            this.pianoControl1.StickyKeys = false;
            this.pianoControl1.TabIndex = 29;
            this.pianoControl1.Text = "pianoControl1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(228, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 56;
            this.label1.Text = "Exam:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(228, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 26);
            this.label2.TabIndex = 57;
            this.label2.Text = "Question:";
            this.label2.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNext.Location = new System.Drawing.Point(17, 444);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(228, 83);
            this.btnNext.TabIndex = 58;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // VoicingExamForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1255, 542);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.voicingSymbol1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.lblExamTimeRemaining);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblQuestionTimeRemaining);
            this.Controls.Add(this.btnPlayVoicing);
            this.Controls.Add(this.pianoControl1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuit);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VoicingExamForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voicing Test";
            this.Load += new System.EventHandler(this.VoicingExamForm_Load);
            this.Shown += new System.EventHandler(this.VoicingExamForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoicingExamForm_KeyDown);
            this.Resize += new System.EventHandler(this.VoicingExamForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblQuestionTimeRemaining;
		private System.Windows.Forms.Label lblExamTimeRemaining;
		private System.Windows.Forms.Button btnQuit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnPause;
		private Controls.PianoControl pianoControl1;
		private VoicingSymbol voicingSymbol1;
		private System.Windows.Forms.Button btnPlayVoicing;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.PictureBox picResult;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
    }
}