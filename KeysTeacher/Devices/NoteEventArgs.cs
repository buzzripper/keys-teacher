using System;

namespace KeysTeacher.Devices
{
	public class NoteEventArgs : EventArgs
	{
		#region Constructors

		public NoteEventArgs(int noteNumber)
		{
			this.NoteNumber = noteNumber;
		}

		#endregion

		#region Properties

		public int NoteNumber { get; private set; }

		#endregion
	}
}