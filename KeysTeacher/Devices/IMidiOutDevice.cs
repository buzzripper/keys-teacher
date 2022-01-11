using System;
using System.Collections.Generic;

namespace KeysTeacher.Devices
{
	public interface IMidiOutDevice : IDisposable
	{
		event EventHandler<DeviceChangedArgs> DeviceChanged;

		int DeviceId { get; }
		string DeviceName { get; set; }

		List<string> GetDeviceNames();
		bool SetDeviceFromId(int deviceId);
		void SendNoteOn(int noteNumber);
		void SendNoteOff(int noteNumber);
	}
}
