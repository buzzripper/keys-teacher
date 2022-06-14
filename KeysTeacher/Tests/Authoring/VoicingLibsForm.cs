using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using KeysTeacher.Data;
using KeysTeacher.Misc;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.Authoring
{
    public partial class VoicingLibsForm : Form, IVoicingLibraryForm
    {
        #region Constants

        #endregion

        #region Events

        public event EventHandler<SelectVoicingsArgs> VoicingsSelected;

        #endregion

        private readonly IVoicingLibRepository _voicingLibRepository;
        private int _windowLeft;
        private int _windowTop;
        private int _windowHeight;
        private BindingList<string> _libNames;
        private BindingList<Voicing> _voicings;
        private VoicingLib _selectedLib;
        private readonly IMsgBox _msgBox;
        private readonly IVoicingLibNameForm _libNameForm;
        private readonly IVoicingEditorForm _voicingEditorForm;

        #region Initialization / Finalization

        public VoicingLibsForm(IVoicingLibRepository voicingLibRepository, IMsgBox msgBox, IVoicingLibNameForm libNameForm, IVoicingEditorForm voicingEditorForm)
        {
            InitializeComponent();

            _voicingLibRepository = voicingLibRepository;
            _msgBox = msgBox;
            _libNameForm = libNameForm;
            _voicingEditorForm = voicingEditorForm;

            _voicings = new BindingList<Voicing>();
            lbxVoicings.DataSource = _voicings;

            _libNames = new BindingList<string>(_voicingLibRepository.GetAllVoicingLibNames());
            cmbLibNames.DataSource = _libNames;
        }

        private void VoicingLibsForm_Load(object sender, EventArgs e)
        {
            cmbSysVoicingLibs.DataSource = _voicingLibRepository.GetSystemLibs();
        }

        #endregion

        #region VoicingLibs

        #region UI Events

        private void cmbLibNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectLib();
        }

        private void btnNewLib_Click(object sender, EventArgs e)
        {
            AddNewLib();
        }

        private void btnEditLib_Click(object sender, EventArgs e)
        {
            EditLibName();
        }

        private void btnDeleteLib_Click(object sender, EventArgs e)
        {
            DeleteLib();
        }

        private void cmbSysVoicingLibs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private VoicingLib SelectedLib
        {
            get { return _selectedLib; }
            set { 
                _selectedLib = value;
                UpdateState();
            }
        }

        private void UpdateState()
        {
            var enabled = this.SelectedLib != null;

            btnAddVoicing.Enabled = enabled;
            btnEditVoicing.Enabled = enabled;
            btnDeleteVoicing.Enabled = enabled;
            btnSelect.Enabled = enabled;
            btnAddSystemLib.Enabled = enabled; 
        }

        private void AddNewLib()
        {
            if (_libNameForm.Run(null) == DialogResult.OK) {
                this.SelectedLib = new VoicingLib();
                this.SelectedLib.Name = _libNameForm.LibName;
                _voicingLibRepository.Save(this.SelectedLib);

                _libNames.Add(_libNameForm.LibName);
                cmbLibNames.SelectedItem = _libNameForm.LibName;
                cmbLibNames.ResetBindings();
            }
        }

        private void EditLibName()
        {
            if (cmbLibNames.SelectedIndex == -1)
                return;

            var oldName = cmbLibNames.SelectedItem.ToString();

            if (_libNameForm.Run(oldName) == DialogResult.OK) {
                var newName = _libNameForm.LibName;
                _voicingLibRepository.UpdateName(oldName, newName);
                this.SelectedLib.Name = newName;
                var idx = _libNames.IndexOf(oldName);
                if (idx >= 0)
                    _libNames[idx] = newName;
                cmbLibNames.ResetBindings();
            }
        }

        private void DeleteLib()
        {
            if (cmbLibNames.SelectedIndex == -1)
                return;

            var name = cmbLibNames.SelectedItem.ToString();

            if (MessageBox.Show(this, $"Delete library '{name}'?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                _voicingLibRepository.Delete(name);
                _libNames.Remove(name);
                cmbLibNames.ResetBindings();
            }
        }

        private void SelectLib()
        {
            if (cmbLibNames.SelectedIndex == -1) {
                btnEditLib.Enabled = false;
                btnDeleteLib.Enabled = false;
                return;
            }
            btnEditLib.Enabled = true;
            btnDeleteLib.Enabled = true;

            var libName = cmbLibNames.SelectedItem.ToString();

            this.SelectedLib = _voicingLibRepository.GetVoicingLib(libName);
            if (this.SelectedLib == null) {
                _msgBox.ShowError($"Could not load library {libName}", "Error");
                return;
            }

            _voicings.Clear();
            this.SelectedLib.Voicings.ForEach(v => _voicings.Add(v));
            lbxVoicings.ResetBindings();
        }

        #endregion

        #region Voicings

        #region UI Events

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbxVoicings.SelectedItems.Count > 0)
                SelectVoicings();
        }

        private void lbxVoicings_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                if (lbxVoicings.SelectedItems.Count > 0)
                    SelectVoicings();
            }
        }

        private void lbxVoicings_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void lbxVoicings_DoubleClick(object sender, EventArgs e)
        {
            if (lbxVoicings.SelectedItems.Count > 0)
                SelectVoicings();
        }

        private void lbxVoicings_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditVoicing.Enabled = lbxVoicings.SelectedItems.Count == 1;
            btnDeleteVoicing.Enabled = lbxVoicings.SelectedItems.Count > 0;
            btnSelect.Enabled = lbxVoicings.SelectedItems.Count > 0;
            btnIncrCopies.Enabled = lbxVoicings.SelectedItems.Count == 1;
        }

        private void VoicingLibraryForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.E && e.Modifiers.HasFlag(Keys.Control)) {
            //    ToggleExpand();
            //}
        }

        #endregion

        public void Show(int windowLeft, int windowTop, int windowHeight)
        {
            _windowLeft = windowLeft;
            _windowTop = windowTop;
            _windowHeight = windowHeight;
            this.Visible = true;
        }

        private void VoicingLibraryForm_VisibleChanged(object sender, EventArgs e)
        {
            this.Left = _windowLeft;
            this.Top = _windowTop;
            this.Height = _windowHeight;
        }

        public void Reset(List<Voicing> voicings)
        {
            lbxVoicings.Items.Clear();
            foreach (var voicing in _voicings.Where(v => !IsInVoicingList(voicings, v)))
                lbxVoicings.Items.Add(voicing);

            btnSelect.Enabled = false;
        }

        private bool IsInVoicingList(List<Voicing> voicings, Voicing voicing)
        {
            string voicingStr = voicing.ToString();
            foreach (var v in voicings)
                if (v.ToString() == voicingStr)
                    return true;
            return false;
        }

        private void VoicingLibraryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        #endregion

        private void btnAddVoicing_Click(object sender, EventArgs e)
        {
            this.CreateVoicing();
        }

        private void btnEditVoicing_Click(object sender, EventArgs e)
        {
            this.EditVoicing();
        }

        private void btnDeleteVoicing_Click(object sender, EventArgs e)
        {
            this.DeleteVoicings();
        }

        private void SelectVoicings()
        {
            List<Voicing> voicings = new List<Voicing>();
            foreach (Voicing voicing in lbxVoicings.SelectedItems)
                voicings.Add(voicing);

            // Fire the event
            InvokeVoicingsSelected(voicings);

            lbxVoicings.SelectedIndex = -1;
        }

        private void InvokeVoicingsSelected(List<Voicing> voicings)
        {
            VoicingsSelected?.Invoke(this, new SelectVoicingsArgs(voicings));
        }

        private void CreateVoicing()
        {
            if (_voicingEditorForm.Run(new Voicing())) {
                _voicings.Add(_voicingEditorForm.Voicing);
                SaveLib(this.SelectedLib);
                lbxVoicings.ResetBindings();
            }
        }

        private void EditVoicing()
        {
            var voicing = lbxVoicings.SelectedItem as Voicing;
            if (voicing == null) {
                _msgBox.ShowError("The selected voicing is null.", "Internal Error");
                return;
            }

            if (_voicingEditorForm.Run(voicing.Clone())) {  // Send a clone to the editor
                voicing.CopyFrom(_voicingEditorForm.Voicing);
                lbxVoicings.ResetBindings();
            }
        }

        private void DeleteVoicings()
        {
            if (MessageBox.Show(this, $"Delete selected voicing(s)?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            List<Voicing> voicings = new List<Voicing>();
            foreach (Voicing voicing in lbxVoicings.SelectedItems)
                voicings.Add(voicing);

            foreach (Voicing voicing in voicings)
                _voicings.Remove(voicing);

            SaveLib(this.SelectedLib);
        }

        private void SaveLib(VoicingLib voicingLib)
        {
            try {
                voicingLib.Voicings.Clear();
                voicingLib.Voicings.AddRange(_voicings.ToList());
                _voicingLibRepository.Save(voicingLib);
            } catch (Exception ex) {
                MessageBox.Show($"{ex.GetType().Name} saving test: {ex.Message}", "Error Saving Test", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
        private void btnAddSystemLib_Click(object sender, EventArgs e)
        {
            var systemLib = cmbSysVoicingLibs.SelectedItem as VoicingLib;
            if (systemLib == null)
                return;

            foreach (var voicing in systemLib.Voicings) {
                if (_voicings.All(v => v.ToString() != voicing.ToString()))
                    _voicings.Add(voicing);
            }

            SaveLib(this.SelectedLib);
        }

        private void btnIncrCopies_Click(object sender, EventArgs e)
        {
            if (lbxVoicings.SelectedItems.Count != 1)
                return;

            if (MessageBox.Show($"Create {numIncrCopies.Value} incremental copies of this voicing?", "Create Incremental Copies", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                var voicing = (Voicing)lbxVoicings.SelectedItems[0];
                for (var i = 0; i < numIncrCopies.Value; i++) {
                    voicing = voicing.Clone();
                    voicing.Increment();
                    _voicings.Add(voicing);
                }
            }
        }
    }
}
