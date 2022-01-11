using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.ProgressionTests
{
	public partial class ProgExamForm : Form
	{
		#region Private classes

		private enum ExamState
		{
			Running,
			ReviewingAnswer,
			Paused,
			Finished
		}

		#endregion

		#region Fields

		//private readonly InputDevice.NoteOnHandler noteOnHandler;
		//private readonly InputDevice.NoteOffHandler noteOffHandler;
		private ExamState _state;
		private readonly IAppDataMgr _appDataMgr;

		#endregion

		#region Constructors / Initialization / Finalization

		public ProgExamForm(List<VoicingProgression> progressions, IAppDataMgr appDataMgr)
		{
			InitializeComponent();

			_appDataMgr = appDataMgr;
			this.Progressions = progressions;

			voicingCtl0.SetDegree(2);
			voicingCtl1.SetDegree(5);
			voicingCtl2.SetDegree(1);
			this.VoicingCtls = new List<VoicingExamCtl>{voicingCtl0, voicingCtl1, voicingCtl2};

			// Create persistent delegates which we can add and remove to events.
			//noteOnHandler = new InputDevice.NoteOnHandler(this.NoteOn);
			//noteOffHandler = new InputDevice.NoteOffHandler(this.NoteOff);
			//Form1.MainForm.InputMidiDevice.NoteOn += noteOnHandler;
			//Form1.MainForm.InputMidiDevice.NoteOff += noteOffHandler;

			this.PressedNoteIds = new List<int>();
			this.AnswerNoteIds = new List<int>();

			this.FailDelaySecs = _appDataMgr.AppData.WrongAnswerWaitSecs;
			this.AutoContinueOnFail = _appDataMgr.AppData.WrongAnswerWaitSecs > 0;
			this.PassDelaySecs = _appDataMgr.AppData.CorrectAnswerWaitSecs;
		}

		#endregion

		#region Properties

		private List<VoicingExamCtl> VoicingCtls { get; set; }

		private ProgTest Test { get; set; }

		private List<VoicingProgression> Progressions { get; set; }

		private List<VoicingProgression> TestProgressions { get; set; }

		private DateTime TestStartTime { get; set; }

		private DateTime TestTimeout { get; set; }

		private int QuestionCount { get; set; }

		private int CorrectAnswerCount { get; set; }

		private int CurrProgIndex { get; set; }

		private int CurrQuestionIndex { get; set; }

		private DateTime QuestionStartTime { get; set; }

		private DateTime QuestionTimeout { get; set; }

		private List<int> PressedNoteIds { get; set; }

		private List<int> AnswerNoteIds { get; set; }

		private int PassDelaySecs { get; set; }

		private bool AutoContinueOnFail { get; set; }

		private int FailDelaySecs { get; set; }

		private DateTime ReviewTimeout { get; set; }

		private DateTime PauseStartTime { get; set; }

		public bool SaveResults { get; set; }

		public TestResult TestResult { get; set; }

		private VoicingProgression CurrProgression
		{
			get { return this.TestProgressions[this.CurrProgIndex]; }
		}

		private Voicing CurrVoicing
		{
			get { return this.CurrProgression.Voicings[this.CurrQuestionIndex]; }
		}

		private VoicingExamCtl CurrVoicingCtl
		{
			get { return this.VoicingCtls[this.CurrQuestionIndex]; }
		}

		private void PauseTest()
		{
			timer1.Stop();
			this.State = ExamState.Paused;
			this.PauseStartTime = DateTime.Now;
		}

		private void ResumeTest()
		{
			int pauseSecs = DateTime.Now.Subtract(this.PauseStartTime).Seconds;
			this.QuestionTimeout = this.QuestionTimeout.AddSeconds(pauseSecs);
			this.TestTimeout = this.TestTimeout.AddSeconds(pauseSecs);
			this.PauseStartTime = DateTime.MinValue;
			timer1.Start();
			this.State = ExamState.Running;
		}

		private ExamState State
		{
			get { return _state; }
			set
			{
				_state = value;
				switch (_state) {
					case ExamState.Running:
						btnPause.Enabled = true;
						btnResume.Enabled = false;
						btnQuit.Enabled = true;
						break;
					case ExamState.Paused:
						btnPause.Enabled = false;
						btnResume.Enabled = true;
						btnQuit.Enabled = true;
						break;
					case ExamState.ReviewingAnswer:
						btnPause.Enabled = true;
						btnResume.Enabled = false;
						btnQuit.Enabled = true;
						break;
					case ExamState.Finished:
						btnPause.Enabled = false;
						btnResume.Enabled = false;
						btnQuit.Enabled = false;
						break;
				}
			}
		}

		#endregion

		public bool Run(ProgTest test)
		{
			try {
				// Build the list of voicings based on the test criteria
				this.TestProgressions = BuildTestProgressionList(test);
				if (this.TestProgressions.Count == 0)
					throw new KTException("This test results in no progressions based on the selected choices.");

				this.Test = test;
				StartTest();
				return ShowDialog() == DialogResult.OK;
			} catch (KTException ex) {
				MessageBox.Show(ex.Message);
				return false;
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Unexpected error: {0}", ex));
				return false;
			}
		}

		private void StartTest()
		{
			// Populate
			this.Text = string.Format("Progression Test - {0}", this.Test.Name);
			if (this.Test.ExamDurationSecs > 0) {
				lblExamTimeRemaining.Visible = true;
				lblExamTimeLbl.Visible = true;
				lblExamTimeRemaining.Text = Utils.TimeDisplay(this.Test.ExamDurationSecs);
			}
			if (this.Test.QuestionDurationSecs > 0) {
				lblQuestionTimeRemaining.Visible = true;
				lblQuestionTimeLbl.Visible = true;
				lblQuestionTimeRemaining.Text = Utils.TimeDisplay(this.Test.QuestionDurationSecs);
			}

			// Reset test variables
			this.TestStartTime = DateTime.Now;
			if (this.Test.ExamDurationSecs > 0)
				this.TestTimeout = this.TestStartTime.AddSeconds(this.Test.ExamDurationSecs);
			else
				this.TestTimeout = DateTime.MaxValue;
			this.QuestionCount = 0;
			this.CorrectAnswerCount = 0;

			this.CurrProgIndex = -1;
			this.CurrQuestionIndex = -1;

			this.TestResult = new TestResult();
			this.TestResult.TestId = this.Test.Id;
			this.TestResult.StartTime = DateTime.Now;

			NextQuestion();
			timer1.Start();
		}

		private void NextQuestion()
		{
			if (this.CurrProgIndex == -1) {
				this.CurrProgIndex = 0;
				this.CurrQuestionIndex = 0;
			} else if (this.CurrQuestionIndex < 2) {
				this.CurrQuestionIndex++;
			} else {
				if (this.CurrProgIndex < this.TestProgressions.Count - 1) {
					this.CurrProgIndex++;
					this.CurrQuestionIndex = 0;
				} else {
					this.CurrProgIndex = 0;
					this.CurrQuestionIndex = 0;
				}
			}

			// Reset
			this.PressedNoteIds.Clear();
			this.AnswerNoteIds.Clear();
			for (int i = 0; i < this.VoicingCtls.Count; i++)
				this.VoicingCtls[i].Visible = i <= this.CurrQuestionIndex;

			// Set
			keySymbol1.SetKey(this.CurrProgression.Key);
			lblForm.Text = string.Format("{0} Form", this.CurrProgression.VoicingForm);
			this.CurrVoicingCtl.SetVoicing(this.CurrVoicing);
			this.QuestionStartTime = DateTime.Now;
			this.QuestionTimeout = this.Test.QuestionDurationSecs > 0 ? this.QuestionStartTime.AddSeconds(this.Test.QuestionDurationSecs) : DateTime.MaxValue;

			this.State = ExamState.Running;
		}

		//public void NoteOn(NoteOnMessage msg)
		//{
		//	if (this.State != ExamState.Running)
		//		return;

		//	if (InvokeRequired) {
		//		BeginInvoke(noteOnHandler, msg);
		//		return;
		//	}

		//	var noteID = (int)msg.Pitch;

		//	if (this.State == ExamState.Running) {
		//		this.CurrVoicingCtl.PressPianoKey(noteID);
		//		this.PressedNoteIds.Add(noteID);
		//	}
		//}

		//public void NoteOff(NoteOffMessage msg)
		//{
		//	if (this.State != ExamState.Running)
		//		return;

		//	if (InvokeRequired) {
		//		BeginInvoke(noteOffHandler, msg);
		//		return;
		//	}

		//	var noteID = (int)msg.Pitch;

		//	if (this.State == ExamState.Running) {
		//		this.AnswerNoteIds.Add(noteID);
		//		this.PressedNoteIds.Remove(noteID);
		//		if (this.PressedNoteIds.Count == 0) {
		//			switch (CheckAnswer()) {
		//				case -1:		// Wrong
		//					EndQuestion(false);
		//					break;

		//				case 0:		// Correct
		//					EndQuestion(true);
		//					break;

		//				default:		// Not complete
		//					break;
		//			}
		//		}
		//	}
		//}

		private int CheckAnswer()
		{
			if (this.AnswerNoteIds.Where(noteId => !this.CurrVoicing.NoteIds.Contains(noteId)).Any())
				return -1; // Wrong

			if (this.AnswerNoteIds.Count < this.CurrVoicing.NoteIds.Count)
				return 1; // No wrong notes, but not complete yet

			return 0; // Correct!
		}

		private void EndQuestion(bool wasCorrect, bool isExamFinished = false)
		{
			this.CurrVoicingCtl.PlayButtonEnabled = true;

			if (isExamFinished) {
				this.State = ExamState.Finished;
				return;
			}

			this.AnswerNoteIds.Clear();
			this.QuestionCount++;

			if (wasCorrect) {
				// Pass
				this.CorrectAnswerCount++;
				this.CurrVoicingCtl.SetResult(AnswerResult.Correct);
				Refresh();
				StartReviewingAnswer(true);
			} else {
				// Fail
				this.CurrVoicingCtl.SetResult(AnswerResult.Wrong);
				PlayVoicing(this.CurrVoicing);
				Refresh();
				if (this.AutoContinueOnFail) {
					this.State = ExamState.ReviewingAnswer;
					StartReviewingAnswer(false);
				} else {
					this.State = ExamState.ReviewingAnswer;
				}
			}
		}

		private void StartReviewingAnswer(bool wasCorrect)
		{
			int waitSecs = -1;
			if (wasCorrect) {
				waitSecs = this.PassDelaySecs;
				this.ReviewTimeout = DateTime.Now.AddSeconds(waitSecs);
			} else {
				if (this.AutoContinueOnFail) {
					waitSecs = this.FailDelaySecs;
					this.ReviewTimeout = DateTime.Now.AddSeconds(this.FailDelaySecs);
				} else {
					this.ReviewTimeout = DateTime.MaxValue;
				}
			}

			if (waitSecs > -1)
				lblMessage.Text = string.Format("Next question in {0} seconds...", waitSecs);
			else
				lblMessage.Text = "Press spacebar to continue.";
			lblMessage.Visible = true;
			lblMessage.Refresh();

			this.State = ExamState.ReviewingAnswer;
		}

		private void EndReviewingAnswer()
		{
			lblMessage.Visible = false;
			lblMessage.Refresh();
			this.ReviewTimeout = DateTime.MaxValue;
			NextQuestion();
		}

		private void EndTest()
		{
			timer1.Stop();
			this.State = ExamState.Finished;

			this.TestResult.TotalDurationSecs = this.Test.ExamDurationSecs;
			this.TestResult.TotalQuestions = this.QuestionCount;
			this.TestResult.TotalCorrect = this.CorrectAnswerCount;

			//using (VoicingTestResultsForm resultsForm = new VoicingTestResultsForm())
			//	this.SaveResults = resultsForm.Run(this.TestResult, this.Test);

			this.DialogResult = DialogResult.OK;
			Hide();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			// See if it's the end of the test
			if (DateTime.Now > this.TestTimeout) {
				EndQuestion(false, true);
				EndTest();
				return;
			}

			if (this.State == ExamState.Running) {
				// See if the question timed out
				if (DateTime.Now > this.QuestionTimeout)
					EndQuestion(false);
				UpdateQuestionTime();
			} else if (this.State == ExamState.ReviewingAnswer) {
				if (DateTime.Now > this.ReviewTimeout) {
					EndReviewingAnswer();
				}
			}

			// Set time displays
			UpdateExamTime();
		}

		private void UpdateExamTime()
		{
			if (this.Test.ExamDurationSecs > 0) {
				int remSecs = Convert.ToInt32(this.TestTimeout.Subtract(DateTime.Now).TotalSeconds);
				if (remSecs < 0)
					remSecs = 0;
				lblExamTimeRemaining.Text = Utils.TimeDisplay(remSecs);
			}
		}

		private void UpdateQuestionTime()
		{
			if (this.Test.QuestionDurationSecs > 0) {
				int remSecs = Convert.ToInt32(this.QuestionTimeout.Subtract(DateTime.Now).TotalSeconds);
				if (remSecs < 0)
					remSecs = 0;
				lblQuestionTimeRemaining.Text = Utils.TimeDisplay(remSecs);
			}
		}

		private void PlayVoicing(Voicing voicing)
		{
			if (voicing == null)
				return;
			this.CurrVoicingCtl.SetNoteIDs(voicing.NoteIds);

			//foreach (var noteId in voicing.NoteIds) {
			//	Form1.MainForm.OutputMidiDevice.SendNoteOn(Channel.Channel1, (Pitch)noteId, 100);
			//}
			//Thread.Sleep(350);
			//foreach (var noteId in voicing.NoteIds) {
			//	Form1.MainForm.OutputMidiDevice.SendNoteOff(Channel.Channel1, (Pitch)noteId, 100);
			//}
		}

		private List<VoicingProgression> BuildTestProgressionList(ProgTest test)
		{
			List<VoicingProgression> filteredList = this.Progressions.Where(prog =>
				(test.IncludeAForm && prog.VoicingForm == VoicingForm.A) ||
				(test.IncludeBForm && prog.VoicingForm == VoicingForm.B) ||
				(test.IncludeOpenForm && prog.VoicingForm == VoicingForm.Open) ||
				(test.IncludeAABForm && prog.VoicingForm == VoicingForm.AAB) ||
				(test.IncludeBBAForm && prog.VoicingForm == VoicingForm.BBA)).ToList();

			filteredList.Shuffle();

			return filteredList;
		}

		private void VoicingExamForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) {
				if (this.State == ExamState.ReviewingAnswer)
					if (this.State == ExamState.ReviewingAnswer) {
						EndReviewingAnswer();
						e.SuppressKeyPress = true;
					}
			} else if (e.KeyCode == Keys.ControlKey) {
				if (this.State == ExamState.ReviewingAnswer)
					PlayVoicing(this.CurrVoicing);
			}
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			EndTest();
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			PauseTest();
		}

		private void btnResume_Click(object sender, EventArgs e)
		{
			ResumeTest();
		}
	}
}