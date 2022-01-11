using System;
using System.Collections.Generic;

namespace KeysTeacher.Devices
{
	public interface IMidiInDevice : IDisposable
	{
		event EventHandler<NoteEventArgs> NoteOn;
		event EventHandler<NoteEventArgs> NoteOff;
		event EventHandler<DeviceChangedArgs> DeviceChanged;

		int DeviceId { get; }
		bool MidiThru { get; }
		string DeviceName { get; set; }

		List<string> GetDeviceNames();
		bool SetDeviceFromId(int deviceId);
		void Close();
	}
}