using System;
using System.Windows.Forms;
using KeysTeacher.Devices;

namespace KeysTeacher
{
	public partial class MidiDeviceForm : Form, IMidiDeviceForm
	{
		#region Fields

		private readonly IMidiInDevice _midiInDevice;
		private readonly IMidiOutDevice _midiOutDevice;

		#endregion

		#region Constructors / Initialization / Finalization

		public MidiDeviceForm(IMidiInDevice midiInDevice, IMidiOutDevice midiOutDevice)
		{
			InitializeComponent();

			_midiInDevice = midiInDevice;
			_midiOutDevice = midiOutDevice;
		}

		#endregion

		#region Properties

		#endregion

		public DialogResult Run()
		{
			lbxInput.Items.Clear();
			lbxOutput.Items.Clear();

			foreach (var name in _midiInDevice.GetDeviceNames())
				lbxInput.Items.Add(name);
			if (_midiInDevice.DeviceId >= 0 && _midiInDevice.DeviceId < lbxInput.Items.Count)
				lbxInput.SelectedIndex = _midiInDevice.DeviceId;
			else
				lbxInput.SelectedIndex = -1;

			foreach (var name in _midiOutDevice.GetDeviceNames())
				lbxOutput.Items.Add(name);
			if (_midiOutDevice.DeviceId >= 0 && _midiOutDevice.DeviceId < lbxOutput.Items.Count)
				lbxOutput.SelectedIndex = _midiOutDevice.DeviceId;
			else
				lbxOutput.SelectedIndex = -1;

			return this.ShowDialog();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (lbxInput.SelectedIndex == -1) {
				MessageBox.Show("Must select a midi input device.");
				return;
			}
			if (lbxOutput.SelectedIndex == -1) {
				MessageBox.Show("Must select a midi output device.");
				return;
			}

			_midiInDevice.SetDeviceFromId(lbxInput.SelectedIndex);
			_midiInDevice.DeviceName = lbxInput.Text;

			_midiOutDevice.SetDeviceFromId(lbxOutput.SelectedIndex);
			_midiOutDevice.DeviceName = lbxOutput.Text;

			this.DialogResult = DialogResult.OK;
			Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Hide();
		}
	}
}