using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KeysTeacher
{
	[Serializable]
	public class PdNote : PropertyNotifyBase
	{
		#region Static

		public static List<PdNote> Notes;

		static PdNote()
		{
			Notes = new List<PdNote>{
				        new PdNote("C"),
				        new PdNote("C", Accidental.Sharp),
				        new PdNote("D", Accidental.Flat),
				        new PdNote("D"),
				        new PdNote("D", Accidental.Sharp),
				        new PdNote("E", Accidental.Flat),
				        new PdNote("E"),
				        new PdNote("F"),
				        new PdNote("F", Accidental.Sharp),
				        new PdNote("G", Accidental.Flat),
				        new PdNote("G"),
				        new PdNote("G", Accidental.Sharp),
				        new PdNote("A", Accidental.Flat),
				        new PdNote("A"),
				        new PdNote("A", Accidental.Sharp),
				        new PdNote("B", Accidental.Flat),
				        new PdNote("B")
			        };
		}

		#endregion

		#region Fields

		[DataMember]
		private string _letter;

		[DataMember]
		private Accidental _accidental;

		#endregion

		#region Constructors

		public PdNote() : this(null, Accidental.Natural)
		{}

		public PdNote(string letter = null, Accidental accidental = Accidental.Natural)
		{
			_letter = letter ?? "C";
			_accidental = accidental;
		}

		#endregion

		#region Properties

		public string Letter
		{
			get { return _letter; }
			set
			{
				_letter = value;
				FirePropertyChanged("Letter");
			}
		}

		public Accidental Accidental
		{
			get { return _accidental; }
			set
			{
				_accidental = value;
				FirePropertyChanged("Accidental");
			}
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", this.Letter, AccidentalToStr());
		}

		#endregion

		#region Methods

		private string AccidentalToStr()
		{
			switch (this.Accidental) {
				case Accidental.Flat:
					return "b";
				case Accidental.Sharp:
					return "#";
				default: //KeysTeacher.Accidental.Natural
					return string.Empty;
			}
		}

		public PdNote Clone()
		{
			return new PdNote{
				       Letter = this.Letter,
				       Accidental = this.Accidental
			       };
		}

		public void CopyFrom(PdNote note)
		{
			this.Letter = note.Letter;
			this.Accidental = note.Accidental;
		}

		#endregion
	}
}