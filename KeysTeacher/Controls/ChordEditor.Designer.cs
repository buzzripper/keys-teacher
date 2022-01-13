namespace KeysTeacher
{
	partial class ChordEditor
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
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbExt1 = new System.Windows.Forms.CheckBox();
            this.ckbExt2 = new System.Windows.Forms.CheckBox();
            this.ckbExt3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numExt1 = new System.Windows.Forms.NumericUpDown();
            this.cmbExt1 = new System.Windows.Forms.ComboBox();
            this.numExt2 = new System.Windows.Forms.NumericUpDown();
            this.cmbExt2 = new System.Windows.Forms.ComboBox();
            this.numExt3 = new System.Windows.Forms.NumericUpDown();
            this.cmbExt3 = new System.Windows.Forms.ComboBox();
            this.cmbBassNotes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chordSymbol1 = new KeysTeacher.ChordSymbol();
            ((System.ComponentModel.ISupportInitialize)(this.numExt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExt3)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbQuality
            // 
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Location = new System.Drawing.Point(294, 42);
            this.cmbQuality.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(163, 28);
            this.cmbQuality.TabIndex = 33;
            this.cmbQuality.SelectedIndexChanged += new System.EventHandler(this.cmbQuality_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Quality:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNote
            // 
            this.cmbNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Location = new System.Drawing.Point(294, 5);
            this.cmbNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(56, 28);
            this.cmbNote.TabIndex = 31;
            this.cmbNote.SelectedIndexChanged += new System.EventHandler(this.cmbNote_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Chord:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbExt1
            // 
            this.ckbExt1.AutoSize = true;
            this.ckbExt1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbExt1.Location = new System.Drawing.Point(244, 85);
            this.ckbExt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbExt1.Name = "ckbExt1";
            this.ckbExt1.Size = new System.Drawing.Size(75, 24);
            this.ckbExt1.TabIndex = 44;
            this.ckbExt1.Text = "Ext 1:";
            this.ckbExt1.UseVisualStyleBackColor = true;
            this.ckbExt1.CheckedChanged += new System.EventHandler(this.ckbExt1_CheckedChanged);
            // 
            // ckbExt2
            // 
            this.ckbExt2.AutoSize = true;
            this.ckbExt2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbExt2.Location = new System.Drawing.Point(244, 118);
            this.ckbExt2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbExt2.Name = "ckbExt2";
            this.ckbExt2.Size = new System.Drawing.Size(75, 24);
            this.ckbExt2.TabIndex = 45;
            this.ckbExt2.Text = "Ext 2:";
            this.ckbExt2.UseVisualStyleBackColor = true;
            this.ckbExt2.CheckedChanged += new System.EventHandler(this.ckbExt2_CheckedChanged);
            // 
            // ckbExt3
            // 
            this.ckbExt3.AutoSize = true;
            this.ckbExt3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbExt3.Location = new System.Drawing.Point(244, 152);
            this.ckbExt3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbExt3.Name = "ckbExt3";
            this.ckbExt3.Size = new System.Drawing.Size(75, 24);
            this.ckbExt3.TabIndex = 47;
            this.ckbExt3.Text = "Ext 3:";
            this.ckbExt3.UseVisualStyleBackColor = true;
            this.ckbExt3.CheckedChanged += new System.EventHandler(this.ckbExt3_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(177, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 44;
            this.checkBox1.Text = "Ext 1:";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numExt1
            // 
            this.numExt1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numExt1.Location = new System.Drawing.Point(335, 80);
            this.numExt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numExt1.Name = "numExt1";
            this.numExt1.Size = new System.Drawing.Size(54, 26);
            this.numExt1.TabIndex = 54;
            this.numExt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numExt1.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numExt1.ValueChanged += new System.EventHandler(this.numExt1_ValueChanged);
            // 
            // cmbExt1
            // 
            this.cmbExt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExt1.FormattingEnabled = true;
            this.cmbExt1.Location = new System.Drawing.Point(401, 78);
            this.cmbExt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbExt1.Name = "cmbExt1";
            this.cmbExt1.Size = new System.Drawing.Size(56, 28);
            this.cmbExt1.TabIndex = 53;
            this.cmbExt1.SelectedIndexChanged += new System.EventHandler(this.cmbExt_SelectedIndexChanged);
            // 
            // numExt2
            // 
            this.numExt2.Location = new System.Drawing.Point(335, 115);
            this.numExt2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numExt2.Name = "numExt2";
            this.numExt2.Size = new System.Drawing.Size(54, 26);
            this.numExt2.TabIndex = 56;
            this.numExt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numExt2.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numExt2.ValueChanged += new System.EventHandler(this.numExt2_ValueChanged);
            // 
            // cmbExt2
            // 
            this.cmbExt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExt2.FormattingEnabled = true;
            this.cmbExt2.Location = new System.Drawing.Point(401, 114);
            this.cmbExt2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbExt2.Name = "cmbExt2";
            this.cmbExt2.Size = new System.Drawing.Size(56, 28);
            this.cmbExt2.TabIndex = 55;
            this.cmbExt2.SelectedIndexChanged += new System.EventHandler(this.cmbExt_SelectedIndexChanged);
            // 
            // numExt3
            // 
            this.numExt3.Location = new System.Drawing.Point(335, 149);
            this.numExt3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numExt3.Name = "numExt3";
            this.numExt3.Size = new System.Drawing.Size(54, 26);
            this.numExt3.TabIndex = 58;
            this.numExt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numExt3.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numExt3.ValueChanged += new System.EventHandler(this.numExt3_ValueChanged);
            // 
            // cmbExt3
            // 
            this.cmbExt3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExt3.FormattingEnabled = true;
            this.cmbExt3.Location = new System.Drawing.Point(401, 149);
            this.cmbExt3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbExt3.Name = "cmbExt3";
            this.cmbExt3.Size = new System.Drawing.Size(56, 28);
            this.cmbExt3.TabIndex = 57;
            this.cmbExt3.SelectedIndexChanged += new System.EventHandler(this.cmbExt_SelectedIndexChanged);
            // 
            // cmbBassNotes
            // 
            this.cmbBassNotes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBassNotes.FormattingEnabled = true;
            this.cmbBassNotes.Location = new System.Drawing.Point(400, 5);
            this.cmbBassNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBassNotes.Name = "cmbBassNotes";
            this.cmbBassNotes.Size = new System.Drawing.Size(56, 28);
            this.cmbBassNotes.TabIndex = 61;
            this.cmbBassNotes.SelectedIndexChanged += new System.EventHandler(this.cmbBassNote_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "Bass:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chordSymbol1
            // 
            this.chordSymbol1.BackColor = System.Drawing.SystemColors.Control;
            this.chordSymbol1.Chord = null;
            this.chordSymbol1.Location = new System.Drawing.Point(6, 21);
            this.chordSymbol1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.chordSymbol1.Name = "chordSymbol1";
            this.chordSymbol1.Size = new System.Drawing.Size(228, 144);
            this.chordSymbol1.TabIndex = 59;
            // 
            // ChordEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbBassNotes);
            this.Controls.Add(this.numExt3);
            this.Controls.Add(this.cmbExt3);
            this.Controls.Add(this.numExt2);
            this.Controls.Add(this.cmbExt2);
            this.Controls.Add(this.numExt1);
            this.Controls.Add(this.cmbExt1);
            this.Controls.Add(this.ckbExt3);
            this.Controls.Add(this.ckbExt2);
            this.Controls.Add(this.ckbExt1);
            this.Controls.Add(this.cmbQuality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chordSymbol1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChordEditor";
            this.Size = new System.Drawing.Size(470, 186);
            this.BackColorChanged += new System.EventHandler(this.ChordEditor_BackColorChanged);
            this.EnabledChanged += new System.EventHandler(this.ChordEditor_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numExt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExt3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbQuality;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNote;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox ckbExt1;
		private System.Windows.Forms.CheckBox ckbExt2;
		private System.Windows.Forms.CheckBox ckbExt3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.NumericUpDown numExt1;
		private System.Windows.Forms.ComboBox cmbExt1;
		private System.Windows.Forms.NumericUpDown numExt2;
		private System.Windows.Forms.ComboBox cmbExt2;
		private System.Windows.Forms.NumericUpDown numExt3;
		private System.Windows.Forms.ComboBox cmbExt3;
		private ChordSymbol chordSymbol1;
		private System.Windows.Forms.ComboBox cmbBassNotes;
		private System.Windows.Forms.Label label3;
	}
}
