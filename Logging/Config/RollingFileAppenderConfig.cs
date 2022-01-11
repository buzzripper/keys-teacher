using System.Configuration;

namespace ProDataMedia.Logging.Config
{
	public class RollingFileAppenderConfig : ConfigurationElement
	{
		//[ConfigurationProperty("file", IsRequired = true)]
		//public string File
		//{
		//    get { return (string) this["file"]; }
		//}

		[ConfigurationProperty("maxFileSize", IsRequired = true, DefaultValue = 100000000)]
		[IntegerValidator(MinValue = 10000)]
		public int MaxFileSize
		{
			get { return (int) this["maxFileSize"]; }
		}

		[ConfigurationProperty("maxNumBackupFiles", IsRequired = true, DefaultValue = 1)]
		[IntegerValidator(MinValue = 1)]
		public int MaxNumBackupFiles
		{
			get { return (int) this["maxNumBackupFiles"]; }
		}
	}
}