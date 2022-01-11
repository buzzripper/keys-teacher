using System;

namespace KeysTeacher.Tests.VoicingLibs
{
	public class ShowVoicingTestEditorArgs : EventArgs
	{
		#region Constructors

		public ShowVoicingTestEditorArgs(VoicingTest voicingTest)
		{
			this.VoicingTest = voicingTest;
		}

		#endregion

		#region Properties

		public VoicingTest VoicingTest { get; private set; }

		#endregion
	}
}