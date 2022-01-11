namespace KeysTeacher.Tests.VoicingTests
{
	partial class VoicingTestEditor
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lbxVoicings = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnVoicingLibarary = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.numQuestionDuration = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.numExamDuration = new System.Windows.Forms.NumericUpDown();
			this.ckbInclBassNote = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numQuestionDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numExamDuration)).BeginInit();
			this.SuspendLayout();
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(249, 74);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(87, 31);
			this.btnEdit.TabIndex = 30;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(249, 112);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(87, 31);
			this.btnDelete.TabIndex = 26;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(249, 36);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(87, 31);
			this.btnAdd.TabIndex = 25;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lbxVoicings
			// 
			this.lbxVoicings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxVoicings.FormattingEnabled = true;
			this.lbxVoicings.IntegralHeight = false;
			this.lbxVoicings.Location = new System.Drawing.Point(14, 139);
			this.lbxVoicings.Name = "lbxVoicings";
			this.lbxVoicings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbxVoicings.Size = new System.Drawing.Size(223, 215);
			this.lbxVoicings.TabIndex = 24;
			this.lbxVoicings.SelectedIndexChanged += new System.EventHandler(this.lbxVoicings_SelectedIndexChanged);
			this.lbxVoicings.DoubleClick += new System.EventHandler(this.lbxVoicings_DoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(17, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 18);
			this.label1.TabIndex = 45;
			this.label1.Text = "Voicing Test Setup";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(65, 34);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(172, 20);
			this.txtName.TabIndex = 46;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(22, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 14);
			this.label2.TabIndex = 47;
			this.label2.Text = "Name:";
			// 
			// btnVoicingLibarary
			// 
			this.btnVoicingLibarary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVoicingLibarary.Location = new System.Drawing.Point(249, 158);
			this.btnVoicingLibarary.Name = "btnVoicingLibarary";
			this.btnVoicingLibarary.Size = new System.Drawing.Size(87, 37);
			this.btnVoicingLibarary.TabIndex = 48;
			this.btnVoicingLibarary.Text = "Voicing Libarary";
			this.btnVoicingLibarary.UseVisualStyleBackColor = true;
			this.btnVoicingLibarary.Click += new System.EventHandler(this.btnVoicingLibarary_Click);
			// 
			// btnDone
			// 
			this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDone.Location = new System.Drawing.Point(249, 289);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(87, 31);
			this.btnDone.TabIndex = 49;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// numQuestionDuration
			// 
			this.numQuestionDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numQuestionDuration.Location = new System.Drawing.Point(132, 62);
			this.numQuestionDuration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numQuestionDuration.Name = "numQuestionDuration";
			this.numQuestionDuration.Size = new System.Drawing.Size(47, 20);
			this.numQuestionDuration.TabIndex = 50;
			this.numQuestionDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(22, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 14);
			this.label3.TabIndex = 51;
			this.label3.Text = "Question Duration:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(179, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 14);
			this.label4.TabIndex = 52;
			this.label4.Text = "sec";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(179, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 14);
			this.label5.TabIndex = 55;
			this.label5.Text = "sec";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(43, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 14);
			this.label6.TabIndex = 54;
			this.label6.Text = "Exam Duration:";
			// 
			// numExamDuration
			// 
			this.numExamDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numExamDuration.Location = new System.Drawing.Point(132, 87);
			this.numExamDuration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numExamDuration.Name = "numExamDuration";
			this.numExamDuration.Size = new System.Drawing.Size(47, 20);
			this.numExamDuration.TabIndex = 53;
			this.numExamDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ckbInclBassNote
			// 
			this.ckbInclBassNote.AutoSize = true;
			this.ckbInclBassNote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ckbInclBassNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ckbInclBassNote.Location = new System.Drawing.Point(66, 116);
			this.ckbInclBassNote.Name = "ckbInclBassNote";
			this.ckbInclBassNote.Size = new System.Drawing.Size(124, 18);
			this.ckbInclBassNote.TabIndex = 56;
			this.ckbInclBassNote.Text = "Include Bass Note";
			this.ckbInclBassNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ckbInclBassNote.UseVisualStyleBackColor = true;
			// 
			// VoicingTestEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ckbInclBassNote);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numExamDuration);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numQuestionDuration);
			this.Controls.Add(this.btnDone);
			this.Controls.Add(this.btnVoicingLibarary);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbxVoicings);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Name = "VoicingTestEditor";
			this.Size = new System.Drawing.Size(349, 362);
			((System.ComponentModel.ISupportInitialize)(this.numQuestionDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numExamDuration)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox lbxVoicings;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnVoicingLibarary;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.NumericUpDown numQuestionDuration;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numExamDuration;
		private System.Windows.Forms.CheckBox ckbInclBassNote;
	}
}
