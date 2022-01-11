namespace KeysTeacher.Tests.VoicingTests
{
	partial class VoicingTestResultsForm
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
			this.btnDiscardResults = new System.Windows.Forms.Button();
			this.btnSaveResults = new System.Windows.Forms.Button();
			this.lblScore = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCorrect = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblQuestionCount = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.ckbAddWrongAnswers = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnDiscardResults
			// 
			this.btnDiscardResults.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDiscardResults.Location = new System.Drawing.Point(151, 167);
			this.btnDiscardResults.Name = "btnDiscardResults";
			this.btnDiscardResults.Size = new System.Drawing.Size(98, 28);
			this.btnDiscardResults.TabIndex = 31;
			this.btnDiscardResults.Text = "Discard Results";
			this.btnDiscardResults.UseVisualStyleBackColor = true;
			this.btnDiscardResults.Click += new System.EventHandler(this.btnDiscardResults_Click);
			// 
			// btnSaveResults
			// 
			this.btnSaveResults.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSaveResults.Location = new System.Drawing.Point(38, 167);
			this.btnSaveResults.Name = "btnSaveResults";
			this.btnSaveResults.Size = new System.Drawing.Size(98, 28);
			this.btnSaveResults.TabIndex = 30;
			this.btnSaveResults.Text = "Save Results";
			this.btnSaveResults.UseVisualStyleBackColor = true;
			this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScore.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblScore.Location = new System.Drawing.Point(137, 96);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(74, 19);
			this.lblScore.TabIndex = 29;
			this.lblScore.Text = "lblScore";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(88, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 14);
			this.label5.TabIndex = 28;
			this.label5.Text = "Score:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(40, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 17);
			this.label3.TabIndex = 27;
			this.label3.Text = "Total correct:";
			// 
			// lblCorrect
			// 
			this.lblCorrect.AutoSize = true;
			this.lblCorrect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCorrect.Location = new System.Drawing.Point(138, 68);
			this.lblCorrect.Name = "lblCorrect";
			this.lblCorrect.Size = new System.Drawing.Size(66, 17);
			this.lblCorrect.TabIndex = 26;
			this.lblCorrect.Text = "lblCorrect";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(26, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 17);
			this.label2.TabIndex = 25;
			this.label2.Text = "Total questions:";
			// 
			// lblQuestionCount
			// 
			this.lblQuestionCount.AutoSize = true;
			this.lblQuestionCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblQuestionCount.Location = new System.Drawing.Point(138, 44);
			this.lblQuestionCount.Name = "lblQuestionCount";
			this.lblQuestionCount.Size = new System.Drawing.Size(112, 17);
			this.lblQuestionCount.TabIndex = 24;
			this.lblQuestionCount.Text = "lblQuestionCount";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(54, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 17);
			this.label1.TabIndex = 23;
			this.label1.Text = "Test name:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblName.Location = new System.Drawing.Point(138, 20);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(55, 17);
			this.lblName.TabIndex = 22;
			this.lblName.Text = "lblName";
			// 
			// ckbAddWrongAnswers
			// 
			this.ckbAddWrongAnswers.AutoSize = true;
			this.ckbAddWrongAnswers.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ckbAddWrongAnswers.Location = new System.Drawing.Point(32, 129);
			this.ckbAddWrongAnswers.Name = "ckbAddWrongAnswers";
			this.ckbAddWrongAnswers.Size = new System.Drawing.Size(232, 21);
			this.ckbAddWrongAnswers.TabIndex = 32;
			this.ckbAddWrongAnswers.Text = "Add wrong answers to Errors test";
			this.ckbAddWrongAnswers.UseVisualStyleBackColor = true;
			// 
			// VoicingTestResultsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 211);
			this.ControlBox = false;
			this.Controls.Add(this.ckbAddWrongAnswers);
			this.Controls.Add(this.btnDiscardResults);
			this.Controls.Add(this.btnSaveResults);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblCorrect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblQuestionCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VoicingTestResultsForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Test Results";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnDiscardResults;
		private System.Windows.Forms.Button btnSaveResults;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblCorrect;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblQuestionCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.CheckBox ckbAddWrongAnswers;
	}
}