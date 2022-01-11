namespace KeysTeacher
{
	partial class TestStatsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
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
		private void InitializeComponent() {
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblScore = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTotQuestions = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotCorrect = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(11, 107);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(199, 121);
			this.listBox1.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOk.Location = new System.Drawing.Point(83, 248);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(60, 27);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblScore
			// 
			this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblScore.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScore.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblScore.Location = new System.Drawing.Point(70, 72);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(74, 19);
			this.lblScore.TabIndex = 31;
			this.lblScore.Text = "lblScore";
			this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(64, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 14);
			this.label5.TabIndex = 30;
			this.label5.Text = "Average Score:";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 14);
			this.label1.TabIndex = 32;
			this.label1.Text = "Total Questions:";
			// 
			// lblTotQuestions
			// 
			this.lblTotQuestions.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblTotQuestions.AutoSize = true;
			this.lblTotQuestions.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotQuestions.Location = new System.Drawing.Point(111, 9);
			this.lblTotQuestions.Name = "lblTotQuestions";
			this.lblTotQuestions.Size = new System.Drawing.Size(92, 14);
			this.lblTotQuestions.TabIndex = 33;
			this.lblTotQuestions.Text = "lblTotQuestions";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(28, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 14);
			this.label2.TabIndex = 35;
			this.label2.Text = "Total Correct:";
			// 
			// lblTotCorrect
			// 
			this.lblTotCorrect.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblTotCorrect.AutoSize = true;
			this.lblTotCorrect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotCorrect.Location = new System.Drawing.Point(111, 28);
			this.lblTotCorrect.Name = "lblTotCorrect";
			this.lblTotCorrect.Size = new System.Drawing.Size(78, 14);
			this.lblTotCorrect.TabIndex = 34;
			this.lblTotCorrect.Text = "lblTotCorrect";
			// 
			// TestStatsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 285);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblTotCorrect);
			this.Controls.Add(this.lblTotQuestions);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "TestStatsForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Test History";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblTotQuestions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotCorrect;
	}
}