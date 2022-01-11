using System;
using System.Collections.Generic;
using System.ComponentModel;
using KeysTeacher.HomeControls;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.VoicingLibs
{
	public interface IVoicingTestsMgr : IHomeControlBase
	{
		event EventHandler<ShowVoicingTestEditorArgs> ShowVoicingTestEditor;

		BindingList<VoicingTest> Tests { get; set; }
		List<TestResult> TestResults { get; }
		void EditTestComplete(VoicingTest voicingTest);
	}
}
