using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using KeysTeacher.Data;
using KeysTeacher.HomeControls;
using KeysTeacher.Misc;
using KeysTeacher.Tests.VoicingLibs;

namespace KeysTeacher.Tests.VoicingTests
{
	public partial class VoicingTestsMgr : HomeControlBase, IVoicingTestsMgr
	{
		#region Events

		public event EventHandler<ShowVoicingTestEditorArgs> ShowVoicingTestEditor;

		#endregion

		#region Constants

		public const string TestResultsFilename = "VoicingTestResults.dat";

		#endregion

		#region Fields

		private List<TestResult> _testResults;
		private readonly IVoicingTestRepository _voicingTestRepository;
		private readonly IMsgBox _msgBox;
		private readonly ILifetimeScope _lifetimeScope;

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingTestsMgr(IVoicingTestRepository voicingTestRepository, IMsgBox msgBox, ILifetimeScope lifetimeScope)
		{
			InitializeComponent();
			_voicingTestRepository = voicingTestRepository;
			_voicingTestRepository.Changed += VoicingTestRepository_Changed;
			_msgBox = msgBox;
			_lifetimeScope = lifetimeScope;
		}

		private void VoicingTestRepository_Changed(object sender, EventArgs e)
		{
			this.UpdateTests();
		}

		private void VoicingTestsMgr_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode) {
				this.UpdateTests();
			}
		}

		private void UpdateTests()
		{
			var selectedTestId = 0;
			var selectedTest = lbxVoicingTests.SelectedItem as VoicingTest;
			if (selectedTest != null)
				selectedTestId = selectedTest.Id;

			this.Tests = new BindingList<VoicingTest>(_voicingTestRepository.GetAllVoicingTests());
			lbxVoicingTests.DataSource = this.Tests;
			lbxVoicingTests.ResetBindings();

			if (selectedTestId > 0) {
				foreach (var item in lbxVoicingTests.Items) {
					if (((VoicingTest) item).Id == selectedTestId) {
						lbxVoicingTests.SelectedItem = item;
						break;
					}
				}
			}
		}

		#endregion

		#region Properties

		public BindingList<VoicingTest> Tests { get; set; }

		public List<TestResult> TestResults => _testResults ?? (_testResults = LoadTestResults());

		public string TestResultsFilepath => Path.Combine(Globals.DataRootFolder, TestResultsFilename);

		#endregion

		private void InvokeShowVoicingTestEditorArgs(VoicingTest voicingTest)
		{
			ShowVoicingTestEditor?.Invoke(this, new ShowVoicingTestEditorArgs(voicingTest));
		}

		#region UI Events

		private void lbxVoicingTests_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enabled = lbxVoicingTests.SelectedIndices.Count > 0;
			btnEdit.Enabled = enabled;
			btnDuplicate.Enabled = enabled;
			btnDelete.Enabled = enabled;
			btnRunTest.Enabled = enabled;
			btnStats.Enabled = enabled;
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			AddNewTest();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditTest();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DeleteTest();
		}

		private void btnRunTest_Click(object sender, EventArgs e)
		{
			if (lbxVoicingTests.SelectedItems.Count == 1)
				RunTest();
		}

		private void lbxTests_DoubleClick(object sender, EventArgs e)
		{
			if (lbxVoicingTests.SelectedItems.Count == 1)
				EditTest();
		}

		private void lbxTests_KeyDown(object sender, KeyEventArgs e)
		{
			if (lbxVoicingTests.SelectedItems.Count != 1)
				return;

			if (e.KeyCode == Keys.Delete)
				DeleteTest();
			else if (e.KeyCode == Keys.Enter)
				EditTest();
			else if (e.KeyCode == Keys.R)
				RunTest();
		}

		#endregion

		#region Methods

		private void AddNewTest()
		{
			InvokeShowVoicingTestEditorArgs(null);
		}

		private void EditTest()
		{
			var voicingTest = lbxVoicingTests.SelectedItem as VoicingTest;
			if (voicingTest == null)
				return;

			InvokeShowVoicingTestEditorArgs(voicingTest);
		}

		public void EditTestComplete(VoicingTest voicingTest)
		{
			if (!this.Tests.Contains(voicingTest))
				this.Tests.Add(voicingTest);
			else
				this.Tests.ResetBindings();
		}

		private void DeleteTest()
		{
			var voicingTest = lbxVoicingTests.SelectedItem as VoicingTest;
			if (voicingTest == null)
				return;

			if (_msgBox.ShowError($"Delete test '{voicingTest.Name}? This will also delete all test results associated with this test...", "Confirm Delete") == DialogResult.OK) {
				_voicingTestRepository.Delete(voicingTest.Id);
				this.Tests.Remove(voicingTest);
				this.TestResults.RemoveAll(tr => tr.TestId == voicingTest.Id);
			}
		}

		private void RunTest()
		{
			var voicingTest = GetSelectedTest();
			if (voicingTest == null)
				return;

			using (var scope = _lifetimeScope.BeginLifetimeScope()) {
				using (var examForm = scope.Resolve<IVoicingExamForm>()) {
					if (examForm.Run(voicingTest)) {
						if (examForm.SaveResults) {
							if (examForm.TestResult == null) {
								_msgBox.ShowError("Null Test Result trying to save.", "Error");
								return;
							}
							this.TestResults.Add(examForm.TestResult);
							SaveTestResults();
						}
						if (examForm.TestResult.AddWrongAnswersToErrorsTest) {
							if (examForm.TestResult.WrongAnswerVoicings.Count > 0) {
								AddWrongAnswerVoicings(examForm.TestResult);
							}
						}
					}
				}
			}
		}

		private void AddWrongAnswerVoicings(TestResult testResult)
		{
			var errorsTestName = $"{testResult.TestName} - Errors";

			var errorsTest = _voicingTestRepository.GetVoicingTestByName(errorsTestName);
			if (errorsTest == null) {
				errorsTest = new VoicingTest();
				errorsTest.Id = _voicingTestRepository.GetNewTestId();
				errorsTest.Name = errorsTestName;
				errorsTest.Description = $"Errors from test {testResult.TestName}";
				errorsTest.ExamDurationSecs = 0;
				errorsTest.InclBassNote = true;
				errorsTest.QuestionDurationSecs = 0;
			}

			foreach (var wrongAnswerVoicing in testResult.WrongAnswerVoicings)
				if (errorsTest.Voicings.All(v => v.ToString() != wrongAnswerVoicing.ToString()))
					errorsTest.Voicings.Add(wrongAnswerVoicing);

			_voicingTestRepository.Save(errorsTest);
		}

		private VoicingTest GetSelectedTest()
		{
			return lbxVoicingTests.SelectedItem as VoicingTest;
		}

		#endregion

		#region Test Results

		private void SaveTestResults()
		{
			try {

				Utils.XmlSerializeToFile(this.TestResults, this.TestResultsFilepath);
			}
			catch (Exception ex) {
				MessageBox.Show(string.Format("Error trying to save test results: {0}", ex.Message));
			}
		}

		private List<TestResult> LoadTestResults()
		{
			List<TestResult> testResults = null;
			if (File.Exists(this.TestResultsFilepath)) {
				try {
					testResults = Utils.XmlDeserializeFromFile<List<TestResult>>(this.TestResultsFilepath);
				}
				catch { }
			}
			if (testResults == null)
				testResults = new List<TestResult>();

			return testResults;
		}

		private void btnStats_Click(object sender, EventArgs e)
		{
			var voicingTest = GetSelectedTest();
			if (voicingTest == null)
				return;

			List<TestResult> testResults = this.TestResults.Where(tr => tr.TestId == voicingTest.Id).ToList();
			if (testResults.Count == 0) {
				MessageBox.Show("There are no test results for this test.");
				return;
			}

			using (TestStatsForm statsForm = new TestStatsForm()) {
				statsForm.Run(testResults, voicingTest.Name);
			}
		}

		#endregion
	}
}