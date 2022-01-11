using System;

namespace KeysTeacher.Devices
{
	public class DeviceChangedArgs : EventArgs
	{
		#region Constructors

		public DeviceChangedArgs(int deviceId, string deviceName)
		{
			this.DeviceId = deviceId;
			this.DeviceName = deviceName;
		}

		#endregion

		#region Properties

		public int DeviceId { get; private set; }
		public string DeviceName { get; private set; }

		#endregion
	}
}