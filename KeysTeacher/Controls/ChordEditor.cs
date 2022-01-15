using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeysTeacher
{
    //public enum ExtState
    //{
    //    Enabled,
    //    ReadOnly,
    //    Disabled
    //}

    public partial class ChordEditor : UserControl
    {
        #region Events

        public event EventHandler Changed;

        #endregion

        #region Constants

        private const int ExtAccCount = 3;

        #endregion

        #region Fields

        private PdChord _chord;
        private bool _populating;
        private readonly List<CheckBox> _extCheckBoxes = new List<CheckBox>();
        private readonly List<NumericUpDown> _extNumUpDns = new List<NumericUpDown>();
        private readonly List<ComboBox> _extAccCombos = new List<ComboBox>();

        #endregion

        #region Constructors / Initialization / Finalization

        public ChordEditor()
        {
            InitializeComponent();

            _populating = true;
            try {
                // Set control arrays
                _extCheckBoxes.Add(ckbExt1);
                _extCheckBoxes.Add(ckbExt2);
                _extCheckBoxes.Add(ckbExt3);

                _extNumUpDns.Add(numExt1);
                _extNumUpDns.Add(numExt2);
                _extNumUpDns.Add(numExt3);

                _extAccCombos.Add(cmbExt1);
                _extAccCombos.Add(cmbExt2);
                _extAccCombos.Add(cmbExt3);

                // Set data
                cmbNote.DataSource = PdNote.Notes;
                cmbQuality.DataSource = new List<Quality>((Quality[])Enum.GetValues(typeof(Quality)));

                foreach (ComboBox cmb in _extAccCombos) {
                    cmb.DataSource = new List<Tuple<string, object>>{
                                         Tuple.Create<string, object>(string.Empty, Accidental.Natural),
                                         Tuple.Create<string, object>("-", Accidental.Flat),
                                         Tuple.Create<string, object>("+", Accidental.Sharp)
                                     };
                    cmb.DisplayMember = "Item1";
                    cmb.ValueMember = "Item2";
                }

                for (int index = 0; index < ExtAccCount; index++)
                    SetExtState(index, false, false);

                List<Tuple<string, object>> bassNoteTuples = new List<Tuple<string, object>>{
                                                                 Tuple.Create<string, object>(string.Empty, null)
                                                             };
                foreach (PdNote note in PdNote.Notes)
                    bassNoteTuples.Add(Tuple.Create<string, object>(note.ToString(), note));
                cmbBassNotes.DataSource = bassNoteTuples;
                cmbBassNotes.DisplayMember = "Item1";
                cmbBassNotes.ValueMember = "Item2";

            } finally {
                _populating = false;
            }
        }

        #endregion

        #region Properties

        public PdChord Chord {
            get { return _chord; }
            set {
                _chord = value;
                if (_chord != null)
                    _chord.PropertyChanged += ChordPropertyChanged;
                Populate(value);
            }
        }

        private void Populate(PdChord chord)
        {
            _populating = true;

            try {
                if (chord == null) {
                    cmbNote.SelectedIndex = 0;
                    cmbQuality.SelectedIndex = 0;
                    for (var i=0; i< ExtAccCount; i++) {
                        _extCheckBoxes[i].Checked = false;
                        _extNumUpDns[i].Value = GetDefaultValueForExtDegree(i);
                        _extAccCombos[i].SelectedIndex = 0;
                        SetExtState(i, i == 0 ? true : false, false);
                    }
                    cmbBassNotes.SelectedIndex = 0;
                    return;
                }

                // Set widgets
                cmbNote.SelectedItem = PdNote.Notes.Where(n => n.Letter == chord.Note.Letter && n.Accidental == chord.Note.Accidental).FirstOrDefault();
                cmbQuality.SelectedItem = chord.Quality;

                for (var i = 0; i < ExtAccCount; i++) {
                    var chordExt = chord.ChordExts[i];
                    if (chordExt.Degree > 0) {
                        _extCheckBoxes[i].Checked = true;
                        _extNumUpDns[i].Value = chordExt.Degree;
                        _extAccCombos[i].SelectedItem = GetTupleForAccidental(_extAccCombos[i], chordExt.Accidental);
                        SetExtState(i, true, true);
                    } else {
                        _extCheckBoxes[i].Checked = false;
                        _extNumUpDns[i].Value = i == 0 ? 5 : i == 1 ? 9 : 13;
                        _extAccCombos[i].SelectedIndex = 0;
                        SetExtState(i, i == 0 ? true : false, false);
                    }
                }
                cmbBassNotes.SelectedIndex = GetCmbIndexForBassNote(chord.BassNote);

                chordSymbol1.Chord = chord;

            } finally {
                _populating = false;
            }
        }

        private int GetDefaultValueForExtDegree(int index)
        {
            switch (index) {
                case 0:
                    return 7;
                case 1:
                    return 9;
                default:
                    return 13;
            }
        }

        #endregion

        private void SetExtState(int index, bool enableCkb, bool enableEditing)
        {
            _extCheckBoxes[index].Enabled = enableCkb;

            var numUpDn = _extNumUpDns[index];
            var accCmb = _extAccCombos[index];

            if (enableEditing) {
                    numUpDn.BackColor = Color.White;
                    numUpDn.ForeColor = Color.Black;
                    numUpDn.Enabled = true;
                    accCmb.BackColor = Color.White;
                    accCmb.ForeColor = Color.Black;
                    accCmb.Enabled = true;
            } else {
                    numUpDn.BackColor = Color.Gainsboro;
                    numUpDn.ForeColor = Color.Gainsboro;
                    numUpDn.Enabled = false;
                    accCmb.BackColor = Color.Gainsboro;
                    accCmb.ForeColor = Color.Gainsboro;
                    accCmb.Enabled = false;
            }
        }

        #region UI Events

        private void cmbNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                _chord.Note = cmbNote.SelectedItem as PdNote;
            }
        }

        private void cmbQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                _chord.Quality = (Quality)cmbQuality.SelectedItem;
            }
        }

        #region Check boxes

        private void ckbExt1_CheckedChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                if (_extCheckBoxes[0].Checked) {
                    SetExtState(0, true, true);
                    SetExtState(1, true, false);
                    this.Chord.ChordExts[0].Degree = Convert.ToInt32(_extNumUpDns[0].Value);
                    this.Chord.ChordExts[0].Accidental = this.GetAccidentalFromCombo(_extAccCombos[0]);
                } else {
                    SetExtState(0, true, false);
                    SetExtState(1, false, false);
                    this.Chord.ChordExts[0].Degree = 0;
                }
            }
        }

        private void ckbExt2_CheckedChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                if (_extCheckBoxes[1].Checked) {
                    SetExtState(0, false, true);
                    SetExtState(1, true, true);
                    SetExtState(2, true, false);
                    this.Chord.ChordExts[1].Degree = Convert.ToInt32(_extNumUpDns[1].Value);
                    this.Chord.ChordExts[1].Accidental = this.GetAccidentalFromCombo(_extAccCombos[1]);
                } else {
                    SetExtState(0, true, true);
                    SetExtState(1, true, false);
                    SetExtState(2, false, false);
                    this.Chord.ChordExts[1].Degree = 0;
                }
            }
        }

        private void ckbExt3_CheckedChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                if (_extCheckBoxes[2].Checked) {
                    SetExtState(1, false, true);
                    SetExtState(2, true, true);
                    this.Chord.ChordExts[2].Degree = Convert.ToInt32(_extNumUpDns[2].Value);
                    this.Chord.ChordExts[2].Accidental = this.GetAccidentalFromCombo(_extAccCombos[2]);
                } else {
                    SetExtState(1, true, true);
                    SetExtState(2, true, false);
                    this.Chord.ChordExts[2].Degree = 0;
                }
            }
        }

        //private void ckbExt_CheckedChanged(int index)
        //{
        //    if (!_populating) {
        //        if (_extCheckBoxes[index].Checked) {
        //            int degree = index == 0 ? 5 : index == 1 ? 9 : 13;
        //            _extNums[index].Value = degree;
        //            _extComboBoxes[index].SelectedIndex = 0;
        //            SetExtEnabled(index, true, true);
        //        } else {
        //            _extNums[index].Value = 0;
        //            _extComboBoxes[index].SelectedIndex = 0;
        //            SetExtEnabled(index, false);
        //        }

        //        //EnableExt(2, _extCheckBoxes[1].Checked);
        //        //EnableExt(1, _extCheckBoxes[0].Checked);
        //    }
        //}

        #endregion

        #region Degree numerics

        private void numExt1_ValueChanged(object sender, EventArgs e)
        {
            numExt_ValueChanged(0);
        }

        private void numExt2_ValueChanged(object sender, EventArgs e)
        {
            numExt_ValueChanged(1);
        }

        private void numExt3_ValueChanged(object sender, EventArgs e)
        {
            numExt_ValueChanged(2);
        }

        private void numExt_ValueChanged(int index)
        {
            if (_chord != null)
                _chord.ChordExts[index].Degree = (int)_extNumUpDns[index].Value;
        }

        #endregion

        #region Ext accidental combos

        private void cmbExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                ComboBox cmb = (ComboBox)sender;
                int idx = _extAccCombos.IndexOf(cmb);
                _chord.ChordExts[idx].Accidental = GetComboValue(cmb);
            }
        }

        #endregion

        private void cmbBassNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_populating) {
                _chord.BassNote = GetBassNoteFromCmbIndex(cmbBassNotes.SelectedIndex);
            }
        }

        private Tuple<string, object> GetTupleForAccidental(ComboBox combo, Accidental accidental)
        {
            return ((List<Tuple<string, object>>)combo.DataSource).Where(t => (Accidental)t.Item2 == accidental).FirstOrDefault();
        }

        private Accidental GetAccidentalFromCombo(ComboBox combo)
        {
            switch (combo.SelectedIndex) {
                case 0:
                    return Accidental.Natural;
                case 1:
                    return Accidental.Flat;
                default:
                    return Accidental.Sharp;
            }
        }

        private int GetCmbIndexForBassNote(PdNote bassNote)
        {
            if (bassNote == null)
                return 0;

            List<Tuple<string, object>> tuples = (List<Tuple<string, object>>)cmbBassNotes.DataSource;
            for (int i = 1; i < tuples.Count; i++) {
                // Skip the first
                PdNote note = (PdNote)tuples[i].Item2;
                if (note.Letter == bassNote.Letter && note.Accidental == bassNote.Accidental)
                    return i;
            }

            return -1;
        }

        private PdNote GetBassNoteFromCmbIndex(int index)
        {
            if (index < 1)
                return null;
            Tuple<string, object> tuple = cmbBassNotes.Items[index] as Tuple<string, object>;
            if (tuple != null)
                return (PdNote)tuple.Item2;
            return null;
        }

        private Accidental GetComboValue(ComboBox combo)
        {
            return (Accidental)((Tuple<string, object>)combo.SelectedItem).Item2;
        }

        private void ChordEditor_BackColorChanged(object sender, EventArgs e)
        {
            chordSymbol1.BackColor = this.BackColor;
        }

        #endregion

        private void ChordEditor_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled) {
                _populating = true;
                try {
                    _extCheckBoxes.ForEach(ckb => ckb.Checked = false);
                    for (int i = 0; i < 3; i++) {
                        _extCheckBoxes[i].Checked = false;
                        SetExtState(i, false, false);
                    }
                } finally {
                    _populating = false;
                }
            }
            chordSymbol1.Visible = this.Enabled;
        }

        private void ChordPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FirePropertyChanged(e.PropertyName);
        }

        private void FirePropertyChanged(string propertyName)
        {
            EventHandler handler = Changed;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}