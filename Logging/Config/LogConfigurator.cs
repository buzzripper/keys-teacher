using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace ProDataMedia.Logging.Config
{
	public static class LogConfigurator
	{
		private const string ConfigSectionName = "proDataLogging";

		public static void Initialize(string appName, string logFiletitle)
		{
			try
			{
				// Make sure there's at least 1 appender configured
				if (string.IsNullOrEmpty(appName))
				{
					Trace.TraceError("No appName provided.");
					return;
				}

				// Make sure there's a avtecLog config section
				var logConfigSection = ConfigurationManager.GetSection(ConfigSectionName) as LogConfigSection;
				if (logConfigSection == null)
				{
					Trace.TraceError($"Configuration section '{ConfigSectionName}' not found.");
					return;
				}

				// Make sure there's at least 1 appender configured
				if (logConfigSection.ActiveAppenders.Count == 0)
				{
					Trace.TraceError($"No appenders configured in {ConfigSectionName} configuration section.");
					return;
				}

				// log4net general settings
				Hierarchy hierarchy = (Hierarchy) LogManager.GetRepository();
				hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/
				hierarchy.Root.Level = LevelFromString(logConfigSection.Level);

				var logsFolder = AppDomain.CurrentDomain.BaseDirectory;

				// Appenders
				var anySuccessfulAppenders = false;
				foreach (var activeAppenders in logConfigSection.ActiveAppenders)
				{
					if (activeAppenders.Name.ToLower() == "rollingfileappender")
					{
						if (ConfigureRollingFileAppender(logConfigSection.RollingFileAppender, logFiletitle ?? appName, logsFolder))
						{
							anySuccessfulAppenders = true;
						}
					}
					else if (activeAppenders.Name.ToLower() == "adonetappender")
					{
						if (ConfigureAdoNetAppender(logConfigSection.AdoNetAppender))
						{
							anySuccessfulAppenders = true;
						}
					}
					else
					{
						Trace.TraceWarning("Unrecognized appender name: {0}", activeAppenders.Name);
					}
				}
				if (!anySuccessfulAppenders)
				{
					Trace.TraceError("No appenders successfully configured. No logging currently functioning.");
					return;
				}

				// Global Properties
				GlobalContext.Properties[LogConstants.HostName] = Environment.MachineName;
				GlobalContext.Properties[LogConstants.AppName] = appName;
			}
			catch (Exception ex)
			{
				Trace.TraceError("{0} reading avtecLog configuration section: {1}", ex.GetType().Name, ex);
				throw;
			}
		}

		private static Level LevelFromString(string levelStr)
		{
			var lowerLevelStr = levelStr.ToLower();
			if (lowerLevelStr == "trace")
			{
				return Level.Trace;
			}
			if (lowerLevelStr == "debug")
			{
				return Level.Debug;
			}
			if (lowerLevelStr == "info")
			{
				return Level.Info;
			}
			if (lowerLevelStr == "warn")
			{
				return Level.Warn;
			}
			if (lowerLevelStr == "error")
			{
				return Level.Error;
			}
			if (lowerLevelStr == "fatal")
			{
				return Level.Fatal;
			}

			Trace.TraceError($"Unable to parse avtecLog 'Level' configuration item ({levelStr}). Using the default level 'Info'");
			return Level.Info;
		}

		private static bool ConfigureRollingFileAppender(RollingFileAppenderConfig config, string logFiletitle, string logsFolder)
		{
			try
			{
				if (string.IsNullOrEmpty(logFiletitle))
				{
					throw new Exception("No log file name provided.");
				}

				var filename = string.Format("{0}.log", logFiletitle);
				var filepath = logsFolder != null ? Path.Combine(logsFolder, filename) : filename;

				RollingFileAppender rollingFileAppender = new RollingFileAppender();
				rollingFileAppender.File = filepath;
				rollingFileAppender.AppendToFile = true;
				rollingFileAppender.MaxFileSize = config.MaxFileSize;
				rollingFileAppender.MaxSizeRollBackups = config.MaxNumBackupFiles;
				PatternLayout patternLayout = new PatternLayout();
				//patternLayout.ConversionPattern = "%level`%utcdate{ISO8601}`%property{HostName}`%property{AppName}`%logger`%message`%property{CurrentUser}`%username`%property{AppSessionId}`%thread`%property{TraceId}`%exception%newline";
				patternLayout.ConversionPattern = "%date{ISO8601} [%-7level] %-20logger %message %exception%newline";
				patternLayout.ActivateOptions();
				rollingFileAppender.Layout = patternLayout;
				rollingFileAppender.ActivateOptions();
				BasicConfigurator.Configure(rollingFileAppender);

				return true;
			}
			catch (Exception ex)
			{
				Trace.TraceError($"{ex.GetType().Name} attempting to configure RollingFileAppender: {ex}");
				return false;
			}
		}

		private static bool ConfigureAdoNetAppender(AdoNetAppenderConfig config)
		{
			try
			{
				const string defConnectionType = "System.Data.SqlClient.SqlConnection, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

				AdoNetAppender adoNetAppender = new AdoNetAppender();
				adoNetAppender.BufferSize = config.BufferSize;
				adoNetAppender.ConnectionStringName = config.ConnectionStringName;
				adoNetAppender.ConnectionType = string.IsNullOrEmpty(config.ConnectionType) ? defConnectionType : config.ConnectionType;
				adoNetAppender.CommandType = CommandType.Text;
				adoNetAppender.CommandText =
					"INSERT INTO Log ([LogLevel],[LogTimestamp],[HostName],[AppName],[LogSource],[CurrentUser],[LogMessage],[AppSessionId],[Thread],[TraceId],[Exception]) VALUES (@LogLevel, @LogTimestamp, @HostName, @AppName, @LogSource, @CurrentUser, @LogMessage, @AppSessionId, @Thread, @TraceId, @Exception)";

				AdoNetAppenderParameter param = new AdoNetAppenderParameter();
				param.ParameterName = "@LogLevel";
				param.DbType = DbType.String;
				param.Size = 10;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%level"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@LogTimestamp";
				param.DbType = DbType.DateTime;
				param.Layout = new RawUtcTimeStampLayout();
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@HostName";
				param.DbType = DbType.String;
				param.Size = 100;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%property{HostName}"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@AppName";
				param.DbType = DbType.String;
				param.Size = 100;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%property{AppName}"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@LogSource";
				param.DbType = DbType.String;
				param.Size = 200;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%logger"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@CurrentUser";
				param.DbType = DbType.String;
				param.Size = 200;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%property{CurrentUser}"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@LogMessage";
				param.DbType = DbType.String;
				param.Size = 2000;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%message"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@AppSessionId";
				param.DbType = DbType.String;
				param.Size = 88;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%property{AppSessionId}"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@Thread";
				param.DbType = DbType.String;
				param.Size = 20;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%thread"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@TraceId";
				param.DbType = DbType.String;
				param.Size = 50;
				param.Layout = new Layout2RawLayoutAdapter(GetPatternLayout("%property{TraceId}"));
				adoNetAppender.AddParameter(param);

				param = new AdoNetAppenderParameter();
				param.ParameterName = "@exception";
				param.DbType = DbType.String;
				param.Size = 2000;
				param.Layout = new Layout2RawLayoutAdapter(new ExceptionLayout());
				adoNetAppender.AddParameter(param);

				adoNetAppender.ActivateOptions();

				BasicConfigurator.Configure(adoNetAppender);

				return true;
			}
			catch (Exception ex)
			{
				Trace.TraceError($"{ex.GetType().Name} attempting to configure AdoNetAppender: {ex}");
				return false;
			}
		}

		private static PatternLayout GetPatternLayout(string pattern)
		{
			PatternLayout patternLayout = new PatternLayout{
				                                               ConversionPattern = pattern
			                                               };
			patternLayout.ActivateOptions();
			return patternLayout;
		}
	}
}