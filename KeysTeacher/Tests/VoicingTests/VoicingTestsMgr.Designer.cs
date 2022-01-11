namespace KeysTeacher.Tests.VoicingTests
{
	partial class VoicingTestsMgr
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoicingTestsMgr));
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnRunTest = new System.Windows.Forms.Button();
			this.btnStats = new System.Windows.Forms.Button();
			this.btnDuplicate = new System.Windows.Forms.Button();
			this.lbxVoicingTests = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 18);
			this.label1.TabIndex = 44;
			this.label1.Text = "Voicings Tests";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(354, 144);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(132, 31);
			this.btnDelete.TabIndex = 43;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(354, 70);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(132, 31);
			this.btnEdit.TabIndex = 42;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(354, 33);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(132, 31);
			this.btnNew.TabIndex = 41;
			this.btnNew.Text = "New..";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnRunTest
			// 
			this.btnRunTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunTest.Enabled = false;
			this.btnRunTest.Image = ((System.Drawing.Image)(resources.GetObject("btnRunTest.Image")));
			this.btnRunTest.Location = new System.Drawing.Point(386, 233);
			this.btnRunTest.Name = "btnRunTest";
			this.btnRunTest.Size = new System.Drawing.Size(66, 58);
			this.btnRunTest.TabIndex = 45;
			this.btnRunTest.Text = "Run Test";
			this.btnRunTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRunTest.UseVisualStyleBackColor = true;
			this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
			// 
			// btnStats
			// 
			this.btnStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStats.Enabled = false;
			this.btnStats.Location = new System.Drawing.Point(354, 181);
			this.btnStats.Name = "btnStats";
			this.btnStats.Size = new System.Drawing.Size(132, 31);
			this.btnStats.TabIndex = 46;
			this.btnStats.Text = "Statistics...";
			this.btnStats.UseVisualStyleBackColor = true;
			this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
			// 
			// btnDuplicate
			// 
			this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDuplicate.Location = new System.Drawing.Point(354, 107);
			this.btnDuplicate.Name = "btnDuplicate";
			this.btnDuplicate.Size = new System.Drawing.Size(132, 31);
			this.btnDuplicate.TabIndex = 47;
			this.btnDuplicate.Text = "Duplicate";
			this.btnDuplicate.UseVisualStyleBackColor = true;
			// 
			// lbxVoicingTests
			// 
			this.lbxVoicingTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxVoicingTests.FormattingEnabled = true;
			this.lbxVoicingTests.IntegralHeight = false;
			this.lbxVoicingTests.Location = new System.Drawing.Point(13, 33);
			this.lbxVoicingTests.Name = "lbxVoicingTests";
			this.lbxVoicingTests.Size = new System.Drawing.Size(330, 287);
			this.lbxVoicingTests.Sorted = true;
			this.lbxVoicingTests.TabIndex = 48;
			this.lbxVoicingTests.SelectedIndexChanged += new System.EventHandler(this.lbxVoicingTests_SelectedIndexChanged);
			this.lbxVoicingTests.DoubleClick += new System.EventHandler(this.lbxTests_DoubleClick);
			this.lbxVoicingTests.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxTests_KeyDown);
			// 
			// VoicingTestsMgr
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lbxVoicingTests);
			this.Controls.Add(this.btnDuplicate);
			this.Controls.Add(this.btnStats);
			this.Controls.Add(this.btnRunTest);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnNew);
			this.Name = "VoicingTestsMgr";
			this.Size = new System.Drawing.Size(498, 342);
			this.Load += new System.EventHandler(this.VoicingTestsMgr_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnRunTest;
		private System.Windows.Forms.Button btnStats;
		private System.Windows.Forms.Button btnDuplicate;
		private System.Windows.Forms.ListBox lbxVoicingTests;
	}
}
