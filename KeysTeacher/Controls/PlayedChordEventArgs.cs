using System;
using System.Collections.Generic;

namespace KeysTeacher
{
	public class PlayedChordEventArgs : EventArgs
	{
		public PlayedChordEventArgs(List<int> noteIDs)
		{
			if (noteIDs != null)
				this.NoteIDs = noteIDs;
			else
				this.NoteIDs = new List<int>();
		}

		public List<int> NoteIDs { get; private set; }
	}
}