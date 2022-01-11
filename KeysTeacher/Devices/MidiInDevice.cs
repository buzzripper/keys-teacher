using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using log4net;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

namespace KeysTeacher.Devices
{
	public class MidiInDevice : IMidiInDevice
	{
		#region Events

		public event EventHandler<NoteEventArgs> NoteOn;
		public event EventHandler<NoteEventArgs> NoteOff;
		public event EventHandler<DeviceChangedArgs> DeviceChanged;

		#endregion

		#region Fields

		private InputDevice _inputDevice;
		private readonly IMidiOutDevice _midiOutDevice;
		private readonly SynchronizationContext _context;
		private readonly ILog _log;

		#endregion

		#region Constructor

		public MidiInDevice(IMidiOutDevice midiOutDevice)
		{
			_log = LogManager.GetLogger(typeof(MidiOutDevice).Name);
			_midiOutDevice = midiOutDevice;
			_context = SynchronizationContext.Current;
			this.DeviceId = -1;
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing) {
				_inputDevice?.Dispose();
			}
		}

		~MidiInDevice()
		{
			Dispose(false);
		}

		#endregion
		
		#region Properties

		public int DeviceId { get; private set; }
		public bool MidiThru { get; private set; }
		public string DeviceName { get; set; }

		#endregion

		#region Public Methods

		public List<string> GetDeviceNames()
		{
			List<string> deviceNames = new List<string>();
			for (int i = 0; i < InputDevice.DeviceCount; i++) {
				deviceNames.Add(InputDevice.GetDeviceCapabilities(i).name);
			}
			return deviceNames;
		}

		public void SetMidiThru(bool value)
		{
			this.MidiThru = value;
		}

		public bool SetDeviceFromId(int deviceId)
		{
			try {
				if (_inputDevice != null) {
					_inputDevice.StopRecording();
					_inputDevice.Dispose();
					_inputDevice = null;
				}

				_inputDevice = new InputDevice(deviceId);
				_inputDevice.ChannelMessageReceived += OnDeviceChannelMessageReceived;
				_inputDevice.Error += OnDeviceError;
				_inputDevice.StartRecording();

				this.DeviceId = deviceId;
				this.DeviceName = this.GetDeviceNames()[deviceId];
				this.InvokeDeviceChanged(this.DeviceId, this.DeviceName);

				return true;
			} catch (Exception ex) {
				_log.Error(string.Format("[SetDeviceFromId] {0}: {1}", ex.GetType().Name, ex.Message), ex);
				return false;
			}
		}

		public void Close()
		{
			if (_inputDevice != null) {
				_inputDevice.StopRecording();
				_inputDevice.Dispose();
				_inputDevice = null;
			}
		}
		
		#endregion

		#region Private Methods

		private void InvokeNoteOn(int noteNumber)
		{
			NoteOn?.Invoke(this, new NoteEventArgs(noteNumber));
		}

		private void InvokeNoteOff(int noteNumber)
		{
			NoteOff?.Invoke(this, new NoteEventArgs(noteNumber));
		}

		private void InvokeDeviceChanged(int deviceId, string deviceName)
		{
			DeviceChanged?.Invoke(this, new DeviceChangedArgs(deviceId, deviceName));
		}

		private void OnDeviceChannelMessageReceived(object sender, ChannelMessageEventArgs e)
		{
			_context.Post(delegate {
				if (e.Message.Command == ChannelCommand.NoteOn) {
					InvokeNoteOn(e.Message.Data1);
					if (this.MidiThru) {
						_midiOutDevice?.SendNoteOn(e.Message.Data1);
					}
				} else if (e.Message.Command == ChannelCommand.NoteOff) {
					InvokeNoteOff(e.Message.Data1);
					if (this.MidiThru) {
						_midiOutDevice?.SendNoteOff(e.Message.Data1);
					}
				}
			}, null);
		}

		private void OnDeviceError(object sender, ErrorEventArgs e)
		{
			MessageBox.Show(e.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		
		#endregion
	}
}