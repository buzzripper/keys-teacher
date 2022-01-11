using System;
using System.IO;

namespace KeysTeacher
{
	public static class Globals
	{
		public const string CompanyName = "ProDataMedia";
		public const string AppName = "KeysTeacher";
		public const int DataMaxValue = 127;
		public const string ImgsRoot = "KeysTeacher.Images";
		public const string DataFolderName = "Data";

		public static readonly string DataRootFolder;

		static Globals()
		{
			DataRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyName, AppName, DataFolderName);
		}
	}
}