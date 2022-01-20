using System;
using System.IO;
using System.Windows.Forms;
using KeysTeacher.Misc;

namespace KeysTeacher
{
	public class AppDataMgr : IAppDataMgr
	{
		#region Constants

		public const string DataFilename = "KeysTeacher.dat";

		#endregion

		#region Fields

		private readonly string _dataFilepath;
		private readonly IMsgBox _msgBox;

		#endregion

		#region Initialization / Finalization

		public AppDataMgr(IMsgBox msgBox)
		{
			_msgBox = msgBox;
			_dataFilepath = Path.Combine(Globals.DataRootFolder, DataFilename);
		}

		#endregion

		#region Properties

		public string DataFilepath => _dataFilepath;
		public AppData AppData { get; private set; }

		#endregion

		public void Load()
		{
			if (File.Exists(_dataFilepath)) {
				try {
					this.AppData = Utils.XmlDeserializeFromFile<AppData>(_dataFilepath);
					return;
				} catch (Exception ex) {
					_msgBox.ShowError($"{ex.GetType().Name} loading AppData.{Environment.NewLine}{ex.Message}");
				}
			}

			// Defaults
			this.AppData = new AppData();
			this.AppData.CorrectAnswerWaitSecs = 3;
			this.AppData.WrongAnswerWaitSecs = 5;
		}

		public void Save()
		{
			try {
				Utils.XmlSerializeToFile(this.AppData, _dataFilepath);
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}