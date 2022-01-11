using System;

namespace KeysTeacher.Tests.VoicingLibs
{
	public class EditVoicingTestCompleteArgs : EventArgs
	{
		#region Constructors

		public EditVoicingTestCompleteArgs(VoicingTest voicingTest)
		{
			this.VoicingTest = voicingTest;
		}

		#endregion

		#region Properties

		public VoicingTest VoicingTest { get; private set; }

		#endregion
	}
}