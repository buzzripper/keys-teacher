using System;

namespace KeysTeacher.Tests.VoicingLibs
{
	public interface IVoicingExamForm : IDisposable
	{
		bool SaveResults { get; set; }
		TestResult TestResult { get; set; }

		bool Run(VoicingTest test);
	}
}
