using System;
using System.ComponentModel;
using KeysTeacher.Music;

namespace KeysTeacher
{
	[Serializable]
	public class VoicingProgression : PropertyNotifyBase
	{
		#region Fields

		private Key _key;
		private VoicingForm _voicingForm;
		private Voicing[] _voicings = new Voicing[3];

		#endregion

		#region Constructors

		public VoicingProgression()
		{
			// Defaults
			_key = Key.C;
			_voicingForm = VoicingForm.A;
			_voicings = new Voicing[3];
		}

		#endregion

		#region Properties

		public Key Key
		{
			get { return _key; }
			set
			{
				_key = value;
				FirePropertyChanged("Key");
			}
		}

		public VoicingForm VoicingForm
		{
			get { return _voicingForm; }
			set
			{
				_voicingForm = value;
				FirePropertyChanged("VoicingForm");
			}
		}

		public Voicing[] Voicings
		{
			get { return _voicings; }
			set
			{
				_voicings = value;
				if (_voicings != null) {
					foreach (Voicing voicing in _voicings)
						voicing.PropertyChanged += VoicingPropertyChanged;
				}

				FirePropertyChanged("Chord");
			}
		}

		void VoicingPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			FirePropertyChanged(string.Format("Voicing_{0}", e.PropertyName));
		}

		public string DisplayName
		{
			get { return ToString(); }
		}

		#endregion

		public override string ToString()
		{
			return string.Format("{0} [{1}]", this.Key, this.VoicingForm);
		}
	}
}