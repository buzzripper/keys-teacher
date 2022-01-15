using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Data
{
	public interface IVoicingLibRepository
	{
		List<string> GetAllVoicingLibNames();
		VoicingLib GetVoicingLib(string name);
		string GetUniqueLibName();
		void Save(VoicingLib voicingLib);
		void UpdateName(string oldName, string newName);
		void Delete(string name);
		bool NameExists(string name);
		List<VoicingLib> GetSystemLibs();
	}
}
