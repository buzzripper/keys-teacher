using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KeysTeacher.Music
{
	[Serializable]
	public class Voicing : PropertyNotifyBase
	{
		#region Fields

		private VoicingForm _form;
		private PdChord _chord;
		private readonly List<int> _noteIds;
		private int _bassNoteId;

		#endregion

		#region Constructors

		public Voicing()
		{
			_noteIds = new List<int>();
			_bassNoteId = 0;
			_chord = new PdChord();
			_chord.PropertyChanged += ChordPropertyChanged;
			_form = VoicingForm.None;
		}

		public void Initialize()
		{
			if (_chord != null) {
				_chord.Initialize();
				_chord.PropertyChanged += ChordPropertyChanged;
			}
		}

		#endregion

		#region Properties

		public List<int> NoteIds => _noteIds;

		public int BassNoteId
		{
			get { return _bassNoteId; }
			set {
				_bassNoteId = value;
				FirePropertyChanged("BassNoteId");
			}
		}

		public VoicingForm Form
		{
			get { return _form; }
			set
			{
				_form = value;
				FirePropertyChanged("Form");
			}
		}

		public PdChord Chord
		{
			get { return _chord; }
			set
			{
				_chord = value;
				if (_chord != null)
					_chord.PropertyChanged += ChordPropertyChanged;
				FirePropertyChanged("Chord");
			}
		}

		public string DisplayName
		{
			get { return ToString(); }
		}

		#endregion

		public void AddNoteId(int noteId)
		{
			if (!_noteIds.Contains(noteId)) {
				_noteIds.Add(noteId);
				FirePropertyChanged("NoteIds");
			}
		}

		public void RemoveNoteId(int noteId)
		{
			if (_noteIds.Contains(noteId)) {
				_noteIds.Remove(noteId);
				FirePropertyChanged("NoteIds");
			}
		}

		public override string ToString()
		{
			var formStr = this.Form != VoicingForm.None ? $"({this.Form})" : null;
			return string.Format($"{this.Chord} {formStr}");
		}

		private void ChordPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			FirePropertyChanged(e.PropertyName);
		}

		public Voicing Clone()
		{
			Voicing clone = new Voicing{
				                Form = this.Form,
				                Chord = this.Chord.Clone(),
								BassNoteId = this.BassNoteId
			                };
			this.NoteIds.ForEach(ni => clone.NoteIds.Add(ni));
			clone.Initialize();
			return clone;
		}

		public void CopyFrom(Voicing voicing)
		{
			this.Form = voicing.Form;
			this.NoteIds.Clear();
			voicing.NoteIds.ForEach(ni => this.NoteIds.Add(ni));
			this.BassNoteId = voicing.BassNoteId;
			this.Chord.CopyFrom(voicing.Chord);
		}
	}
}