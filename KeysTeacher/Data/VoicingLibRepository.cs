﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using KeysTeacher.Misc;
using KeysTeacher.Music;
using KeysTeacher.Tests.VoicingLibs;
using KeysTeacher.Tests.VoicingTests;
using log4net;

namespace KeysTeacher.Data
{
	public class VoicingLibRepository : IVoicingLibRepository
	{
		#region Constants

		private const string VoicingLibsFolder = "VoicingLibs";
		private const string FileExt = "vlb";

		#endregion

		#region Fields

		private readonly string _dataFolderPath;
		private List<VoicingLib> _systemLibs;
		private readonly ILifetimeScope _lifetimeScope;
		private readonly ILog _log;

		#endregion

		#region Ctor

		public VoicingLibRepository(ILog log, ILifetimeScope lifetimeScope)
		{
			_log = log;
			_lifetimeScope = lifetimeScope;

			_dataFolderPath = Path.Combine(Globals.DataRootFolder, VoicingLibsFolder);
			if (!Directory.Exists(_dataFolderPath))
				Directory.CreateDirectory(_dataFolderPath);

			_systemLibs = BuildSystemLibs();
		}

		#endregion

		#region Public Methods

		public List<VoicingLib> GetAllVoicingLibs()
		{
			return LoadAllVoicingLibs();
		}

		public List<string> GetAllVoicingLibNames()
		{
			//var allVoicings = new VoicingsBuilder().BuildVoicings();
			//var vl = new VoicingLib();
			//vl.Name = "Default";
			//vl.Voicings.AddRange(allVoicings);
			//this.Save(vl);

			return ReadAllVoicingLibNames();
		}

		public VoicingLib GetVoicingLib(string name)
		{
			return LoadVoicingLib(name);
		}

		public string GetUniqueLibName()
		{
			string newLibName;

			int counter = 0;
			do {
				counter++;
				newLibName = $"Voicing Test {counter}";
			}
			while (this.GetAllVoicingLibs().Any(t => string.Compare(t.Name, newLibName, StringComparison.OrdinalIgnoreCase) == 0));

			return newLibName;
		}

		public bool NameExists(string name)
		{
			return this.GetAllVoicingLibNames().Any(n => String.Compare(name, n, StringComparison.OrdinalIgnoreCase) == 0);
		}

		public void UpdateName(string oldName, string newName)
		{
			var voicingLib = this.LoadVoicingLib(oldName);
			if (voicingLib == null)
				return;

			voicingLib.Name = newName;
			this.Save(voicingLib);

			this.Delete(oldName);
		}

		public void Save(VoicingLib voicingLib)
		{
			var serializedTest = XmlTools.Serialize(voicingLib);

			var filepath = this.BuildLibFolderPath(voicingLib.Name);
			if (File.Exists(filepath))
				File.Delete(filepath);

			File.WriteAllText(filepath, serializedTest);
		}

		public void Delete(string name)
		{
			var filepath = Path.Combine(_dataFolderPath, $"{name}.{FileExt}");
			if (File.Exists(filepath))
				File.Delete(filepath);
		}

		public List<VoicingLib> GetSystemLibs()
		{
			return _systemLibs;
		}

		#endregion

		#region Private Methods

		private List<VoicingLib> LoadAllVoicingLibs()
		{
			var allVoicingLibs = new List<VoicingLib>();

			//DirectoryInfo dirInfo = new DirectoryInfo(_dataFolderPath);
			//foreach (var fileInfo in dirInfo.GetFiles($"*.{FileExt}", SearchOption.TopDirectoryOnly)) {
			foreach (var name in ReadAllVoicingLibNames()) {
				try {
					var voicingLib = LoadVoicingLib(BuildLibFolderPath(name));
					allVoicingLibs.Add(voicingLib);
				}
				catch (Exception ex) {
					_log.Error($"[GetAllVoicingLibs] {ex.GetType().Name} attempting to load {name}: {ex.Message}", ex);
				}
			}
			return allVoicingLibs;
		}

		private List<string> ReadAllVoicingLibNames()
		{
			return Directory.GetFiles(_dataFolderPath, $"*.{FileExt}").Select(fp => Path.GetFileNameWithoutExtension(fp)).ToList();
		}

		private VoicingLib LoadVoicingLib(string name)
		{
			var filePath = BuildLibFolderPath(name);
			if (!File.Exists(filePath))
				return null;

			var fileInfo = new FileInfo(filePath);
			return LoadVoicingLib(fileInfo);
		}

		private VoicingLib LoadVoicingLib(FileInfo fileInfo)
		{
			var fileContents = File.ReadAllText(fileInfo.FullName);

			var voicingLib = XmlTools.Deserialize<VoicingLib>(fileContents);
			voicingLib.Name = Path.GetFileNameWithoutExtension(fileInfo.Name);

			return voicingLib;
		}

		private string BuildLibFolderPath(string libName)
		{
			return Path.Combine(_dataFolderPath, $"{libName}.{FileExt}");
		}

		private List<VoicingLib> BuildSystemLibs()
		{
			using (var scope = _lifetimeScope.BeginLifetimeScope()) {
				var builder = scope.Resolve<ISystemVoicingLibBuilder>();
				return builder.BuildAllSystemLibs();
			}
		}

		#endregion
	}
}
