namespace KeysTeacher
{
	partial class VoicingSymbol
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
			this.lblForm = new System.Windows.Forms.Label();
			this.chordSymbol1 = new KeysTeacher.ChordSymbol();
			this.SuspendLayout();
			// 
			// lblForm
			// 
			this.lblForm.BackColor = System.Drawing.Color.Transparent;
			this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblForm.ForeColor = System.Drawing.Color.MediumBlue;
			this.lblForm.Location = new System.Drawing.Point(14, 52);
			this.lblForm.Name = "lblForm";
			this.lblForm.Size = new System.Drawing.Size(81, 21);
			this.lblForm.TabIndex = 1;
			this.lblForm.Text = "lblForm";
			this.lblForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chordSymbol1
			// 
			this.chordSymbol1.BackColor = System.Drawing.SystemColors.Control;
			this.chordSymbol1.Chord = null;
			this.chordSymbol1.Location = new System.Drawing.Point(2, 1);
			this.chordSymbol1.Name = "chordSymbol1";
			this.chordSymbol1.Size = new System.Drawing.Size(127, 62);
			this.chordSymbol1.TabIndex = 2;
			// 
			// VoicingSymbol
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblForm);
			this.Controls.Add(this.chordSymbol1);
			this.Name = "VoicingSymbol";
			this.Size = new System.Drawing.Size(131, 88);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblForm;
		private ChordSymbol chordSymbol1;
	}
}
