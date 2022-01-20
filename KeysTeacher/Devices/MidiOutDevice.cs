using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

namespace KeysTeacher.Devices
{
    public class MidiOutDevice : IMidiOutDevice
    {
        #region Events

        public event EventHandler<DeviceChangedArgs> DeviceChanged;

        #endregion

        #region Fields

        private OutputDevice _outputDevice;
        private readonly ILog _log;
        private readonly IAppDataMgr _appDataMgr;

        #endregion

        #region Constructor

        public MidiOutDevice(ILog log, IAppDataMgr appDataMgr)
        {
            _log = log;
            _appDataMgr = appDataMgr;
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
                _outputDevice?.Dispose();
            }
        }

        ~MidiOutDevice()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        public int DeviceId { get; private set; }
        public string DeviceName { get; set; }

        #endregion

        #region Public Methods

        public List<string> GetDeviceNames()
        {
            List<string> deviceNames = new List<string>();
            for (int i = 0; i < OutputDevice.DeviceCount; i++) {
                deviceNames.Add(OutputDevice.GetDeviceCapabilities(i).name);
            }
            return deviceNames;
        }

        public bool SetDeviceFromId(int deviceId)
        {
            try {
                _outputDevice?.Dispose();
                _outputDevice = null;

                _outputDevice = new OutputDevice(deviceId);
                _outputDevice.Error += OnDeviceError;

                this.DeviceId = deviceId;
                this.DeviceName = this.GetDeviceNames()[deviceId];
                this.InvokeDeviceChanged(this.DeviceId, this.DeviceName);

                return true;

            } catch (Exception ex) {
                _log.Error(string.Format("[SetDeviceFromId] {0}: {1}", ex.GetType().Name, ex.Message), ex);
                return false;
            }
        }

        public void SendNoteOn(int noteNumber)
        {
            var msg = new ChannelMessage(ChannelCommand.NoteOn, 0, noteNumber, _appDataMgr.AppData.NoteOnVelocity);
            _outputDevice?.Send(msg);
        }

        public void SendNoteOff(int noteNumber)
        {
            var msg = new ChannelMessage(ChannelCommand.NoteOff, 0, noteNumber, _appDataMgr.AppData.NoteOnVelocity);
            _outputDevice?.Send(msg);
        }

        #endregion

        #region Private Methods

        private void InvokeDeviceChanged(int deviceId, string deviceName)
        {
            DeviceChanged?.Invoke(this, new DeviceChangedArgs(deviceId, deviceName));
        }

        private void OnDeviceError(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        #endregion
    }
}