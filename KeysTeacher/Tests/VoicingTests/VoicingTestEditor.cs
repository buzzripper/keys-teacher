using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using KeysTeacher.Data;
using KeysTeacher.HomeControls;
using KeysTeacher.Misc;
using KeysTeacher.Music;
using KeysTeacher.Tests.Authoring;
using KeysTeacher.Tests.VoicingLibs;

namespace KeysTeacher.Tests.VoicingTests
{
	public partial class VoicingTestEditor : HomeControlBase, IVoicingTestEditor
	{
		#region Events

		public event EventHandler<EditVoicingTestCompleteArgs> EditVoicingTestComplete;

		#endregion

		#region Fields

		private readonly IVoicingTestRepository _voicingTestRepository;
		private readonly IVoicingLibraryForm _voicingLibForm;
		private readonly IVoicingEditorForm _voicingEditorForm;
		private readonly IMsgBox _msgBox;
		private BindingList<Voicing> _voicings;

		#endregion

		#region Ctor

		public VoicingTestEditor(IVoicingTestRepository voicingTestRepository, IVoicingLibraryForm voicingLibForm, IMsgBox msgBox, IVoicingEditorForm voicingEditorForm)
		{
			InitializeComponent();

			_voicingTestRepository = voicingTestRepository;

			_voicingLibForm = voicingLibForm;
			_voicingLibForm.VoicingsSelected += VoicingLibFormVoicingsSelected;

			_msgBox = msgBox;
			_voicingEditorForm = voicingEditorForm;
		}

		#endregion

		#region Properties

		public VoicingTest VoicingTest { get; private set; }

		#endregion

		#region Public Methods

		public void Run(VoicingTest voicingTest)
		{
			this.VoicingTest = voicingTest ?? CreateNewVoicingTest();
			_voicings = new BindingList<Voicing>(this.VoicingTest.Voicings);

			PopulateForm();

			txtName.SelectAll();
			txtName.Focus();
		}

		private void PopulateForm()
		{
			txtName.Text = this.VoicingTest.Name;
			numQuestionDuration.Value = this.VoicingTest.QuestionDurationSecs;
			numExamDuration.Value = this.VoicingTest.ExamDurationSecs;
			ckbInclBassNote.Checked = this.VoicingTest.InclBassNote;

			lbxVoicings.DataSource = _voicings;
		}

		#endregion

		#region UI Events

		private void btnVoicingLibarary_Click(object sender, EventArgs e)
		{
			if (_voicingLibForm.Visible)
				HideVoicingLibrary();
			else
				ShowVoicingLibrary();
		}

		private void ShowVoicingLibrary()
		{
			var parentForm = GetParentForm();
			_voicingLibForm.Show(parentForm.Left + parentForm.Width - 12, parentForm.Top, parentForm.Height);
		}

		private void HideVoicingLibrary()
		{
			_voicingLibForm.Hide();
		}

		private void VoicingLibFormVoicingsSelected(object sender, SelectVoicingsArgs e)
		{
			var voicingsToAdd = new List<Voicing>();
			foreach (var voicing in e.Voicings) {
				if (_voicings.All(v => v.ToString() != voicing.ToString())) {
					voicingsToAdd.Add(voicing);
				}
			}
			AddAndSaveVoicings(voicingsToAdd);
		}

		private void lbxVoicings_SelectedIndexChanged(object sender, EventArgs e)
		{
			var enabled = lbxVoicings.SelectedItems.Count > 0;
			btnDelete.Enabled = enabled;
			btnEdit.Enabled = lbxVoicings.SelectedItems.Count == 1;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var newVoicing = new Voicing();
			if (EditVoicing(newVoicing)) {
				AddAndSaveVoicings(new List<Voicing> { newVoicing });
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditVoicing();
		}

		private void lbxVoicings_DoubleClick(object sender, EventArgs e)
		{
			EditVoicing();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DeleteVoicings();
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtName.Text)) {
				_msgBox.ShowError($"You must enter a name.");
				return;
			}

			if (HasChanges()) {
				this.UpdateName(this.VoicingTest.Name, txtName.Text);
				this.VoicingTest.Name = txtName.Text;
				this.VoicingTest.QuestionDurationSecs = (int)numQuestionDuration.Value;
				this.VoicingTest.ExamDurationSecs = (int)numExamDuration.Value;
				this.VoicingTest.InclBassNote = ckbInclBassNote.Checked;
				this.Save();
			}

			InvokeEditVoicingTestComplete(this.VoicingTest);
			_voicingLibForm.Hide();
		}

		#endregion

		#region Private Methods

		private Form GetParentForm()
		{
			return GetParent(this) as Form;	
		}

		private Control GetParent(Control control)
		{
			var parent = control.Parent;
			if (parent is Form1)
				return parent;
			// Recurse
			return GetParent(parent);
		}

		private void AddAndSaveVoicings(List<Voicing> voicings)
		{
			foreach (var voicing in voicings) {
				_voicings.Add(voicing);
			}
			this.Save();
		}

		private void EditVoicing()
		{
			if (lbxVoicings.SelectedItems.Count != 1)
				return;

			var voicing = lbxVoicings.SelectedItem as Voicing;
			if (voicing == null) {
				_msgBox.ShowError("The selected voicing is null.", "Internal Error");
				return;
			}

			// Send a clone to the editor
			if (_voicingEditorForm.Run(voicing.Clone())) {
				voicing.CopyFrom(_voicingEditorForm.Voicing);
				this.Save();
				lbxVoicings.ResetBindings();
			}
		}

		private bool EditVoicing(Voicing voicing)
		{
			return _voicingEditorForm.Run(voicing);
		}

		private void Save()
		{
			try {
				this.VoicingTest.Voicings = _voicings.ToList();
				_voicingTestRepository.Save(this.VoicingTest);
			}
			catch (Exception ex) {
				MessageBox.Show($"{ex.GetType().Name} saving test: {ex.Message}", "Error Saving Test", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private VoicingTest CreateNewVoicingTest()
		{
			var voicingTest = new VoicingTest();
			voicingTest.Id = _voicingTestRepository.GetNewTestId();
			voicingTest.Name = _voicingTestRepository.GetUniqueTestName();
			voicingTest.ExamDurationSecs = 0;
			voicingTest.QuestionDurationSecs = 0;
			voicingTest.InclBassNote = false;

			return voicingTest;
		}

		private void InvokeEditVoicingTestComplete(VoicingTest voicingTest)
		{
			EditVoicingTestComplete?.Invoke(this, new EditVoicingTestCompleteArgs(voicingTest));
		}

		private bool HasChanges()
		{
			return (txtName.Text != this.VoicingTest.Name ||
					(int)numQuestionDuration.Value != this.VoicingTest.QuestionDurationSecs ||
					(int)numExamDuration.Value != this.VoicingTest.ExamDurationSecs ||
					ckbInclBassNote.Checked != this.VoicingTest.InclBassNote);
		}

		private void UpdateName(string oldName, string newName)
		{
			try {
				_voicingTestRepository.UpdateName(oldName, newName);
			}
			catch (Exception ex) {
				_msgBox.ShowError($"{ex.GetType().Name} saving test: {ex.Message}", "Error Saving Test");
			}
		}

		private void DeleteVoicings()
		{
			var voicingsToDelete = new List<Voicing>();
			foreach (var selectedItem in lbxVoicings.SelectedItems)
				voicingsToDelete.Add(selectedItem as Voicing);

			foreach (var voicing in voicingsToDelete) {
				_voicings.Remove(voicing);
			}

			this.Save();

			lbxVoicings.ResetBindings();
			lbxVoicings.Focus();
		}

		#endregion
	}
}