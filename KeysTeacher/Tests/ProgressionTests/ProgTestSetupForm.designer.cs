namespace KeysTeacher
{
	partial class ProgTestSetupForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgTestSetupForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.numTestDuration = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.numQuestionDuration = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnRunNow = new System.Windows.Forms.Button();
			this.ckbSaveFirst = new System.Windows.Forms.CheckBox();
			this.ckbIncludeBBAForms = new System.Windows.Forms.CheckBox();
			this.ckbIncludeAABForms = new System.Windows.Forms.CheckBox();
			this.ckbIncludeOpenForms = new System.Windows.Forms.CheckBox();
			this.ckbIncludeBForms = new System.Windows.Forms.CheckBox();
			this.ckbIncludeAForms = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numTestDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numQuestionDuration)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(67, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(114, 12);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(194, 20);
			this.txtName.TabIndex = 0;
			// 
			// numTestDuration
			// 
			this.numTestDuration.Location = new System.Drawing.Point(115, 99);
			this.numTestDuration.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.numTestDuration.Name = "numTestDuration";
			this.numTestDuration.Size = new System.Drawing.Size(50, 20);
			this.numTestDuration.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(34, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Test Duration:";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(83, 277);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(63, 26);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(172, 277);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(63, 26);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// numQuestionDuration
			// 
			this.numQuestionDuration.Location = new System.Drawing.Point(115, 123);
			this.numQuestionDuration.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
			this.numQuestionDuration.Name = "numQuestionDuration";
			this.numQuestionDuration.Size = new System.Drawing.Size(50, 20);
			this.numQuestionDuration.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Time Per Question:";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(114, 38);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(194, 43);
			this.txtDescription.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(45, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 42;
			this.label6.Text = "Description:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(166, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 48;
			this.label5.Text = "secs";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(166, 125);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(29, 13);
			this.label8.TabIndex = 49;
			this.label8.Text = "secs";
			// 
			// btnRunNow
			// 
			this.btnRunNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunNow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnRunNow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnRunNow.Image = ((System.Drawing.Image)(resources.GetObject("btnRunNow.Image")));
			this.btnRunNow.Location = new System.Drawing.Point(225, 144);
			this.btnRunNow.Name = "btnRunNow";
			this.btnRunNow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnRunNow.Size = new System.Drawing.Size(83, 44);
			this.btnRunNow.TabIndex = 10;
			this.btnRunNow.Text = "Run Now";
			this.btnRunNow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRunNow.UseVisualStyleBackColor = true;
			this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
			// 
			// ckbSaveFirst
			// 
			this.ckbSaveFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ckbSaveFirst.AutoSize = true;
			this.ckbSaveFirst.Location = new System.Drawing.Point(236, 195);
			this.ckbSaveFirst.Name = "ckbSaveFirst";
			this.ckbSaveFirst.Size = new System.Drawing.Size(70, 17);
			this.ckbSaveFirst.TabIndex = 50;
			this.ckbSaveFirst.Text = "Save first";
			this.ckbSaveFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ckbSaveFirst.UseVisualStyleBackColor = true;
			// 
			// ckbIncludeBBAForms
			// 
			this.ckbIncludeBBAForms.AutoSize = true;
			this.ckbIncludeBBAForms.Location = new System.Drawing.Point(114, 241);
			this.ckbIncludeBBAForms.Name = "ckbIncludeBBAForms";
			this.ckbIncludeBBAForms.Size = new System.Drawing.Size(78, 17);
			this.ckbIncludeBBAForms.TabIndex = 58;
			this.ckbIncludeBBAForms.Text = "BBA Forms";
			this.ckbIncludeBBAForms.UseVisualStyleBackColor = true;
			// 
			// ckbIncludeAABForms
			// 
			this.ckbIncludeAABForms.AutoSize = true;
			this.ckbIncludeAABForms.Location = new System.Drawing.Point(114, 223);
			this.ckbIncludeAABForms.Name = "ckbIncludeAABForms";
			this.ckbIncludeAABForms.Size = new System.Drawing.Size(78, 17);
			this.ckbIncludeAABForms.TabIndex = 57;
			this.ckbIncludeAABForms.Text = "AAB Forms";
			this.ckbIncludeAABForms.UseVisualStyleBackColor = true;
			// 
			// ckbIncludeOpenForms
			// 
			this.ckbIncludeOpenForms.AutoSize = true;
			this.ckbIncludeOpenForms.Location = new System.Drawing.Point(114, 196);
			this.ckbIncludeOpenForms.Name = "ckbIncludeOpenForms";
			this.ckbIncludeOpenForms.Size = new System.Drawing.Size(83, 17);
			this.ckbIncludeOpenForms.TabIndex = 56;
			this.ckbIncludeOpenForms.Text = "Open Forms";
			this.ckbIncludeOpenForms.UseVisualStyleBackColor = true;
			// 
			// ckbIncludeBForms
			// 
			this.ckbIncludeBForms.AutoSize = true;
			this.ckbIncludeBForms.Location = new System.Drawing.Point(114, 178);
			this.ckbIncludeBForms.Name = "ckbIncludeBForms";
			this.ckbIncludeBForms.Size = new System.Drawing.Size(64, 17);
			this.ckbIncludeBForms.TabIndex = 55;
			this.ckbIncludeBForms.Text = "B Forms";
			this.ckbIncludeBForms.UseVisualStyleBackColor = true;
			// 
			// ckbIncludeAForms
			// 
			this.ckbIncludeAForms.AutoSize = true;
			this.ckbIncludeAForms.Location = new System.Drawing.Point(114, 160);
			this.ckbIncludeAForms.Name = "ckbIncludeAForms";
			this.ckbIncludeAForms.Size = new System.Drawing.Size(64, 17);
			this.ckbIncludeAForms.TabIndex = 54;
			this.ckbIncludeAForms.Text = "A Forms";
			this.ckbIncludeAForms.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 52;
			this.label2.Text = "Include Major Keys:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 13);
			this.label7.TabIndex = 59;
			this.label7.Text = "Include Minor Keys:";
			// 
			// ProgTestSetupForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(320, 316);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.ckbIncludeBBAForms);
			this.Controls.Add(this.ckbIncludeAABForms);
			this.Controls.Add(this.ckbIncludeOpenForms);
			this.Controls.Add(this.ckbIncludeBForms);
			this.Controls.Add(this.ckbIncludeAForms);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ckbSaveFirst);
			this.Controls.Add(this.btnRunNow);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numQuestionDuration);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.numTestDuration);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ProgTestSetupForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Voicing Test Setup";
			((System.ComponentModel.ISupportInitialize)(this.numTestDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numQuestionDuration)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.NumericUpDown numTestDuration;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.NumericUpDown numQuestionDuration;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnRunNow;
		private System.Windows.Forms.CheckBox ckbSaveFirst;
		private System.Windows.Forms.CheckBox ckbIncludeBBAForms;
		private System.Windows.Forms.CheckBox ckbIncludeAABForms;
		private System.Windows.Forms.CheckBox ckbIncludeOpenForms;
		private System.Windows.Forms.CheckBox ckbIncludeBForms;
		private System.Windows.Forms.CheckBox ckbIncludeAForms;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
	}
}