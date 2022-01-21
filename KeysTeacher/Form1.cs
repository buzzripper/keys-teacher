using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using KeysTeacher.Data;
using KeysTeacher.Devices;
using KeysTeacher.HomeControls;
using KeysTeacher.Tests.VoicingLibs;
using KeysTeacher.Tests.VoicingTests;
using log4net;
using Sanford.Multimedia.Midi;

namespace KeysTeacher
{
    public partial class Form1 : Form, IForm1
    {
        public static Form1 MainForm;

        #region Constants


        #endregion

        #region Fields

        private readonly IMidiInDevice _midiInDevice;
        private readonly IMidiOutDevice _midiOutDevice;
        private Dictionary<HomeControlType, IHomeControlBase> _homeControls;
        private IHomeControlBase _activeHomeControl;
        private readonly IVoicingTestsMgr _voicingTestsMgr;
        private readonly IVoicingTestEditor _voicingTestEditor;
        private readonly ILog _log;
        private readonly IMidiDeviceForm _midiDeviceForm;
        private readonly IAppDataMgr _appDataMgr;
        private readonly IWindowPlacement _windowPlacement;
        private readonly IVoicingLibRepository _voicingLibRepository;
        private readonly IVoicingTestRepository _voicingTestRepository;

        #endregion

        #region Constructors / Initialization / Finalization

        public Form1(ILog log, IVoicingTestsMgr voicingTestsMgr, IVoicingTestEditor voicingTestEditor, IMidiInDevice midiInDevice, IMidiOutDevice midiOutDevice, IMidiDeviceForm midiDeviceForm, IAppDataMgr appDataMgr, IWindowPlacement windowPlacement, IVoicingLibRepository voicingLibRepository, IVoicingTestRepository voicingTestRepository)
        {
            InitializeComponent();

            _log = log;

            _voicingTestsMgr = voicingTestsMgr;
            _voicingTestsMgr.ShowVoicingTestEditor += _voicingTestsMgr_ShowVoicingTestEditor;

            _voicingTestEditor = voicingTestEditor;
            _midiInDevice = midiInDevice;
            _midiOutDevice = midiOutDevice;
            _midiDeviceForm = midiDeviceForm;
            _appDataMgr = appDataMgr;
            _windowPlacement = windowPlacement;
            _voicingTestEditor.EditVoicingTestComplete += VoicingTestEditor_EditVoicingTestComplete;
            _voicingLibRepository = voicingLibRepository;
            _voicingTestRepository = voicingTestRepository;

            MainForm = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            try {
                _appDataMgr.Load();

                if (!InitializeMidiDevices(_appDataMgr.AppData.InDeviceId, _appDataMgr.AppData.OutDeviceId)) {
                    //MessageBox.Show("Unable to open midi device(s). Shutting down.");
                    //Close();
                    //return;
                }

                InitializeHomeControls();

                ActivateHomeControl(HomeControlType.VoicingTestMgr);

                _windowPlacement.SetPlacement(this.Handle, _appDataMgr.AppData.WindowPlacement);

            } catch (Exception ex) {
                MessageBox.Show(string.Format(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop));
                this.Close();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _log.Info("-------------  Ending Application  -------------");
        }

        #region Midi Devices

        private bool InitializeMidiDevices(int midiInDeviceId, int midiOutDeviceId)
        {
            _midiOutDevice.DeviceChanged += OnMidiOutDeviceChanged;

            _midiInDevice.NoteOn += OnNoteOn;
            _midiInDevice.NoteOff += OnNoteOff;
            _midiInDevice.DeviceChanged += OnMidiInDeviceChanged;

            if (midiInDeviceId < 0 || midiOutDeviceId < 0)
                return ShowDevicesDialog();

            if (midiInDeviceId >= 0) {
                _midiInDevice.SetDeviceFromId(midiInDeviceId);
                _midiInDevice.MidiThru = _appDataMgr.AppData.MidiThru;
            }

            if (midiOutDeviceId >= 0)
                _midiOutDevice.SetDeviceFromId(midiOutDeviceId);

            return true;
        }

        private bool ShowDevicesDialog()
        {
            if (_midiDeviceForm.Run() == DialogResult.OK) {
                return true;
            }
            return false;
        }

        private void mnuDevices_Click(object sender, EventArgs e)
        {
            ShowDevicesDialog();
        }

        public void OnMidiInDeviceChanged(object sender, DeviceChangedArgs deviceChangedEventArgs)
        {
            stsInput.Text = $"Midi In: {deviceChangedEventArgs.DeviceName}";
        }

        public void OnMidiOutDeviceChanged(object sender, DeviceChangedArgs deviceChangedEventArgs)
        {
            stsOutput.Text = $"Midi Out: {deviceChangedEventArgs.DeviceName}";
        }

        #endregion

        private void InitializeHomeControls()
        {
            _homeControls = new Dictionary<HomeControlType, IHomeControlBase>();

            // Voicing Tests
            _homeControls.Add(HomeControlType.VoicingTestMgr, _voicingTestsMgr);
            _homeControls.Add(HomeControlType.VoicingTestEditor, _voicingTestEditor);

            // Progression Tests
            //_progTestsMgr = new ProgTestsMgr(this.AppData.ProgTests, new ProgressionsBuilder().BuildProgressions());
            //_homeControls.Add(nbnProgTests, _progTestsMgr);

            foreach (HomeControlBase homeControl in _homeControls.Values) {
                homeControl.Visible = false;
                homeControl.Dock = DockStyle.Fill;
                homeControl.NeedSaving += OnHomeControlNeedSaving;
                HomeControlsPnl.Controls.Add(homeControl);
            }
        }

        private void OnHomeControlNeedSaving(object sender, EventArgs e)
        {
            _appDataMgr.AppData.InDeviceId = _midiInDevice.DeviceId;
            _appDataMgr.AppData.OutDeviceId = _midiOutDevice.DeviceId;
            _appDataMgr.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                _appDataMgr.AppData.InDeviceId = _midiInDevice.DeviceId;
                _appDataMgr.AppData.OutDeviceId = _midiOutDevice.DeviceId;
                _appDataMgr.AppData.WindowPlacement = _windowPlacement.GetPlacementData(this.Handle);
                _appDataMgr.Save();
            } catch (Exception ex) {
                _log.Error(string.Format("[Form1_FormClosing] {0} saving app data: {1}", ex.GetType().Name, ex.Message), ex);
            }

            try {
                _midiInDevice?.Dispose();
                _midiOutDevice?.Dispose();
            } catch (Exception ex) {
                _log.Error($"[Form1_FormClosing] {ex.GetType().Name} closing midi devices: {ex}");
            }
        }

        #endregion

        #region Properties

        public InputDevice InputMidiDevice { get; set; }

        public OutputDevice OutputMidiDevice { get; set; }

        #endregion

        #region Note Events

        public void OnNoteOn(object sender, NoteEventArgs noteEventArgs)
        {
            rbMidiActivity.Checked = true;
        }

        public void OnNoteOff(object sender, NoteEventArgs noteEventArgs)
        {
            rbMidiActivity.Checked = false;
        }

        #endregion

        private void VoicingTestEditor_EditVoicingTestComplete(object sender, EditVoicingTestCompleteArgs e)
        {
            //_voicingTestsMgr.EditTestComplete(e.VoicingTest);
            ActivateHomeControl(HomeControlType.VoicingTestMgr);
        }

        #region Navigation

        private void _voicingTestsMgr_ShowVoicingTestEditor(object sender, ShowVoicingTestEditorArgs e)
        {
            _voicingTestEditor.Run(e.VoicingTest);
            ActivateHomeControl(HomeControlType.VoicingTestEditor);
        }

        private void ActivateHomeControl(HomeControlType homeControlType)
        {
            foreach (HomeControlType hct in Enum.GetValues(typeof(HomeControlType))) {
                if (hct == homeControlType) {
                    _activeHomeControl = _homeControls[homeControlType];
                    _activeHomeControl.Activate();
                } else {
                    if (_homeControls[hct].IsActive) {
                        _homeControls[hct].Deactivate();
                    }
                }
            }
        }

        #endregion

        #region UI Events

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _activeHomeControl?.SendKeyDown(e);
        }

        #endregion

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            var appDataClone = _appDataMgr.AppData.Clone();
            using (var optionsForm = new OptionsForm()) {
                if (optionsForm.Run(this, appDataClone)) {
                    _appDataMgr.AppData.CopyFrom(appDataClone);
                    if (_midiInDevice != null)
                        _midiInDevice.MidiThru = _appDataMgr.AppData.MidiThru;
                }
            }
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            saveFileDlg.InitialDirectory = _appDataMgr.AppData.MRUBackupFolder;
            if (saveFileDlg.ShowDialog() == DialogResult.OK) {
                try {
                    BackupData(saveFileDlg.FileName);
                    _appDataMgr.AppData.MRUBackupFolder = Path.GetDirectoryName(saveFileDlg.FileName);
                } catch (Exception ex) {
                    MessageBox.Show(this, $"Error during backup: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BackupData(string backupFilepath)
        {
            var srcZipFilepath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Substring(10));
            try {
                ZipFile.CreateFromDirectory(Globals.DataRootFolder, srcZipFilepath);
                File.Copy(srcZipFilepath, backupFilepath);
                MessageBox.Show(this, "Backup completed successfully.", "Backup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } finally {
                File.Delete(srcZipFilepath);
            }
        }

        private RestoreForm _restoreForm;

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            if (_restoreForm == null)
                _restoreForm = new RestoreForm();

            if (_restoreForm.Run(this, _appDataMgr.AppData.MRUBackupFolder)) {
                this.RestoreData(_restoreForm.BackupFilepath, _restoreForm.IncludeSettings, _restoreForm.IncludeVoicingLibs, _restoreForm.IncludeVoicingTests, _restoreForm.IncludeTestResults);
            }
        }

        private void RestoreData(string backupFilepath, bool includeSettings, bool includeVoicingLibs, bool includeVoicingTests, bool includeTestResults)
        {
            var tempZipFilepath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString().Substring(10)}.tmp");
            try {
                File.Copy(backupFilepath, tempZipFilepath);

                var tempExtractFolder = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString().Substring(10)}");
                Directory.CreateDirectory(tempExtractFolder);

                ZipFile.ExtractToDirectory(tempZipFilepath, tempExtractFolder);

                if (includeSettings) {
                    var src = Path.Combine(tempExtractFolder, AppDataMgr.DataFilename);
                    if (File.Exists(src)) {
                        var dest = _appDataMgr.DataFilepath;
                        File.Copy(src, dest, true);
                    }
                }

                if (includeVoicingLibs) {
                    var srcFolder = Path.Combine(tempExtractFolder, VoicingLibRepository.VoicingLibsFolder);
                    if (Directory.Exists(srcFolder)) {
                        var destFolder = _voicingLibRepository.DataFolderPath;
                        if (Directory.Exists(destFolder)) {
                            foreach (var srcFilepath in Directory.GetFiles(srcFolder, "*.vlb")) {
                                var destFilepath = Path.Combine(destFolder, Path.GetFileName(srcFilepath));
                                File.Copy(srcFilepath, destFilepath, true);
                            }
                        }
                    }
                }

                if (includeVoicingTests) {
                    var srcFolder = Path.Combine(tempExtractFolder, VoicingTestRepository.VoicingTestFolder);
                    if (Directory.Exists(srcFolder)) {
                        var destFolder = _voicingTestRepository.DataFolderPath;
                        if (Directory.Exists(destFolder)) {
                            foreach (var srcFilepath in Directory.GetFiles(srcFolder, "*.vt")) {
                                var destFilepath = Path.Combine(destFolder, Path.GetFileName(srcFilepath));
                                File.Copy(srcFilepath, destFilepath, true);
                            }
                        }
                    }
                }

                if (includeTestResults) {
                    var src = Path.Combine(tempExtractFolder, VoicingTestsMgr.TestResultsFilename);
                    if (File.Exists(src)) {
                        var dest = Path.Combine(Globals.DataRootFolder, VoicingTestsMgr.TestResultsFilename); ;
                        File.Copy(src, dest, true);
                    }
                }

            } catch (Exception ex) {
                MessageBox.Show(this, $"Error during backup: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } finally {
                File.Delete(tempZipFilepath);
            }
        }
    }
}