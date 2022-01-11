namespace KeysTeacher
{
	partial class VoicingExamCtl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoicingExamCtl));
			this.picResult = new System.Windows.Forms.PictureBox();
			this.btnPlayVoicing = new System.Windows.Forms.Button();
			this.chordSymbol1 = new KeysTeacher.ChordSymbol();
			this.pianoControl1 = new Controls.PianoControl();
			this.lblDegree = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
			this.SuspendLayout();
			// 
			// picResult
			// 
			this.picResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.picResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.picResult.Image = ((System.Drawing.Image)(resources.GetObject("picResult.Image")));
			this.picResult.Location = new System.Drawing.Point(64, 22);
			this.picResult.Name = "picResult";
			this.picResult.Size = new System.Drawing.Size(32, 32);
			this.picResult.TabIndex = 45;
			this.picResult.TabStop = false;
			// 
			// btnPlayVoicing
			// 
			this.btnPlayVoicing.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnPlayVoicing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnPlayVoicing.Image = ((System.Drawing.Image)(resources.GetObject("btnPlayVoicing.Image")));
			this.btnPlayVoicing.Location = new System.Drawing.Point(229, 22);
			this.btnPlayVoicing.Name = "btnPlayVoicing";
			this.btnPlayVoicing.Size = new System.Drawing.Size(35, 34);
			this.btnPlayVoicing.TabIndex = 44;
			this.btnPlayVoicing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPlayVoicing.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnPlayVoicing.UseVisualStyleBackColor = true;
			this.btnPlayVoicing.Click += new System.EventHandler(this.btnPlayVoicing_Click);
			// 
			// chordSymbol1
			// 
			this.chordSymbol1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.chordSymbol1.BackColor = System.Drawing.SystemColors.Control;
			this.chordSymbol1.Chord = null;
			this.chordSymbol1.Location = new System.Drawing.Point(99, 7);
			this.chordSymbol1.Name = "chordSymbol1";
			this.chordSymbol1.Size = new System.Drawing.Size(118, 63);
			this.chordSymbol1.TabIndex = 46;
			// 
			// pianoControl1
			// 
			this.pianoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pianoControl1.HighNoteID = 92;
			this.pianoControl1.Location = new System.Drawing.Point(273, 4);
			this.pianoControl1.LowNoteID = 28;
			this.pianoControl1.Name = "pianoControl1";
			this.pianoControl1.NoteOnColor = System.Drawing.Color.DodgerBlue;
			this.pianoControl1.Size = new System.Drawing.Size(539, 70);
			this.pianoControl1.TabIndex = 42;
			this.pianoControl1.Text = "pianoControl1";
			// 
			// lblDegree
			// 
			this.lblDegree.AutoSize = true;
			this.lblDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDegree.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDegree.Location = new System.Drawing.Point(9, 12);
			this.lblDegree.Margin = new System.Windows.Forms.Padding(0);
			this.lblDegree.Name = "lblDegree";
			this.lblDegree.Size = new System.Drawing.Size(48, 48);
			this.lblDegree.TabIndex = 47;
			this.lblDegree.Text = "II";
			// 
			// VoicingExamCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chordSymbol1);
			this.Controls.Add(this.picResult);
			this.Controls.Add(this.btnPlayVoicing);
			this.Controls.Add(this.pianoControl1);
			this.Controls.Add(this.lblDegree);
			this.Name = "VoicingExamCtl";
			this.Size = new System.Drawing.Size(815, 79);
			this.Load += new System.EventHandler(this.VoicingExamCtl_Load);
			((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picResult;
		private System.Windows.Forms.Button btnPlayVoicing;
		private Controls.PianoControl pianoControl1;
		private ChordSymbol chordSymbol1;
		private System.Windows.Forms.Label lblDegree;
	}
}
