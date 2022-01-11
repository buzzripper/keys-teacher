using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class ChordEditor : UserControl
	{
		#region Events

		public event EventHandler Changed;

		#endregion

		#region Fields

		private PdChord _chord;
		private bool _populating;
		private readonly List<CheckBox> _extCheckBoxes = new List<CheckBox>();
		private readonly List<NumericUpDown> _extNums = new List<NumericUpDown>();
		private readonly List<ComboBox> _extComboBoxes = new List<ComboBox>();

		// DEBUG
		//private ChordSymbol chordSymbol1;

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

				_extNums.Add(numExt1);
				_extNums.Add(numExt2);
				_extNums.Add(numExt3);

				_extComboBoxes.Add(cmbExt1);
				_extComboBoxes.Add(cmbExt2);
				_extComboBoxes.Add(cmbExt3);

				// Set data
				cmbNote.DataSource = PdNote.Notes;
				cmbQuality.DataSource = new List<Quality>((Quality[]) Enum.GetValues(typeof(Quality)));

				foreach (ComboBox cmb in _extComboBoxes) {
					cmb.DataSource = new List<Tuple<string, object>>{
						                 Tuple.Create<string, object>(string.Empty, Accidental.Natural),
						                 Tuple.Create<string, object>("-", Accidental.Flat),
						                 Tuple.Create<string, object>("+", Accidental.Sharp)
					                 };
					cmb.DisplayMember = "Item1";
					cmb.ValueMember = "Item2";
				}

				for (int index = 0; index < 3; index++)
					EnableExt(index, false);

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

		public PdChord Chord
		{
			get { return _chord; }
			set
			{
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
					_extCheckBoxes.ForEach(ckb => ckb.Checked = false);
					_extNums.ForEach(num => num.Value = 0);
					_extComboBoxes.ForEach(cmb => cmb.SelectedIndex = 0);
					cmbBassNotes.SelectedIndex = 0;
					//chordSymbol1.Visible = false;
					return;
				}

				// Set widgets
				cmbNote.SelectedItem = PdNote.Notes.Where(n => n.Letter == chord.Note.Letter && n.Accidental == chord.Note.Accidental).FirstOrDefault();
				cmbQuality.SelectedItem = chord.Quality;
				_extCheckBoxes.ForEach(ckb => ckb.Checked = false);
				int i = 0;
				foreach (ChordExt chordExt in chord.ChordExts) {
					if (chordExt.Degree > 0) {
						_extCheckBoxes[i].Checked = true;
						_extNums[i].Value = chordExt.Degree;
						_extComboBoxes[i].SelectedItem = GetTupleForAccidental(_extComboBoxes[i], chordExt.Accidental);
						EnableExt(i, true);
					} else {
						_extCheckBoxes[i].Checked = false;
						_extNums[i].Value = 0;
						_extComboBoxes[i].SelectedIndex = 0;
						EnableExt(i, false);
					}
					i++;
				}
				cmbBassNotes.SelectedIndex = GetCmbIndexForBassNote(chord.BassNote);

				chordSymbol1.Chord = chord;
				//chordSymbol1.Visible = true;
			} finally {
				_populating = false;
			}
		}

		#endregion

		private void EnableExt(int index, bool enable)
		{
			_extComboBoxes[index].Enabled = enable;

			NumericUpDown num = _extNums[index];
			if (enable) {
				num.BackColor = Color.White;
				num.ForeColor = Color.Black;
				num.ReadOnly = false;
			} else {
				num.BackColor = Color.Gainsboro;
				num.ForeColor = Color.Gainsboro;
				num.ReadOnly = true;
				_extComboBoxes[index].SelectedIndex = 0;
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
				_chord.Quality = (Quality) cmbQuality.SelectedItem;
			}
		}

		#region Check boxes

		private void ckbExt1_CheckedChanged(object sender, EventArgs e)
		{
			ckbExt_CheckedChanged(0);
		}

		private void ckbExt2_CheckedChanged(object sender, EventArgs e)
		{
			ckbExt_CheckedChanged(1);
		}

		private void ckbExt3_CheckedChanged(object sender, EventArgs e)
		{
			ckbExt_CheckedChanged(2);
		}

		private void ckbExt_CheckedChanged(int index)
		{
			if (!_populating) {
				if (_extCheckBoxes[index].Checked) {
					int degree = index == 0 ? 5 : index == 1 ? 9 : 13;
					_extNums[index].Value = degree;
					_extComboBoxes[index].SelectedIndex = 0;
					EnableExt(index, true);
				} else {
					_extNums[index].Value = 0;
					_extComboBoxes[index].SelectedIndex = 0;
					EnableExt(index, false);
				}
			}
		}

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
				_chord.ChordExts[index].Degree = (int) _extNums[index].Value;
		}

		#endregion

		#region Ext accidental combos

		private void cmbExt_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_populating) {
				ComboBox cmb = (ComboBox) sender;
				int idx = _extComboBoxes.IndexOf(cmb);
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
			return ((List<Tuple<string, object>>) combo.DataSource).Where(t => (Accidental) t.Item2 == accidental).FirstOrDefault();
		}

		private int GetCmbIndexForBassNote(PdNote bassNote)
		{
			if (bassNote == null)
				return 0;

			List<Tuple<string, object>> tuples = (List<Tuple<string, object>>) cmbBassNotes.DataSource;
			for (int i = 1; i < tuples.Count; i++) {
				// Skip the first
				PdNote note = (PdNote) tuples[i].Item2;
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
				return (PdNote) tuple.Item2;
			return null;
		}

		private Accidental GetComboValue(ComboBox combo)
		{
			return (Accidental) ((Tuple<string, object>) combo.SelectedItem).Item2;
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
						EnableExt(i, false);
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