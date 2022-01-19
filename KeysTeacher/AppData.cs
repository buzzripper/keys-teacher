using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace KeysTeacher
{
	[Serializable]
	public class AppData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		#region Fields

		private int _inDeviceId;
		private int _outDeviceId;
		private bool _midiThru = true;
		private int _correctAnswerWaitSecs = 3;
		private int _wrongAnswerWaitSecs = 5;
		private string _windowPlacementStr;
		private int _noteOnVelocity = 75;
		private string _backupFolder;

		#endregion

		public int InDeviceId
		{
			get { return _inDeviceId; }
			set {
				_inDeviceId = value;
				OnPropertyChanged("InDeviceId");
			}
		}

		public int OutDeviceId
		{
			get { return _outDeviceId; }
			set {
				_outDeviceId = value;
				OnPropertyChanged("OutDeviceId");
			}
		}

		public bool MidiThru
		{
			get { return _midiThru; }
			set {
				_midiThru = value;
				OnPropertyChanged("MidiThru");
			}
		}

		public int CorrectAnswerWaitSecs
		{
			get { return _correctAnswerWaitSecs; }
			set {
				_correctAnswerWaitSecs = value;
				OnPropertyChanged("CorrectAnswerWaitSecs");
			}
		}

		public int WrongAnswerWaitSecs
		{
			get { return _wrongAnswerWaitSecs; }
			set {
				_wrongAnswerWaitSecs = value;
				OnPropertyChanged("WrongAnswerWaitSecs");
			}
		}

		public int NoteOnVelocity
		{
			get { return _noteOnVelocity; }
			set {
				_noteOnVelocity = value;
				OnPropertyChanged("NoteOnVelocity");
			}
		}

		public string BackupFolder {
			get { return _backupFolder; }
			set {
				_backupFolder = value;
				OnPropertyChanged("BackupFolder");
			}
		}

		[XmlElement("CDataElement")]
		public XmlCDataSection WindowPlacement
		{
			get {
				XmlDocument doc = new XmlDocument();
				return doc.CreateCDataSection(_windowPlacementStr);
			}
			set {
				_windowPlacementStr = value.Value;
				OnPropertyChanged("WindowPlacement");
			}
		}

		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public AppData Clone()
		{
			return new AppData {
				InDeviceId = this.InDeviceId,
				OutDeviceId = this.OutDeviceId,
				MidiThru = this.MidiThru,
				CorrectAnswerWaitSecs = this.CorrectAnswerWaitSecs,
				WrongAnswerWaitSecs = this.WrongAnswerWaitSecs,
				NoteOnVelocity = this.NoteOnVelocity,
				WindowPlacement = this.WindowPlacement,
				BackupFolder = this.BackupFolder
			};
		}

		public void CopyFrom(AppData appData)
		{
			this.InDeviceId = appData.InDeviceId;
			this.OutDeviceId = appData.OutDeviceId;
			this.MidiThru = appData.MidiThru;
			this.CorrectAnswerWaitSecs = appData.CorrectAnswerWaitSecs;
			this.WrongAnswerWaitSecs = appData.WrongAnswerWaitSecs;
			this.NoteOnVelocity = appData.NoteOnVelocity;
			this.WindowPlacement = appData.WindowPlacement;
			this.BackupFolder = appData.BackupFolder;
		}
	}
}