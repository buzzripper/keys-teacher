using System;
using KeysTeacher.HomeControls;

namespace KeysTeacher.Tests.VoicingLibs
{
	public interface IVoicingTestEditor : IHomeControlBase
	{
		event EventHandler<EditVoicingTestCompleteArgs> EditVoicingTestComplete;

		void Run(VoicingTest voicingTest);
	}
}
