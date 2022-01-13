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
            this.picAccidental.BackColor = System.Drawing.Color.Transparent;
            this.picAccidental.ErrorImage = null;
            this.picAccidental.Image = ((System.Drawing.Image)(resources.GetObject("picAccidental.Image")));
            this.picAccidental.InitialImage = null;
            this.picAccidental.Location = new System.Drawing.Point(66, 5);
            this.picAccidental.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picAccidental.Name = "picAccidental";
            this.picAccidental.Size = new System.Drawing.Size(24, 41);
            this.picAccidental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAccidental.TabIndex = 1053;
            this.picAccidental.TabStop = false;
            // 
            // lblLetter
            // 
            this.lblLetter.BackColor = System.Drawing.Color.Transparent;
            this.lblLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetter.Location = new System.Drawing.Point(5, 0);
            this.lblLetter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(67, 93);
            this.lblLetter.TabIndex = 1052;
            this.lblLetter.Text = "G";
            this.lblLetter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NoteSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.picAccidental);
            this.Controls.Add(this.lblLetter);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NoteSymbol";
            this.Size = new System.Drawing.Size(88, 82);
            this.EnabledChanged += new System.EventHandler(this.NoteSymbol_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picAccidental)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picAccidental;
		private System.Windows.Forms.Label lblLetter;
	}
}
