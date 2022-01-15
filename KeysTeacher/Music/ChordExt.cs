using System;
using System.Runtime.Serialization;

namespace KeysTeacher
{
	[Serializable]
	public class ChordExt : PropertyNotifyBase
	{
		#region Fields

		[DataMember]
		private int _degree;

		[DataMember]
		private Accidental _accidental;

		#endregion

		#region Constructors

		public ChordExt() : this(0)
		{}

		public ChordExt(int degree = 0, Accidental accidental = Accidental.Natural)
		{
			_degree = degree;
			_accidental = accidental;
		}



		#endregion

		#region Properties

		public int Degree
		{
			get { return _degree; }
			set
			{
				_degree = value;
				if (value == 0)
					_accidental = Accidental.Natural;
				FirePropertyChanged("Degree");
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

		#endregion

		#region Methods

		public override string ToString()
		{
			return string.Format("{0}{1}", AccidentalToText(this.Accidental), this.Degree);
		}

		private static string AccidentalToText(Accidental accidental)
		{
			switch (accidental) {
				case Accidental.Natural:
					return null;
				case Accidental.Flat:
					return "-";
				default:
					return "+";
			}
		}

		public ChordExt Clone()
		{
			return new ChordExt{
				       Degree = this.Degree,
				       Accidental = this.Accidental
			       };
		}

		public void CopyFrom(ChordExt chordExt)
		{
			this.Degree = chordExt.Degree;
			this.Accidental = chordExt.Accidental;
		}

		#endregion
	}
}