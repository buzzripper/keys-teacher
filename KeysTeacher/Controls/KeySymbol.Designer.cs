namespace KeysTeacher
{
	partial class KeySymbol
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeySymbol));
			this.lblLetter = new System.Windows.Forms.Label();
			this.picAccidental = new System.Windows.Forms.PictureBox();
			this.picMinor = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picAccidental)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picMinor)).BeginInit();
			this.SuspendLayout();
			// 
			// lblLetter
			// 
			this.lblLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLetter.Location = new System.Drawing.Point(-12, -13);
			this.lblLetter.Name = "lblLetter";
			this.lblLetter.Size = new System.Drawing.Size(87, 81);
			this.lblLetter.TabIndex = 1063;
			this.lblLetter.Text = "G";
			// 
			// picAccidental
			// 
			this.picAccidental.Image = ((System.Drawing.Image)(resources.GetObject("picAccidental.Image")));
			this.picAccidental.Location = new System.Drawing.Point(65, -1);
			this.picAccidental.Name = "picAccidental";
			this.picAccidental.Size = new System.Drawing.Size(15, 38);
			this.picAccidental.TabIndex = 1064;
			this.picAccidental.TabStop = false;
			// 
			// picMinor
			// 
			this.picMinor.Image = ((System.Drawing.Image)(resources.GetObject("picMinor.Image")));
			this.picMinor.Location = new System.Drawing.Point(65, 44);
			this.picMinor.Name = "picMinor";
			this.picMinor.Size = new System.Drawing.Size(18, 19);
			this.picMinor.TabIndex = 1065;
			this.picMinor.TabStop = false;
			// 
			// KeySymbol
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.picMinor);
			this.Controls.Add(this.picAccidental);
			this.Controls.Add(this.lblLetter);
			this.Name = "KeySymbol";
			this.Size = new System.Drawing.Size(88, 68);
			((System.ComponentModel.ISupportInitialize)(this.picAccidental)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picMinor)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblLetter;
		private System.Windows.Forms.PictureBox picAccidental;
		private System.Windows.Forms.PictureBox picMinor;
	}
}
