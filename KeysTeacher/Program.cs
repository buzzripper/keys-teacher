using System;
using System.Windows.Forms;
using Autofac;
using KeysTeacher.Controls;
using KeysTeacher.Data;
using KeysTeacher.Devices;
using KeysTeacher.Misc;
using KeysTeacher.Tests;
using KeysTeacher.Tests.Authoring;
using KeysTeacher.Tests.VoicingLibs;
using KeysTeacher.Tests.VoicingTests;
using log4net;
using ProDataMedia.Logging.Config;
using ProDataMedia.Logging.DI;

namespace KeysTeacher
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			try {
				LogConfigurator.Initialize(Globals.AppName, Globals.AppName);
				var log = LogManager.GetLogger(typeof(Form1).Name);
				log.Info("-------------  Starting application  -------------");

				log.Debug("Configuring container...");
				var container = InitializeContainer();

				log.Debug("Starting maing form...");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run((Form1)container.Resolve<IForm1>());
				Application.Exit();

			} catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		private static IContainer InitializeContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule(new LoggingDIModule());
			builder.Register(c => new MidiInDevice(c.Resolve<IMidiOutDevice>())).As<IMidiInDevice>().SingleInstance();
			builder.RegisterType<MidiOutDevice>().As<IMidiOutDevice>().SingleInstance();

			builder.RegisterType<VoicingTestRepository>().As<IVoicingTestRepository>().SingleInstance();
			builder.RegisterType<VoicingRepository>().As<IVoicingRepository>().SingleInstance();
			builder.RegisterType<VoicingRepository>().As<IVoicingRepository>().SingleInstance();
			builder.RegisterType<VoicingLibRepository>().As<IVoicingLibRepository>().SingleInstance();
			builder.RegisterType<VoicingEditorForm>().As<IVoicingEditorForm>().SingleInstance();
			builder.RegisterType<AppDataMgr>().As<IAppDataMgr>().SingleInstance();
			builder.RegisterType<WindowPlacement>().As<IWindowPlacement>().SingleInstance();

			builder.RegisterType<MsgBox>().As<IMsgBox>();
			builder.RegisterType<Form1>().As<IForm1>();
			builder.RegisterType<VoicingTestEditor>().As<IVoicingTestEditor>();
			builder.RegisterType<VoicingTestsMgr>().As<IVoicingTestsMgr>();
			builder.RegisterType<VoicingLibsForm>().As<IVoicingLibraryForm>();
			builder.RegisterType<VoicingExamForm>().As<IVoicingExamForm>();
			builder.RegisterType<MidiDeviceForm>().As<IMidiDeviceForm>();
			builder.RegisterType<VoicingTestResultsForm>().As<IVoicingTestResultsForm>();
			builder.RegisterType<VoicingLibNameForm>().As<IVoicingLibNameForm>();
			builder.RegisterType<SystemVoicingLibBuilder>().As<ISystemVoicingLibBuilder>();

			return builder.Build();
		}
	}
}