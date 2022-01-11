namespace KeysTeacher
{
	partial class VoicingListEditor
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
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lbxVoicings = new System.Windows.Forms.ListBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.voicingEditor1 = new KeysTeacher.VoicingEditor();
			this.btnAddCopy = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(515, 156);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(81, 25);
			this.btnDelete.TabIndex = 9;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(515, 32);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(81, 25);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lbxVoicings
			// 
			this.lbxVoicings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxVoicings.FormattingEnabled = true;
			this.lbxVoicings.IntegralHeight = false;
			this.lbxVoicings.Location = new System.Drawing.Point(11, 35);
			this.lbxVoicings.Name = "lbxVoicings";
			this.lbxVoicings.Size = new System.Drawing.Size(496, 170);
			this.lbxVoicings.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(515, 125);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(81, 25);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(9, 217);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(587, 4);
			this.panel1.TabIndex = 13;
			// 
			// voicingEditor1
			// 
			this.voicingEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.voicingEditor1.Location = new System.Drawing.Point(2, 227);
			this.voicingEditor1.Name = "voicingEditor1";
			this.voicingEditor1.Size = new System.Drawing.Size(599, 238);
			this.voicingEditor1.TabIndex = 14;
			this.voicingEditor1.Voicing = null;
			// 
			// btnAddCopy
			// 
			this.btnAddCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddCopy.Location = new System.Drawing.Point(515, 63);
			this.btnAddCopy.Name = "btnAddCopy";
			this.btnAddCopy.Size = new System.Drawing.Size(81, 25);
			this.btnAddCopy.TabIndex = 16;
			this.btnAddCopy.Text = "Add Copy";
			this.btnAddCopy.UseVisualStyleBackColor = true;
			this.btnAddCopy.Click += new System.EventHandler(this.btnAddCopy_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(515, 94);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(81, 25);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 18);
			this.label1.TabIndex = 45;
			this.label1.Text = "Voicings Setup";
			// 
			// VoicingListEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAddCopy);
			this.Controls.Add(this.voicingEditor1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbxVoicings);
			this.Name = "VoicingListEditor";
			this.Size = new System.Drawing.Size(608, 473);
			this.Load += new System.EventHandler(this.VoicingListEditor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox lbxVoicings;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel1;
		private VoicingEditor voicingEditor1;
		private System.Windows.Forms.Button btnAddCopy;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
	}
}
