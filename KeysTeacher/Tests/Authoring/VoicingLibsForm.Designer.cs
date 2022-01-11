namespace KeysTeacher.Tests.Authoring
{
	partial class VoicingLibsForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoicingLibsForm));
			this.btnSelect = new System.Windows.Forms.Button();
			this.lbxVoicings = new System.Windows.Forms.ListBox();
			this.btnExpand = new System.Windows.Forms.Button();
			this.btnEditVoicing = new System.Windows.Forms.Button();
			this.btnDeleteVoicing = new System.Windows.Forms.Button();
			this.btnAddVoicing = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbLibNames = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnEditLib = new System.Windows.Forms.Button();
			this.btnDeleteLib = new System.Windows.Forms.Button();
			this.btnNewLib = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.cmbSysVoicingLibs = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAddSystemLib = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSelect
			// 
			this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSelect.Location = new System.Drawing.Point(47, 294);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(91, 31);
			this.btnSelect.TabIndex = 27;
			this.btnSelect.Text = "Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lbxVoicings
			// 
			this.lbxVoicings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbxVoicings.FormattingEnabled = true;
			this.lbxVoicings.IntegralHeight = false;
			this.lbxVoicings.Location = new System.Drawing.Point(5, 50);
			this.lbxVoicings.Name = "lbxVoicings";
			this.lbxVoicings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbxVoicings.Size = new System.Drawing.Size(187, 233);
			this.lbxVoicings.TabIndex = 26;
			this.lbxVoicings.SelectedIndexChanged += new System.EventHandler(this.lbxVoicings_SelectedIndexChanged);
			this.lbxVoicings.DoubleClick += new System.EventHandler(this.lbxVoicings_DoubleClick);
			this.lbxVoicings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxVoicings_KeyDown);
			this.lbxVoicings.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbxVoicings_KeyPress);
			// 
			// btnExpand
			// 
			this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExpand.Location = new System.Drawing.Point(170, 294);
			this.btnExpand.Name = "btnExpand";
			this.btnExpand.Size = new System.Drawing.Size(21, 31);
			this.btnExpand.TabIndex = 28;
			this.btnExpand.Text = ">";
			this.btnExpand.UseVisualStyleBackColor = true;
			this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
			// 
			// btnEditVoicing
			// 
			this.btnEditVoicing.Enabled = false;
			this.btnEditVoicing.Location = new System.Drawing.Point(203, 89);
			this.btnEditVoicing.Name = "btnEditVoicing";
			this.btnEditVoicing.Size = new System.Drawing.Size(133, 31);
			this.btnEditVoicing.TabIndex = 33;
			this.btnEditVoicing.Text = "Edit";
			this.btnEditVoicing.UseVisualStyleBackColor = true;
			this.btnEditVoicing.Click += new System.EventHandler(this.btnEditVoicing_Click);
			// 
			// btnDeleteVoicing
			// 
			this.btnDeleteVoicing.Enabled = false;
			this.btnDeleteVoicing.Location = new System.Drawing.Point(203, 127);
			this.btnDeleteVoicing.Name = "btnDeleteVoicing";
			this.btnDeleteVoicing.Size = new System.Drawing.Size(133, 31);
			this.btnDeleteVoicing.TabIndex = 32;
			this.btnDeleteVoicing.Text = "Delete";
			this.btnDeleteVoicing.UseVisualStyleBackColor = true;
			this.btnDeleteVoicing.Click += new System.EventHandler(this.btnDeleteVoicing_Click);
			// 
			// btnAddVoicing
			// 
			this.btnAddVoicing.Location = new System.Drawing.Point(203, 51);
			this.btnAddVoicing.Name = "btnAddVoicing";
			this.btnAddVoicing.Size = new System.Drawing.Size(133, 31);
			this.btnAddVoicing.TabIndex = 31;
			this.btnAddVoicing.Text = "Add";
			this.btnAddVoicing.UseVisualStyleBackColor = true;
			this.btnAddVoicing.Click += new System.EventHandler(this.btnAddVoicing_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 52;
			this.label3.Text = "Library:";
			// 
			// cmbLibNames
			// 
			this.cmbLibNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLibNames.FormattingEnabled = true;
			this.cmbLibNames.Location = new System.Drawing.Point(56, 8);
			this.cmbLibNames.Name = "cmbLibNames";
			this.cmbLibNames.Size = new System.Drawing.Size(133, 21);
			this.cmbLibNames.TabIndex = 53;
			this.cmbLibNames.SelectedIndexChanged += new System.EventHandler(this.cmbLibNames_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(8, 36);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(334, 4);
			this.panel1.TabIndex = 54;
			// 
			// btnEditLib
			// 
			this.btnEditLib.Image = global::KeysTeacher.Properties.Resources.edit_datasource;
			this.btnEditLib.Location = new System.Drawing.Point(232, 6);
			this.btnEditLib.Name = "btnEditLib";
			this.btnEditLib.Size = new System.Drawing.Size(26, 23);
			this.btnEditLib.TabIndex = 57;
			this.btnEditLib.UseVisualStyleBackColor = true;
			this.btnEditLib.Click += new System.EventHandler(this.btnEditLib_Click);
			// 
			// btnDeleteLib
			// 
			this.btnDeleteLib.Image = global::KeysTeacher.Properties.Resources.del_datasource;
			this.btnDeleteLib.Location = new System.Drawing.Point(261, 6);
			this.btnDeleteLib.Name = "btnDeleteLib";
			this.btnDeleteLib.Size = new System.Drawing.Size(26, 23);
			this.btnDeleteLib.TabIndex = 56;
			this.btnDeleteLib.UseVisualStyleBackColor = true;
			this.btnDeleteLib.Click += new System.EventHandler(this.btnDeleteLib_Click);
			// 
			// btnNewLib
			// 
			this.btnNewLib.Image = global::KeysTeacher.Properties.Resources.add_datasource;
			this.btnNewLib.Location = new System.Drawing.Point(203, 6);
			this.btnNewLib.Name = "btnNewLib";
			this.btnNewLib.Size = new System.Drawing.Size(26, 23);
			this.btnNewLib.TabIndex = 55;
			this.btnNewLib.UseVisualStyleBackColor = true;
			this.btnNewLib.Click += new System.EventHandler(this.btnNewLib_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "ArrowCollapse");
			this.imageList1.Images.SetKeyName(1, "ArrowExpand");
			// 
			// cmbSysVoicingLibs
			// 
			this.cmbSysVoicingLibs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSysVoicingLibs.FormattingEnabled = true;
			this.cmbSysVoicingLibs.Location = new System.Drawing.Point(203, 215);
			this.cmbSysVoicingLibs.Name = "cmbSysVoicingLibs";
			this.cmbSysVoicingLibs.Size = new System.Drawing.Size(133, 21);
			this.cmbSysVoicingLibs.TabIndex = 58;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(202, 197);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 59;
			this.label1.Text = "System Libraries";
			// 
			// btnAddSystemLib
			// 
			this.btnAddSystemLib.Location = new System.Drawing.Point(232, 244);
			this.btnAddSystemLib.Name = "btnAddSystemLib";
			this.btnAddSystemLib.Size = new System.Drawing.Size(67, 25);
			this.btnAddSystemLib.TabIndex = 60;
			this.btnAddSystemLib.Text = "Add";
			this.btnAddSystemLib.UseVisualStyleBackColor = true;
			this.btnAddSystemLib.Click += new System.EventHandler(this.btnAddSystemLib_Click);
			// 
			// VoicingLibsForm
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(348, 333);
			this.Controls.Add(this.btnAddSystemLib);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbSysVoicingLibs);
			this.Controls.Add(this.btnEditLib);
			this.Controls.Add(this.btnDeleteLib);
			this.Controls.Add(this.btnNewLib);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cmbLibNames);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnEditVoicing);
			this.Controls.Add(this.btnDeleteVoicing);
			this.Controls.Add(this.btnAddVoicing);
			this.Controls.Add(this.btnExpand);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.lbxVoicings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "VoicingLibsForm";
			this.Text = "Voicing Library";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoicingLibraryForm_FormClosing);
			this.Load += new System.EventHandler(this.VoicingLibsForm_Load);
			this.VisibleChanged += new System.EventHandler(this.VoicingLibraryForm_VisibleChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VoicingLibraryForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ListBox lbxVoicings;
		private System.Windows.Forms.Button btnExpand;
		private System.Windows.Forms.Button btnEditVoicing;
		private System.Windows.Forms.Button btnDeleteVoicing;
		private System.Windows.Forms.Button btnAddVoicing;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbLibNames;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnEditLib;
		private System.Windows.Forms.Button btnDeleteLib;
		private System.Windows.Forms.Button btnNewLib;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ComboBox cmbSysVoicingLibs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddSystemLib;
	}
}