namespace KeysTeacher
{
	public static class PianoControlExtensions
	{
		public static void AllNotesOff(this Controls.PianoControl pianoControl)
		{
			for (int k = pianoControl.LowNoteID; k < pianoControl.HighNoteID; k++) {
				pianoControl.ReleasePianoKey(k);
			}
		}
	}
}