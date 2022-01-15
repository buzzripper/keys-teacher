using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace KeysTeacher
{
    [Serializable]
    public class PdChord : PropertyNotifyBase
    {
        #region Fields

        [DataMember]
        private PdNote _note = new PdNote();

        [DataMember]
        private Quality _quality;

        [DataMember]
        private PdNote _bassNote;

        [DataMember]
        private ChordExt[] _chordExts;

        #endregion

        #region Constructors

        public PdChord()
            : this(null, Quality.Major)
        { }

        public PdChord(PdNote note = null, Quality quality = Quality.Major)
        {
            this.Note = note ?? new PdNote();
            this.Quality = quality;

            ChordExt[] chordExts = new ChordExt[3];
            chordExts[0] = new ChordExt();
            chordExts[1] = new ChordExt();
            chordExts[2] = new ChordExt();
            this.ChordExts = chordExts;
        }

        public void Initialize()
        {
            _note.PropertyChanged += NotePropertyChanged;
            if (_chordExts != null) {
                _chordExts[0].PropertyChanged += ExtPropertyChanged0;
                _chordExts[1].PropertyChanged += ExtPropertyChanged1;
                _chordExts[2].PropertyChanged += ExtPropertyChanged2;
            }
        }

        #endregion

        #region Properties

        public PdNote Note {
            get { return _note; }
            set {
                _note = value;
                if (_note != null)
                    _note.PropertyChanged += NotePropertyChanged;
                FirePropertyChanged("Note");
            }
        }

        public Quality Quality {
            get { return _quality; }
            set {
                _quality = value;
                FirePropertyChanged("Quality");
            }
        }

        public ChordExt[] ChordExts {
            get { return _chordExts; }
            set {
                _chordExts = value;
                if (_chordExts != null) {
                    _chordExts[0].PropertyChanged += ExtPropertyChanged0;
                    _chordExts[1].PropertyChanged += ExtPropertyChanged1;
                    _chordExts[2].PropertyChanged += ExtPropertyChanged2;
                }
                FirePropertyChanged("ChordExts");
            }
        }

        public PdNote BassNote {
            get { return _bassNote; }
            set {
                _bassNote = value;
                if (_bassNote != null)
                    _bassNote.PropertyChanged += BassNotePropertyChanged;
                FirePropertyChanged("BassNote");
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}{1}", this.Note, QualityToStr()));

            int count = 0;
            foreach (ChordExt chordExt in this.ChordExts) {
                if (chordExt.Degree > 0) {
                    sb.Append(string.Format("{0}{1}{2}", count == 0 ? "[" : ",", ExtToStr(chordExt.Accidental), chordExt.Degree));
                    count++;
                }
            }
            if (count > 0)
                sb.Append("]");

            if (this.BassNote != null)
                sb.Append(string.Format("/{0}", this.BassNote));

            return sb.ToString();
        }

        private string QualityToStr()
        {
            switch (this.Quality) {
                case Quality.Major:
                    return string.Empty;
                case Quality.Minor:
                    return "m";
                case Quality.Augmented:
                    return "^";
                case Quality.Dominant7th:
                    return "7";
                case Quality.Minor7th:
                    return "m7";
                case Quality.Major7th:
                    return "M7";
                default: //Quality.Diminished
                    return "o";
            }
        }

        private static string ExtToStr(Accidental accidental)
        {
            switch (accidental) {
                case Accidental.Flat:
                    return "-";
                case Accidental.Sharp:
                    return "+";
                default:
                    return string.Empty;
            }
        }

        private void NotePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e.PropertyName);
        }

        private void BassNotePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e.PropertyName);
        }

        private void ExtPropertyChanged0(object sender, PropertyChangedEventArgs e)
        {
            ExtPropertyChanged(0);
        }

        private void ExtPropertyChanged1(object sender, PropertyChangedEventArgs e)
        {
            ExtPropertyChanged(1);
        }

        private void ExtPropertyChanged2(object sender, PropertyChangedEventArgs e)
        {
            ExtPropertyChanged(2);
        }

        private void ExtPropertyChanged(int index)
        {
            FirePropertyChanged(string.Format("ChordExt_{0}", index));
        }

        public PdChord Clone()
        {
            PdChord clone = new PdChord {
                Note = this.Note.Clone(),
                Quality = this.Quality
            };

            if (this.BassNote != null)
                clone.BassNote = this.BassNote.Clone();

            for (int i = 0; i < 3; i++)
                clone.ChordExts[i] = this.ChordExts[i].Clone();

            return clone;
        }

        public void CopyFrom(PdChord chord)
        {
            this.Note.CopyFrom(chord.Note);
            this.Quality = chord.Quality;

            if (chord.BassNote != null) {
                if (this.BassNote == null)
                    this.BassNote = new PdNote();
                this.BassNote.CopyFrom(chord.BassNote);
            } else {
                this.BassNote = null;
            }

            for (int i = 0; i < 3; i++)
                this.ChordExts[i].CopyFrom(chord.ChordExts[i]);
        }

        #endregion
    }
}