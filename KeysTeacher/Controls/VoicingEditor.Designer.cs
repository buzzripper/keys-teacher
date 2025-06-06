﻿namespace KeysTeacher
{
	partial class VoicingEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoicingEditor));
            this.cmbVoicingForm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblForm = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chordEditor1 = new KeysTeacher.ChordEditor();
            this.pianoControl1 = new KeysTeacher.Controls.PianoControl();
            this.SuspendLayout();
            // 
            // cmbVoicingForm
            // 
            this.cmbVoicingForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbVoicingForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoicingForm.FormattingEnabled = true;
            this.cmbVoicingForm.Location = new System.Drawing.Point(326, 127);
            this.cmbVoicingForm.Name = "cmbVoicingForm";
            this.cmbVoicingForm.Size = new System.Drawing.Size(107, 21);
            this.cmbVoicingForm.TabIndex = 33;
            this.cmbVoicingForm.SelectedIndexChanged += new System.EventHandler(this.cmbVoicingForm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Location = new System.Drawing.Point(279, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Form:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblForm
            // 
            this.lblForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForm.BackColor = System.Drawing.Color.Transparent;
            this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblForm.Location = new System.Drawing.Point(154, 114);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(95, 29);
            this.lblForm.TabIndex = 3;
            this.lblForm.Text = "lblForm";
            this.lblForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlay.Location = new System.Drawing.Point(458, 105);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(45, 43);
            this.btnPlay.TabIndex = 38;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Location = new System.Drawing.Point(509, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 43);
            this.btnClear.TabIndex = 39;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chordEditor1
            // 
            this.chordEditor1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chordEditor1.Chord = null;
            this.chordEditor1.Location = new System.Drawing.Point(116, 3);
            this.chordEditor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chordEditor1.Name = "chordEditor1";
            this.chordEditor1.Size = new System.Drawing.Size(317, 119);
            this.chordEditor1.TabIndex = 40;
            // 
            // pianoControl1
            // 
            this.pianoControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pianoControl1.BassNoteOnColor = System.Drawing.Color.MediumBlue;
            this.pianoControl1.HighNoteID = 92;
            this.pianoControl1.Location = new System.Drawing.Point(31, 161);
            this.pianoControl1.LowNoteID = 28;
            this.pianoControl1.Name = "pianoControl1";
            this.pianoControl1.NoteOnColor = System.Drawing.Color.DodgerBlue;
            this.pianoControl1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pianoControl1.Size = new System.Drawing.Size(537, 77);
            this.pianoControl1.StickyKeys = true;
            this.pianoControl1.TabIndex = 35;
            this.pianoControl1.Text = "pianoControl1";
            this.pianoControl1.PianoKeyDown += new System.EventHandler<KeysTeacher.PianoKeyEventArgs>(this.pianoControl1_PianoKeyDown);
            this.pianoControl1.PianoKeyUp += new System.EventHandler<KeysTeacher.PianoKeyEventArgs>(this.pianoControl1_PianoKeyUp);
            this.pianoControl1.BassKeyDown += new System.EventHandler<KeysTeacher.PianoKeyEventArgs>(this.pianoControl1_BassKeyDown);
            this.pianoControl1.BassKeyUp += new System.EventHandler<KeysTeacher.PianoKeyEventArgs>(this.pianoControl1_BassKeyUp);
            // 
            // VoicingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.chordEditor1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pianoControl1);
            this.Controls.Add(this.cmbVoicingForm);
            this.Controls.Add(this.label1);
            this.Name = "VoicingEditor";
            this.Size = new System.Drawing.Size(597, 258);
            this.EnabledChanged += new System.EventHandler(this.VoicingEditor_EnabledChanged);
            this.Resize += new System.EventHandler(this.VoicingEditor_Resize);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbVoicingForm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblForm;
		private Controls.PianoControl pianoControl1;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnClear;
		private ChordEditor chordEditor1;
	}
}
