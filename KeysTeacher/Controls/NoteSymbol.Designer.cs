namespace KeysTeacher
{
	partial class NoteSymbol
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteSymbol));
			this.picAccidental = new System.Windows.Forms.PictureBox();
			this.lblLetter = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picAccidental)).BeginInit();
			this.SuspendLayout();
			// 
			// picAccidental
			// 
			this.picAccidental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picAccidental.BackColor = System.Drawing.Color.Transparent;
			this.picAccidental.ErrorImage = null;
			this.picAccidental.Image = ((System.Drawing.Image)(resources.GetObject("picAccidental.Image")));
			this.picAccidental.InitialImage = null;
			this.picAccidental.Location = new System.Drawing.Point(32, 0);
			this.picAccidental.Name = "picAccidental";
			this.picAccidental.Size = new System.Drawing.Size(10, 25);
			this.picAccidental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picAccidental.TabIndex = 1053;
			this.picAccidental.TabStop = false;
			// 
			// lblLetter
			// 
			this.lblLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLetter.BackColor = System.Drawing.Color.Transparent;
			this.lblLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLetter.Location = new System.Drawing.Point(1, -3);
			this.lblLetter.Name = "lblLetter";
			this.lblLetter.Size = new System.Drawing.Size(40, 44);
			this.lblLetter.TabIndex = 1052;
			this.lblLetter.Text = "G";
			this.lblLetter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// NoteSymbol
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.picAccidental);
			this.Controls.Add(this.lblLetter);
			this.Name = "NoteSymbol";
			this.Size = new System.Drawing.Size(46, 40);
			this.EnabledChanged += new System.EventHandler(this.NoteSymbol_EnabledChanged);
			((System.ComponentModel.ISupportInitialize)(this.picAccidental)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picAccidental;
		private System.Windows.Forms.Label lblLetter;
	}
}
