namespace KeysTeacher
{
	partial class NoteSymbolSm
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
			this.lblNote = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblNote
			// 
			this.lblNote.BackColor = System.Drawing.Color.Transparent;
			this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNote.Location = new System.Drawing.Point(-3, -3);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(33, 21);
			this.lblNote.TabIndex = 1052;
			this.lblNote.Text = "D#";
			// 
			// NoteSymbolSm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblNote);
			this.Name = "NoteSymbolSm";
			this.Size = new System.Drawing.Size(28, 18);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblNote;
	}
}
