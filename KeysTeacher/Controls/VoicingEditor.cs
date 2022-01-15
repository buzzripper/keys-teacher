using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using KeysTeacher.Music;

namespace KeysTeacher
{
	public partial class VoicingEditor : UserControl
	{
		#region Events

		public event EventHandler Changed;
		public event EventHandler<PlayedChordEventArgs> PlayedChord;

		#endregion

		#region Fields

		private Voicing _voicing;
		private bool _populating;

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingEditor()
		{
			InitializeComponent();

			_populating = true;
			try {
				cmbVoicingForm.DataSource = new List<VoicingForm>((VoicingForm[]) Enum.GetValues(typeof(VoicingForm)));
				chordEditor1.Changed += chordEditor1_Changed;
			} finally {
				_populating = false;
			}
		}

		#endregion

		#region Properties

		public Voicing Voicing
		{
			get { return _voicing; }
			set
			{
				_voicing = value;
				if (_voicing != null)
					_voicing.PropertyChanged += Voicing_PropertyChanged;
				Populate(value);
			}
		}

		private void Populate(Voicing voicing)
		{
			_populating = true;
			try {
				if (voicing != null) {
					chordEditor1.Chord = voicing.Chord;
					lblForm.Text = voicing.Form != VoicingForm.None ? voicing.Form.ToString() : String.Empty;
					lblForm.Tag = voicing.Form;
					pianoControl1.ReleaseAllPianoKeys();
					voicing.NoteIds.ForEach(noteId => pianoControl1.PressPianoKey(noteId));
					if (voicing.BassNoteId > 0)
						pianoControl1.PressBassKey(voicing.BassNoteId);
				} else {
					chordEditor1.Chord = new PdChord();
					lblForm.Text = VoicingForm.A.ToString();
					lblForm.Tag = VoicingForm.A;
					pianoControl1.ReleaseAllPianoKeys();
				}
			} finally {
				_populating = false;
			}
		}

		#endregion

		#region UI Events

		private void cmbVoicingForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_populating)
				_voicing.Form = (VoicingForm) cmbVoicingForm.SelectedItem;
		}

		#endregion

		private void VoicingEditor_EnabledChanged(object sender, EventArgs e)
		{
			_populating = true;
			chordEditor1.Enabled = this.Enabled;
			pianoControl1.Enabled = this.Enabled;
			if (!this.Enabled) {
				lblForm.Text = string.Empty;
				cmbVoicingForm.Text = string.Empty;
				pianoControl1.ReleaseAllPianoKeys();
			}
			_populating = false;
		}

		private void InvokeChangedEvent()
		{
			Changed?.Invoke(this, new EventArgs());
		}

		void chordEditor1_Changed(object sender, EventArgs e)
		{
			InvokeChangedEvent();
		}

		void Voicing_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Form") {
				lblForm.Text = _voicing.Form.ToString();
				lblForm.Tag = _voicing.Form;
				InvokeChangedEvent();
			}
		}

		private void pianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
		{
			//if (!_populating) {
			//	_voicing.RemoveNoteId(e.NoteID);
			//	InvokeChangedEvent();
			//}
		}

		private void pianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
		{
			if (!_populating) {
				_voicing.AddNoteId(e.NoteID);
				InvokeChangedEvent();
			}
		}

		private void pianoControl1_BassKeyDown(object sender, PianoKeyEventArgs e)
		{
			if (!_populating) {
				_voicing.BassNoteId = e.NoteID;
				InvokeChangedEvent();
			}
		}

		private void pianoControl1_BassKeyUp(object sender, PianoKeyEventArgs e)
		{
			if (!_populating) {
				_voicing.BassNoteId = 0;
				InvokeChangedEvent();
			}
		}

		private void VoicingEditor_Resize(object sender, EventArgs e)
		{
			pianoControl1.Refresh();
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (pianoControl1.PressedKeyIDs.Count > 0)
				InvokePlayedChordEvent(pianoControl1.PressedKeyIDs, pianoControl1.PressedBassKeyID);
		}

		private void InvokePlayedChordEvent(List<int> pressedKeyIDs, int bassNoteID)
		{
			var noteIds = new List<int>(pressedKeyIDs);
			if (bassNoteID > 0)
				noteIds.Add(bassNoteID);
			PlayedChord?.Invoke(this, new PlayedChordEventArgs(noteIds));
		}

		//public void NoteDown(NoteOnMessage msg)
		//{
		//	pianoControl1.TogglePianoKey((int)msg.Pitch);
		//}

		//public void NoteUp(NoteOffMessage msg)
		//{
		//	//pianoControl1.ReleasePianoKey((int)msg.Pitch);
		//}

		private void btnClear_Click(object sender, EventArgs e)
		{
			pianoControl1.ReleaseAllPianoKeys();
		}
	}
}