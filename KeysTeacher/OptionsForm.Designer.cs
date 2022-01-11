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
			((System.ComponentModel.ISupportInitialize)(this.numNoteOnVelocity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPassDelaySecs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFailDelaySecs)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(143, 153);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 31);
			this.btnCancel.TabIndex = 32;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(50, 153);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(87, 31);
			this.btnOk.TabIndex = 31;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(58, 111);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Answer Note Velocity:";
			// 
			// numNoteOnVelocity
			// 
			this.numNoteOnVelocity.Location = new System.Drawing.Point(173, 109);
			this.numNoteOnVelocity.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
			this.numNoteOnVelocity.Name = "numNoteOnVelocity";
			this.numNoteOnVelocity.Size = new System.Drawing.Size(54, 20);
			this.numNoteOnVelocity.TabIndex = 34;
			this.numNoteOnVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ckbMidiThru
			// 
			this.ckbMidiThru.AutoSize = true;
			this.ckbMidiThru.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ckbMidiThru.Location = new System.Drawing.Point(113, 12);
			this.ckbMidiThru.Name = "ckbMidiThru";
			this.ckbMidiThru.Size = new System.Drawing.Size(73, 17);
			this.ckbMidiThru.TabIndex = 35;
			this.ckbMidiThru.Text = "Midi Thru:";
			this.ckbMidiThru.UseVisualStyleBackColor = true;
			// 
			// numPassDelaySecs
			// 
			this.numPassDelaySecs.Location = new System.Drawing.Point(173, 47);
			this.numPassDelaySecs.Name = "numPassDelaySecs";
			this.numPassDelaySecs.Size = new System.Drawing.Size(54, 20);
			this.numPassDelaySecs.TabIndex = 38;
			this.numPassDelaySecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 13);
			this.label2.TabIndex = 37;
			this.label2.Text = "Wait after a correct answer:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(229, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 13);
			this.label3.TabIndex = 39;
			this.label3.Text = "sec.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(229, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 13);
			this.label4.TabIndex = 42;
			this.label4.Text = "sec.";
			// 
			// numFailDelaySecs
			// 
			this.numFailDelaySecs.Location = new System.Drawing.Point(173, 73);
			this.numFailDelaySecs.Name = "numFailDelaySecs";
			this.numFailDelaySecs.Size = new System.Drawing.Size(54, 20);
			this.numFailDelaySecs.TabIndex = 41;
			this.numFailDelaySecs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 13);
			this.label5.TabIndex = 40;
			this.label5.Text = "Wait after a wrong answer:";
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(281, 197);
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
	}
}