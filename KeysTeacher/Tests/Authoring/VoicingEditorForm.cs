using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using KeysTeacher.Devices;
using KeysTeacher.Misc;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.Authoring
{
	public partial class VoicingEditorForm : Form, IVoicingEditorForm
	{
		#region Static

		private static Point _lastPosition;
		
		#endregion

		#region Fields

		private readonly IMidiOutDevice _midiOutDevice;
		private readonly IMsgBox _msgBox;
		
		#endregion

		#region Initialization / Finalization

		public VoicingEditorForm(IMidiOutDevice midiOutDevice, IMsgBox msgBox)
		{
			_midiOutDevice = midiOutDevice;
			_msgBox = msgBox;
			InitializeComponent();
		}

		private void VoicingEditorForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveWindowPosition();
		}

		private void SaveWindowPosition()
        {
			_lastPosition.X = this.Left;
			_lastPosition.Y = this.Top;
		}

		#endregion

		#region Properties

		public Voicing Voicing => voicingEditor1.Voicing;
		
		#endregion

		#region Public Methods

		public bool Run(Voicing voicing)
		{
			voicingEditor1.Voicing = voicing;

			if (IsFirstShowing()) {
				this.CenterToScreen();
			} else {
				this.Left = _lastPosition.X;
				this.Top = _lastPosition.Y;
			}
			return ShowDialog() == DialogResult.OK;
		}

		private bool IsFirstShowing()
		{
			return _lastPosition.X == 0 && _lastPosition.Y == 0;
		}

		#endregion

		#region UI Events

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (!ValidEntries())
				return;

			this.SaveWindowPosition();
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.SaveWindowPosition();
			this.Hide();
		}

		#endregion

		private bool ValidEntries()
		{
			if (voicingEditor1.Voicing.NoteIds.Count == 0) {
				_msgBox.ShowError("No notes selected.");
				voicingEditor1.Focus();
				return false;
			}
				
			return true;
		}

		private void voicingEditor1_PlayedChord(object sender, PlayedChordEventArgs e)
		{
			e.NoteIDs.ForEach(noteId => _midiOutDevice.SendNoteOn(noteId));
			Thread.Sleep(350);
			e.NoteIDs.ForEach(noteId => _midiOutDevice.SendNoteOff(noteId));
		}
	}
}