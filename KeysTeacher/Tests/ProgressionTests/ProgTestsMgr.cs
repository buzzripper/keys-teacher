using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KeysTeacher.HomeControls;
using KeysTeacher.Tests;
using KeysTeacher.Tests.ProgressionTests;

namespace KeysTeacher
{
	public partial class ProgTestsMgr : HomeControlBase
	{
		#region Constants

		private const string TestResultsFilename = "ProgTestResults.dat";

		#endregion

		#region Fields

		private List<TestResult> _testResults;
		private readonly IAppDataMgr _appDataMgr;

		#endregion

		#region Constructors / Initialization / Finalization

		public ProgTestsMgr(IAppDataMgr appDataMgr)
		{
			_appDataMgr = appDataMgr;
			InitializeComponent();
		}

		public ProgTestsMgr(List<ProgTest> tests, List<VoicingProgression> progressions, IAppDataMgr appDataMgr)
			: this(appDataMgr)
		{
			this.Tests = tests;
			this.Progressions = progressions;
		}

		private void ProgTestsMgr_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
				PopulateTestList();
		}

		#endregion

		#region Properties

		public List<ProgTest> Tests { get; set; }

		public List<VoicingProgression> Progressions { get; set; }

		public List<TestResult> TestResults
		{
			get { return _testResults ?? (_testResults = LoadTestResults()); }
		}

		#endregion

		#region UI Events

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
			if (lvTests.SelectedItems.Count == 1)
				RunTest();
		}

		private void lvTests_DoubleClick(object sender, EventArgs e)
		{
			if (lvTests.SelectedItems.Count == 1)
				EditTest();
		}

		private void lvTests_KeyDown(object sender, KeyEventArgs e)
		{
			if (lvTests.SelectedItems.Count != 1)
				return;

			if (e.KeyCode == Keys.Delete)
				DeleteTest();
			else if (e.KeyCode == Keys.Enter)
				EditTest();
			else if (e.KeyCode == Keys.R)
				RunTest();
		}

		private void lvTests_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool enabled = lvTests.SelectedIndices.Count > 0;
			btnEdit.Enabled = enabled;
			btnDelete.Enabled = enabled;
			btnRunTest.Enabled = enabled;
			btnStats.Enabled = enabled;
		}

		private void lvTests_Resize(object sender, EventArgs e)
		{
			lvTests.Columns[0].Width = lvTests.Width - 2;
		}

		#endregion

		#region Methods

		private void PopulateTestList()
		{
			lvTests.SuspendLayout();
			try {
				lvTests.Items.Clear();
				for (int i = 0; i < this.Tests.Count; i++) {
					ProgTest test = this.Tests[i];
					ListViewItem item = new ListViewItem{Text = test.Name};
					item.SubItems.Add(test.Description);
					item.Tag = i;
					lvTests.Items.Add(item);
				}
			} finally {
				lvTests.ResumeLayout();
			}
		}

		private void AddNewTest()
		{
			int newTestId;
			if (this.Tests.Count > 0)
				newTestId = this.Tests.Max(t => t.Id) + 1;
			else
				newTestId = 1;
			ProgTest newTest = ProgTest.CreateTest(newTestId);
			RunSetupForm(newTest, true);
		}

		private void EditTest()
		{
			if (lvTests.SelectedItems.Count == 0)
				return;
			ProgTest test = this.Tests[(int) lvTests.SelectedItems[0].Tag];
			RunSetupForm(test, false);
		}

		private void RunSetupForm(ProgTest test, bool isNew)
		{
			DialogResult dialogResult;
			using (ProgTestSetupForm setupForm = new ProgTestSetupForm()) {
				dialogResult = setupForm.Run(Form1.MainForm, test);
				if (dialogResult == DialogResult.OK) {
					if (isNew)
						this.Tests.Add(test);
					InvokeNeedSavingEvent();
					PopulateTestList();
					SelectTestInListView(test);
				} else if (dialogResult == DialogResult.Yes) {
					// Run Now
					if (setupForm.SaveFirst) {
						if (isNew)
							this.Tests.Add(test);
						InvokeNeedSavingEvent();
						PopulateTestList();
						SelectTestInListView(test);
					}
					RunTest();
				}
			}
		}

		private void DeleteTest()
		{
			if (lvTests.SelectedItems.Count == 0)
				return;
			ProgTest test = this.Tests[(int) lvTests.SelectedItems[0].Tag];
			if (MessageBox.Show(string.Format("Delete test '{0}? This will also delete all test results associated with this test...", test.Name), "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK) {
				this.Tests.Remove(test);
				this.TestResults.RemoveAll(tr => tr.TestId == test.Id);
				InvokeNeedSavingEvent();
				PopulateTestList();
			}
		}

		private void RunTest()
		{
			if (lvTests.SelectedItems.Count == 0)
				return;

			ProgTest test = this.Tests[(int) lvTests.SelectedItems[0].Tag];

			using (ProgExamForm examForm = new ProgExamForm(this.Progressions, _appDataMgr)) {
				if (examForm.Run(test)) {
					if (examForm.SaveResults) {
						if (examForm.TestResult == null) {
							MessageBox.Show("Null Test Result trying to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						this.TestResults.Add(examForm.TestResult);
						SaveTestResults();
					}
				}
				examForm.Close();
			}
		}

		private void SelectTestInListView(ProgTest test)
		{
			int idx = this.Tests.IndexOf(test);
			for (int i = 0; i < lvTests.Items.Count; i++) {
				ListViewItem item = lvTests.Items[i];
				if ((int) item.Tag == idx) {
					lvTests.SelectedItems.Clear();
					lvTests.SelectedIndices.Add(i);
				}
			}
		}

		#endregion

		#region Test Results

		private void SaveTestResults()
		{
			try {
				string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestResultsFilename);
				Utils.XmlSerializeToFile(this.TestResults, filepath);
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Error trying to save test results: {0}", ex.Message));
			}
		}

		private static List<TestResult> LoadTestResults()
		{
			List<TestResult> testResults = null;
			string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TestResultsFilename);
			if (File.Exists(filepath)) {
				try {
					testResults = Utils.XmlDeserializeFromFile<List<TestResult>>(filepath);
				} catch {}
			}
			if (testResults == null)
				testResults = new List<TestResult>();

			return testResults;
		}

		#endregion

		private void btnStats_Click(object sender, EventArgs e)
		{
			ProgTest test = this.Tests[(int) lvTests.SelectedItems[0].Tag];

			List<TestResult> testResults = this.TestResults.Where(tr => tr.TestId == test.Id).ToList();
			if (testResults.Count == 0) {
				MessageBox.Show("There are no test results for this test.");
				return;
			}

			using (TestStatsForm statsForm = new TestStatsForm()) {
				statsForm.Run(testResults, test.Name);
			}
		}
	}
}