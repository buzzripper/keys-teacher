namespace KeysTeacher
{
	partial class MidiDeviceForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.lbxOutput = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbxInput = new System.Windows.Forms.ListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "MIDI OutputDevice";
			// 
			// lbxOutput
			// 
			this.lbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxOutput.FormattingEnabled = true;
			this.lbxOutput.Location = new System.Drawing.Point(10, 130);
			this.lbxOutput.Name = "lbxOutput";
			this.lbxOutput.Size = new System.Drawing.Size(303, 69);
			this.lbxOutput.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "MIDI Input Device";
			// 
			// lbxInput
			// 
			this.lbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxInput.FormattingEnabled = true;
			this.lbxInput.Location = new System.Drawing.Point(10, 30);
			this.lbxInput.Name = "lbxInput";
			this.lbxInput.Size = new System.Drawing.Size(303, 69);
			this.lbxInput.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(239, 217);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(144, 217);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// MidiDeviceForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(326, 252);
			this.ControlBox = false;
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbxOutput);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbxInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MidiDeviceForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MidiDeviceForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbxOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbxInput;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
	}
}