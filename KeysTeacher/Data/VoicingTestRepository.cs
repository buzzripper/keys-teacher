using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KeysTeacher.Misc;
using KeysTeacher.Tests.VoicingLibs;
using log4net;

namespace KeysTeacher.Data
{
	public class VoicingTestRepository : IVoicingTestRepository
	{
		#region Events

		public event EventHandler Changed;

		#endregion

		#region Constants

		private const string FileExt = "vt";
		public const string VoicingTestFolder = "VoicingTests";

		#endregion

		#region Fields

		private readonly string _dataFolderPath;
		private readonly ILog _log;

		#endregion

		#region Ctor

		public VoicingTestRepository(ILog log)
		{
			_log = log;

			_dataFolderPath = Path.Combine(Globals.DataRootFolder, VoicingTestFolder);
			if (!Directory.Exists(_dataFolderPath))
				Directory.CreateDirectory(_dataFolderPath);
		}

		#endregion

		public string DataFolderPath => _dataFolderPath;

		private void InvokeChanged()
		{
			Changed?.Invoke(this, new EventArgs());
		}

		#region Public Methods

		public List<VoicingTest> GetAllVoicingTests()
		{
			return LoadAllVoicingTests();
		}

		public VoicingTest GetVoicingTest(int id)
		{
			return GetAllVoicingTests().FirstOrDefault(vt => vt.Id == id);
		}

		public VoicingTest GetVoicingTestByName(string testName)
		{
			return GetAllVoicingTests().FirstOrDefault(vt => string.Compare(vt.Name, testName, StringComparison.OrdinalIgnoreCase) == 0);
		}

		public int GetNewTestId()
		{
			List<VoicingTest> allVoicingTests = GetAllVoicingTests();

			int newId = 0;
			do {
				newId++;
			}
			while (allVoicingTests.Any(vt => vt.Id == newId));

			return newId;
		}

		public string GetUniqueTestName()
		{
			string newTestName;

			int counter = 0;
			do {
				counter++;
				newTestName = $"Voicing Test {counter}";
			}
			while (GetAllVoicingTests().Any(t => string.Compare(t.Name, newTestName, StringComparison.OrdinalIgnoreCase) == 0));

			return newTestName;
		}

		public void Save(VoicingTest voicingTest)
		{
			string filepath = Path.Combine(_dataFolderPath, $"{voicingTest.Name}.{FileExt}");
			string serializedTest = XmlTools.Serialize(voicingTest);

			if (File.Exists(filepath))
				File.Delete(filepath);

			File.WriteAllText(filepath, serializedTest);
			InvokeChanged();
		}

		public void UpdateName(string oldName, string newName)
		{
			List<VoicingTest> allVoicingTests = GetAllVoicingTests();
			VoicingTest voicingTest = allVoicingTests.FirstOrDefault(vt => vt.Name == oldName);
			if (voicingTest == null)
				return;
			voicingTest.Name = newName;
			Delete(voicingTest.Id);
			Save(voicingTest);
			InvokeChanged();
		}

		public void Delete(int id)
		{
			VoicingTest voicingTest = GetAllVoicingTests().FirstOrDefault(vt => vt.Id == id);
			if (voicingTest == null)
				return;

			string filepath = Path.Combine(_dataFolderPath, $"{voicingTest.Name}.{FileExt}");
			if (File.Exists(filepath))
				File.Delete(filepath);
			InvokeChanged();
		}

		#endregion

		#region Private Methods

		private List<VoicingTest> LoadAllVoicingTests()
		{
			List<VoicingTest> allVoicingTests = new List<VoicingTest>();

			DirectoryInfo dirInfo = new DirectoryInfo(_dataFolderPath);
			foreach (FileInfo fileInfo in dirInfo.GetFiles($"*.{FileExt}", SearchOption.TopDirectoryOnly)) {
				try {
					VoicingTest voicingTest = LoadVoicingTest(fileInfo);
					allVoicingTests.Add(voicingTest);
				} catch (Exception ex) {
					_log.Error($"[GetAllVoicingTests] {ex.GetType().Name} attempting to load {fileInfo.Name}: {ex.Message}", ex);
				}
			}
			return allVoicingTests;
		}

		private VoicingTest LoadVoicingTest(FileInfo fileInfo)
		{
			string fileContents = File.ReadAllText(fileInfo.FullName);

			VoicingTest voicingTest = XmlTools.Deserialize<VoicingTest>(fileContents);

			voicingTest.Name = Path.GetFileNameWithoutExtension(fileInfo.Name);

			return voicingTest;
		}

		#endregion
	}
}