using System;
using System.Collections.Generic;
using KeysTeacher.Tests.VoicingLibs;

namespace KeysTeacher.Data
{
	public interface IVoicingTestRepository
	{
		event EventHandler Changed;

		List<VoicingTest> GetAllVoicingTests();
		VoicingTest GetVoicingTest(int id);
		int GetNewTestId();
		string GetUniqueTestName();
		void Save(VoicingTest voicingTest);
		void Delete(int id);
		void UpdateName(string oldName, string newName);
		VoicingTest GetVoicingTestByName(string testName);
	}
}