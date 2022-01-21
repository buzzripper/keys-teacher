using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using KeysTeacher.Devices;
using KeysTeacher.Music;
using KeysTeacher.Tests.VoicingLibs;

namespace KeysTeacher.Tests.VoicingTests
{
	public partial class VoicingExamForm : Form, IVoicingExamForm
	{
		#region Private classes

		private enum ExamState
		{
			Running,
			ReviewingAnswer,
			Paused,
			ReviewingPaused,
			Finished
		}

		#endregion

		#region Fields

		private ExamState _state;
		private readonly IMidiInDevice _midiInDevice;
		private readonly IMidiOutDevice _midiOutDevice;
		private readonly IVoicingTestResultsForm _voicingResultsForm;
		private readonly IAppDataMgr _appDataMgr;
		private bool _autoContinue;
		private List<Voicing> _testVoicings;

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingExamForm(IMidiInDevice midiInDevice, IMidiOutDevice midiOutDevice, IVoicingTestResultsForm voicingResultsForm, IAppDataMgr appDataMgr)
		{
			InitializeComponent();

			_midiInDevice = midiInDevice;
			_midiOutDevice = midiOutDevice;
			_voicingResultsForm = voicingResultsForm;
			_appDataMgr = appDataMgr;

			this.ResultPics = new Bitmap[2];
			this.ResultPics[0] = Utils.GetBmpFromResource(string.Format("{0}.correct_48.gif", Globals.ImgsRoot));
			this.ResultPics[1] = Utils.GetBmpFromResource(string.Format("{0}.wrong_48.gif", Globals.ImgsRoot));

			this.PressedNoteIds = new List<int>();
			this.AnswerNoteIds = new List<int>();
		}

		private void VoicingExamForm_Load(object sender, EventArgs e)
		{
			this.Size = new Size(this.Width + 1, this.Height + 1);
		}

		private void VoicingExamForm_Shown(object sender, EventArgs e)
		{
		}

		#endregion

		#region Properties

		private Bitmap[] ResultPics { get; set; }

		private VoicingTest Test { get; set; }

		private DateTime TestStartTime { get; set; }

		private DateTime TestTimeout { get; set; }

		private int QuestionCount { get; set; }

		private int CorrectAnswerCount { get; set; }

		private int CurrIndex { get; set; }

		private DateTime QuestionStartTime { get; set; }

		private DateTime PauseStartTime { get; set; }

		private DateTime QuestionTimeout { get; set; }

		private int PressedBassNoteId { get; set; }

		private List<int> PressedNoteIds { get; set; }

		private List<int> AnswerNoteIds { get; set; }

		private DateTime ReviewTimeout { get; set; }

		public bool SaveResults { get; set; }

		public TestResult TestResult { get; set; }

		private Voicing CurrVoicing
		{
			get { return voicingSymbol1.Voicing; }
			set {
				voicingSymbol1.Voicing = value;
				voicingSymbol1.Visible = value != null;
			}
		}

		private ExamState State
		{
			get { return _state; }
			set {
				switch (_state)
				{
					case ExamState.Running:
						SetStateRunning(_state);
						break;

					case ExamState.Paused:
						SetStatePaused(_state);
						break;

					case ExamState.ReviewingAnswer:
						SetStateReviewingPaused(_state);
						break;

					case ExamState.ReviewingPaused:
						SetStateReviewingAnswer(_state);
						break;

					case ExamState.Finished:
						SetStateFinished(_state);
						break;
				}
				_state = value;
			}
		}

		private void SetStateRunning(ExamState prevState)
        {
			SetPaused(false);
			btnPlayVoicing.Enabled = false;
			btnQuit.Enabled = true;
		}

		private void SetStatePaused(ExamState prevState)
		{
			SetPaused(true);
			btnPlayVoicing.Enabled = false;
			btnQuit.Enabled = true;
		}

		private void SetStateReviewingAnswer(ExamState prevState)
		{
			SetPaused(false);
			btnPlayVoicing.Enabled = true;
			btnQuit.Enabled = true;
		}

		private void SetStateReviewingPaused(ExamState prevState)
		{
			SetPaused(true);
			btnPlayVoicing.Enabled = true;
			btnQuit.Enabled = true;
		}

		private void SetStateFinished(ExamState prevState)
		{
			SetPaused(true);
			btnPause.Enabled = false;
			btnPlayVoicing.Enabled = true;
			btnQuit.Enabled = false;
		}

		private void SetPaused(bool isPaused)
        {
			if (isPaused) {
				btnPause.Text = "Resume";
				btnPause.BackColor = Color.RosyBrown;
			} else {
				btnPause.Text = "Pause";
				btnPause.BackColor = Color.LightSteelBlue;
			}
			btnPause.Enabled = true;
		}

		#endregion

		public bool Run(VoicingTest test)
		{
			try
			{
				this.Test = test;
				lblTestName.Text = test.Name;
				StartTest();
				return ShowDialog() == DialogResult.OK;
			}
			catch (KTException ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Unexpected error: {0}", ex));
				return false;
			}
		}

		private void StartTest()
		{
			// Populate
			this.Text = string.Format("Voicing Test - {0}", this.Test.Name);
			if (this.Test.ExamDurationSecs > 0)
			{
				lblExamTimeRemaining.Visible = true;
				//lblExamTimeLbl.Visible = true;
				lblExamTimeRemaining.Text = Utils.TimeDisplay(this.Test.ExamDurationSecs);
			}
			if (this.Test.QuestionDurationSecs > 0)
			{
                lblQuestionTimeRemaining.Visible = true;
                //lblQuestionTimeLbl.Visible = true;
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

			_autoContinue = _appDataMgr.AppData.WrongAnswerWaitSecs > 0;

			_testVoicings = this.Test.Voicings;
			_testVoicings.Shuffle().Shuffle().Shuffle();

			this.CurrVoicing = null;

			this.TestResult = new TestResult();
			this.TestResult.TestId = this.Test.Id;
			this.TestResult.TestName = this.Test.Name;
			this.TestResult.StartTime = DateTime.Now;

			NextQuestion();
			EnableMidiInput(true);
			timer1.Start();
		}

		private void NextQuestion()
		{
			if (this.CurrVoicing == null)
			{
				this.CurrIndex = 0;
			}
			else
			{
				if (this.CurrIndex == _testVoicings.Count - 1)
				{
					this.CurrIndex = 0;
					_testVoicings.Shuffle().Shuffle().Shuffle();
				}
				else
				{
					this.CurrIndex++;
				}
			}

			// Reset
			this.PressedNoteIds.Clear();
			this.PressedBassNoteId = 0;
			this.AnswerNoteIds.Clear();
			pianoControl1.ReleaseAllPianoKeys();
			picResult.Image = null;

			// Set
			this.CurrVoicing = _testVoicings[this.CurrIndex];
			this.QuestionStartTime = DateTime.Now;
			this.QuestionTimeout = this.Test.QuestionDurationSecs > 0 ? this.QuestionStartTime.AddSeconds(this.Test.QuestionDurationSecs) : DateTime.MaxValue;

			this.State = ExamState.Running;
		}

		private void EnableMidiInput(bool enable)
		{
			if (enable)
			{
				_midiInDevice.NoteOn += MidiInDevice_NoteOn;
				_midiInDevice.NoteOff += MidiInDevice_NoteOff;
			}
			else
			{
				_midiInDevice.NoteOn -= MidiInDevice_NoteOn;
				_midiInDevice.NoteOff -= MidiInDevice_NoteOff;
			}
		}

		private void MidiInDevice_NoteOn(object sender, NoteEventArgs e)
		{
			if (this.State != ExamState.Running)
				return;

			if (this.State == ExamState.Running)
			{
				pianoControl1.PressPianoKey(e.NoteNumber);

				if (IsBassNote(e.NoteNumber))
					this.PressedBassNoteId = e.NoteNumber;
				else
					this.PressedNoteIds.Add(e.NoteNumber);
			}
		}

		private void MidiInDevice_NoteOff(object sender, NoteEventArgs e)
		{
			if (this.State == ExamState.Running)
			{
				if (!IsBassNote(e.NoteNumber))
				{
					this.AnswerNoteIds.Add(e.NoteNumber);
					this.PressedNoteIds.Remove(e.NoteNumber);
				}

				if (this.PressedNoteIds.Count == 0)
				{
					switch (CheckAnswer())
					{
						case -1:        // Wrong
							EndQuestion(false);
							break;
						case 0:     // Correct
							EndQuestion(true);
							break;
					}
				}
			}
		}

		private bool IsBassNote(int noteId)
		{
			return this.Test.InclBassNote && noteId == this.CurrVoicing.BassNoteId;
		}

		private int CheckAnswer()
		{
			if (this.AnswerNoteIds.Any(noteId => !this.CurrVoicing.NoteIds.Contains(noteId)))
				return -1; // Wrong

			if (this.AnswerNoteIds.Count < this.CurrVoicing.NoteIds.Count)
				return 1; // No wrong notes, but not complete yet

			if (this.Test.InclBassNote && this.PressedBassNoteId == 0)
				return 1; // No wrong notes, but bass note not selected yet

			return 0; // Correct!
		}

		private void EndQuestion(bool wasCorrect, bool isExamFinished = false)
		{
			if (isExamFinished)
			{
				picResult.Image = null;
				this.State = ExamState.Finished;
				return;
			}

			this.AnswerNoteIds.Clear();
			this.QuestionCount++;

			if (wasCorrect)
			{
				// Pass
				this.CorrectAnswerCount++;
				picResult.Image = this.ResultPics[0];
				Refresh();
				picResult.Visible = true;
				BeginReviewingAnswer(true);
			}
			else
			{
				// Fail
				picResult.Image = this.ResultPics[1];
				picResult.Visible = true;
				PlayVoicing(this.CurrVoicing);
				Refresh();
				this.TestResult.WrongAnswerVoicings.Add(this.CurrVoicing);
				BeginReviewingAnswer(false);
			}
		}

		private void BeginReviewingAnswer(bool wasCorrect)
		{
			if (_autoContinue)
			{
				this.ReviewTimeout = DateTime.Now.AddSeconds(wasCorrect ? _appDataMgr.AppData.CorrectAnswerWaitSecs : _appDataMgr.AppData.WrongAnswerWaitSecs);
				pbReview.Value = 100;
				timerReview.Start();
			} 
			else
			{
				this.ReviewTimeout = DateTime.MaxValue;
				lblMessage.Text = "Press spacebar to continue.";
			}

            lblMessage.Visible = true;
            lblMessage.Refresh();

            this.State = ExamState.ReviewingAnswer;
		}

		private void timerReview_Tick(object sender, EventArgs e)
		{

		}

		private void EndReviewingAnswer()
		{
			lblMessage.Visible = false;
			lblMessage.Refresh();
			this.ReviewTimeout = DateTime.MaxValue;
			NextQuestion();
		}

		private void PauseTest()
		{
			timer1.Stop();
			EnableMidiInput(false);
			this.State = (this.State == ExamState.ReviewingAnswer) ? ExamState.ReviewingPaused : ExamState.Paused;
			this.PauseStartTime = DateTime.Now;
		}

		private void Resume()
		{
			int totalSecsPaused = DateTime.Now.Subtract(this.PauseStartTime).Seconds;

			if (this.ReviewTimeout < DateTime.MaxValue)
				this.ReviewTimeout = this.ReviewTimeout.AddSeconds(totalSecsPaused);

			if (this.QuestionTimeout < DateTime.MaxValue)
				this.QuestionTimeout = this.QuestionTimeout.AddSeconds(totalSecsPaused);

			if (this.TestTimeout < DateTime.MaxValue)
				this.TestTimeout = this.TestTimeout.AddSeconds(totalSecsPaused);

			EnableMidiInput(true);
			this.State = (this.State == ExamState.ReviewingPaused) ? ExamState.ReviewingAnswer : ExamState.Running;
			timer1.Start();
		}

		private void EndTest()
		{
			timer1.Stop();
			EnableMidiInput(false);

			this.TestResult.TotalDurationSecs = this.Test.ExamDurationSecs;
			this.TestResult.TotalQuestions = this.QuestionCount;
			this.TestResult.TotalCorrect = this.CorrectAnswerCount;

			this.SaveResults = _voicingResultsForm.Run(this.TestResult, this.Test);

			this.DialogResult = DialogResult.OK;
			Hide();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			// See if it's the end of the test
			if (DateTime.Now > this.TestTimeout)
			{
				EndQuestion(false, true);
				EndTest();
				return;
			}

			if (this.State == ExamState.Running)
			{
				// See if the question timed out
				if (DateTime.Now > this.QuestionTimeout)
					EndQuestion(false);

				UpdateQuestionTime();
			}
			else if (this.State == ExamState.ReviewingAnswer)
			{
				if (_autoContinue)
				{
					if (DateTime.Now > this.ReviewTimeout)
					{
						EndReviewingAnswer();
					}
					else
					{
						var waitSecs = (this.ReviewTimeout.Subtract(DateTime.Now).Seconds + 1).ToString();
						lblMessage.Text = string.Format("Next question in {0} seconds...", waitSecs);
					}
				}
			}

			// Set time displays
			if (this.Test.ExamDurationSecs > 0) {
				int remSecs = Convert.ToInt32(this.TestTimeout.Subtract(DateTime.Now).TotalSeconds);
				if (remSecs < 0)
					remSecs = 0;
				lblExamTimeRemaining.Text = Utils.TimeDisplay(remSecs);
			}
		}

		private void UpdateQuestionTime()
		{
			if (this.Test.QuestionDurationSecs > 0)
			{
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

			pianoControl1.ReleaseAllPianoKeys();
			foreach (var noteId in voicing.NoteIds)
			{
				_midiOutDevice.SendNoteOn(noteId);
				pianoControl1.PressPianoKey(noteId);
			}
			if (this.Test.InclBassNote)
			{
				_midiOutDevice.SendNoteOn(voicing.BassNoteId);
				pianoControl1.PressBassKey(voicing.BassNoteId);
			}

			Thread.Sleep(350);

			foreach (var noteId in voicing.NoteIds)
			{
				_midiOutDevice.SendNoteOff(noteId);
			}
			if (this.Test.InclBassNote)
			{
				_midiOutDevice.SendNoteOff(voicing.BassNoteId);
			}
		}

		private void VoicingExamForm_Resize(object sender, EventArgs e)
		{
			pianoControl1.Refresh();
		}

		private void VoicingExamForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (this.State == ExamState.ReviewingAnswer)
				{
					EndReviewingAnswer();
					e.SuppressKeyPress = true;
				}
			}
			else if (e.KeyCode == Keys.ControlKey)
			{
				if (this.State == ExamState.ReviewingAnswer)
					PlayVoicing(this.CurrVoicing);
			}
			else if (e.KeyCode == Keys.Space)
			{
				if (this.State == ExamState.ReviewingAnswer)
				{
					if (_autoContinue)
						this.PauseTest();
					else
						EndReviewingAnswer();
					e.SuppressKeyPress = true;
				}
				else if (this.State == ExamState.Running)
				{
					if (_autoContinue)
					{
						this.PauseTest();
						e.SuppressKeyPress = true;
					}
				}
				else if (this.State == ExamState.Paused || this.State == ExamState.ReviewingPaused)
				{
					this.Resume();
					e.SuppressKeyPress = true;
				}
			}
		}

		private void btnPlayVoicing_Click(object sender, EventArgs e)
		{
			PlayVoicing(this.CurrVoicing);
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			EndTest();
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			if (this.State == ExamState.Running || this.State == ExamState.ReviewingAnswer) {
				PauseTest();
			} else {
				Resume();
			}
				
		}
    }
}