using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using KeysTeacher.Music;

namespace KeysTeacher
{
	[Serializable]
	public class KeyForm
	{
		#region Fields

		[DataMember]
		private VoicingForm _form;

		[DataMember]
		private List<Voicing> _voicings;

		[DataMember]
		private bool _isOutOfRange;

		#endregion

		public KeyForm(VoicingForm form)
		{
			_form = form;
		}

		#region Properties

		public VoicingForm Form
		{
			get { return _form; }
			set { _form = value; }
		}

		public List<Voicing> Voicings
		{
			get { return _voicings; }
			set { _voicings = value; }
		}

		public bool IsOutOfRange
		{
			get { return _isOutOfRange; }
			set { _isOutOfRange = value; }
		}

		#endregion
	}
}