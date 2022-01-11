namespace KeysTeacher
{
	partial class ProgTestsMgr
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgTestsMgr));
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.lvTests = new System.Windows.Forms.ListView();
			this.TestName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnRunTest = new System.Windows.Forms.Button();
			this.btnStats = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 18);
			this.label1.TabIndex = 44;
			this.label1.Text = "Progression Tests";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(410, 102);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(132, 27);
			this.btnDelete.TabIndex = 43;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(410, 68);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(132, 27);
			this.btnEdit.TabIndex = 42;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnNew
			// 
			this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNew.Location = new System.Drawing.Point(410, 34);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(132, 27);
			this.btnNew.TabIndex = 41;
			this.btnNew.Text = "New..";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// lvTests
			// 
			this.lvTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvTests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TestName});
			this.lvTests.FullRowSelect = true;
			this.lvTests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvTests.HideSelection = false;
			this.lvTests.Location = new System.Drawing.Point(10, 34);
			this.lvTests.Name = "lvTests";
			this.lvTests.Size = new System.Drawing.Size(390, 273);
			this.lvTests.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvTests.TabIndex = 40;
			this.lvTests.UseCompatibleStateImageBehavior = false;
			this.lvTests.View = System.Windows.Forms.View.Details;
			this.lvTests.SelectedIndexChanged += new System.EventHandler(this.lvTests_SelectedIndexChanged);
			this.lvTests.DoubleClick += new System.EventHandler(this.lvTests_DoubleClick);
			this.lvTests.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvTests_KeyDown);
			this.lvTests.Resize += new System.EventHandler(this.lvTests_Resize);
			// 
			// TestName
			// 
			this.TestName.Text = "Test Name";
			this.TestName.Width = 320;
			// 
			// btnRunTest
			// 
			this.btnRunTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRunTest.Enabled = false;
			this.btnRunTest.Image = ((System.Drawing.Image)(resources.GetObject("btnRunTest.Image")));
			this.btnRunTest.Location = new System.Drawing.Point(444, 192);
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
			this.btnStats.Location = new System.Drawing.Point(410, 136);
			this.btnStats.Name = "btnStats";
			this.btnStats.Size = new System.Drawing.Size(132, 27);
			this.btnStats.TabIndex = 46;
			this.btnStats.Text = "Statistics...";
			this.btnStats.UseVisualStyleBackColor = true;
			this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(406, 280);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(132, 27);
			this.button1.TabIndex = 47;
			this.button1.Text = "Test";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// ProgTestsMgr
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnStats);
			this.Controls.Add(this.btnRunTest);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.lvTests);
			this.Name = "ProgTestsMgr";
			this.Size = new System.Drawing.Size(554, 322);
			this.Load += new System.EventHandler(this.ProgTestsMgr_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.ListView lvTests;
		private System.Windows.Forms.ColumnHeader TestName;
		private System.Windows.Forms.Button btnRunTest;
		private System.Windows.Forms.Button btnStats;
		private System.Windows.Forms.Button button1;
	}
}
