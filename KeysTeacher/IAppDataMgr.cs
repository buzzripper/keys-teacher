
namespace KeysTeacher
{
	public interface IAppDataMgr
	{
		string DataFilepath { get; }
		AppData AppData { get; }

		void Load();
		void Save();
	}
}
