using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using KeysTeacher.HomeControls;
using KeysTeacher.Music;

namespace KeysTeacher
{
	public partial class VoicingListEditor : HomeControlBase
	{
		#region Events

		public event EventHandler<PlayedChordEventArgs> PlayedChord;

		#endregion

		#region Constants

		private const string FILENAME = "Voicings.vlb";

		#endregion

		#region Fields

		//private bool _initialized;
		private EditState _editState;
		private bool _populating;
		private readonly BindingSource _bindingSource;
		private readonly Voicing _undoVoicing = new Voicing();

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingListEditor(List<Voicing> voicings)
		{
			InitializeComponent();

			_bindingSource = new BindingSource();
			_bindingSource.CurrentChanged += _bindingSource_CurrentChanged;
			_bindingSource.DataSource = voicings;
			lbxVoicings.DataSource = _bindingSource;

			voicingEditor1.Changed += VoicingEditor1Changed;
			voicingEditor1.PlayedChord += voicingEditor1_PlayedChord;
			voicingEditor1.Enabled = false;
		}

		private void VoicingListEditor_Load(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		//public override void Activate()
		//{
		//    try {
		//        if (!_initialized)
		//            this.Initialize();

		//    } finally {
		//        base.Activate();
		//    }
		//}

		//private void Initialize()
		//{
		//    try {
		//        //this.LoadVoicings();
		//        //    lbxVoicings.DataSource = _bindingSource;

		//    } finally {
		//        this.Visible = true;
		//        _initialized = true;
		//    }
		//}

		#endregion

		#region Properties

		private void SetEditState(EditState editState)
		{
			_editState = editState;
			switch (editState) {
				case EditState.Adding:
				case EditState.Editing:
					btnAdd.Enabled = false;
					btnAddCopy.Enabled = false;
					btnCancel.Enabled = true;
					btnSave.Enabled = true;
					btnDelete.Enabled = false;
					voicingEditor1.Enabled = true;
					EnableListBox(false);
					break;

				default: // EditState.Normal
					btnAdd.Enabled = true;
					btnAddCopy.Enabled = lbxVoicings.SelectedIndex > -1;
					btnCancel.Enabled = false;
					btnSave.Enabled = false;
					btnDelete.Enabled = lbxVoicings.SelectedIndex > -1;
					voicingEditor1.Enabled = lbxVoicings.SelectedIndex > -1;
					EnableListBox(true);
					break;
			}
		}

		private void EnableListBox(bool enable)
		{
			if (enable) {
				lbxVoicings.Enabled = true;
				//lbxVoicings.ResumeLayout();
			} else {
				lbxVoicings.Enabled = false;
				//lbxVoicings.SuspendLayout();
			}
		}

		#endregion

		#region Persist voicings

		//public void LoadVoicings()
		//{
		//    var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);

		//    List<Voicing> voicings;
		//    if (File.Exists(filepath))
		//        voicings = Utils.XmlDeserializeFromFile<List<Voicing>>(filepath);
		//    else
		//        voicings = new List<Voicing>();

		//    _bindingSource.DataSource = voicings;
		//    lbxVoicings.DataSource = _bindingSource;
		//}

		//private void SaveVoicings()
		//{
		//    try {
		//        this.SortVoicings();
		//        var voicings = _bindingSource.DataSource as List<Voicing>;

		//        string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
		//        Utils.XmlSerializeToFile(voicings, filepath);

		//    } catch (Exception ex) {
		//        MessageBox.Show(ex.Message);
		//    }
		//}

		#endregion

		#region Editing

		private void Add()
		{
			Voicing newVoicing = new Voicing();
			_bindingSource.Add(newVoicing);
			_bindingSource.Position = _bindingSource.IndexOf(newVoicing);
			SetEditState(EditState.Adding);
		}

		private void AddCopyFrom()
		{
			Voicing newVoicing = ((Voicing) lbxVoicings.SelectedItem).Clone();
			_bindingSource.Add(newVoicing);
			_bindingSource.Position = _bindingSource.IndexOf(newVoicing);
			SetEditState(EditState.Adding);
		}

		private void Cancel()
		{
			voicingEditor1.Voicing.CopyFrom(_undoVoicing);
			_bindingSource_CurrentChanged(null, null);
			SetEditState(EditState.Normal);
		}

		private void Save()
		{
			if (!ValidateEntries())
				return;

			try {
				_populating = true;
				SortVoicings();
				SetEditState(EditState.Normal);
				SelectVoicing(voicingEditor1.Voicing);
				InvokeNeedSavingEvent();
			} finally {
				_populating = false;
			}
		}

		private bool ValidateEntries()
		{
			if (voicingEditor1.Voicing.NoteIds.Count == 0) {
				MessageBox.Show("You don't have any notes selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void Delete()
		{
			if (_editState != EditState.Normal) {
				MessageBox.Show("Can't reload while editing.");
				return;
			}
			_bindingSource.Remove(_bindingSource.Current);
			InvokeNeedSavingEvent();
		}

		#endregion

		#region UI Events

		void _bindingSource_CurrentChanged(object sender, EventArgs e)
		{
			if (!_populating) {
				Voicing currVoicing = _bindingSource.Current as Voicing;
				if (currVoicing != null) {
					_populating = true;
					_undoVoicing.CopyFrom(currVoicing);
					voicingEditor1.Enabled = true;
					voicingEditor1.Voicing = currVoicing;
					_populating = false;
				} else {
					_populating = true;
					voicingEditor1.Enabled = false;
					_populating = false;
				}
			}
			btnDelete.Enabled = _bindingSource.Current != null;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Add();
		}

		private void btnAddCopy_Click(object sender, EventArgs e)
		{
			AddCopyFrom();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void VoicingEditor1Changed(object sender, EventArgs e)
		{
			if (!_populating)
				if (_editState == EditState.Normal) {
					SetEditState(EditState.Editing);
				}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		#endregion

		#region Methods

		private void SelectVoicing(Voicing voicing)
		{
			lbxVoicings.SelectedIndex = lbxVoicings.Items.IndexOf(voicing);
		}

		private static int CompareVoicings(Voicing x, Voicing y)
		{
			return x.DisplayName.CompareTo(y.DisplayName);
		}

		private void SortVoicings()
		{
			((List<Voicing>) _bindingSource.DataSource).Sort(CompareVoicings);
			_bindingSource.ResetBindings(false);
		}

		public override void SendKeyDown(KeyEventArgs args)
		{
			if (args.Control) {
				if (args.KeyCode == Keys.A) {
					if (btnAdd.Enabled)
						Add();
				} else if (args.Shift && args.KeyCode == Keys.A) {
					if (btnAddCopy.Enabled)
						AddCopyFrom();
				} else if (args.KeyCode == Keys.S) {
					if (btnSave.Enabled)
						Save();
				} else if (args.KeyCode == Keys.D) {
					if (btnDelete.Enabled)
						Delete();
				}
			}
		}

		#endregion

		void voicingEditor1_PlayedChord(object sender, PlayedChordEventArgs e)
		{
			InvokePlayedChordEvent(e);
		}

		private void InvokePlayedChordEvent(PlayedChordEventArgs e)
		{
			if (PlayedChord != null)
				PlayedChord(this, e);
		}

		#region Send Midi Notes

		//public override void NoteDown(NoteOnMessage msg)
		//{
		//	voicingEditor1.NoteDown(msg);
		//}

		//public override void NoteUp(NoteOffMessage msg)
		//{
		//	voicingEditor1.NoteUp(msg);
		//}

		#endregion

		#region Private classes

		private enum EditState
		{
			Normal,
			Editing,
			Adding
		}

		#endregion

		private void button1_Click(object sender, EventArgs e)
		{
			_populating = true;
			Voicing voicing = voicingEditor1.Voicing;

			List<PdNote> notes = new List<PdNote>();
			notes.Add(PdNote.Notes[12]);
			notes.Add(PdNote.Notes[13]); // A
			notes.Add(PdNote.Notes[15]);
			notes.Add(PdNote.Notes[16]);
			notes.Add(PdNote.Notes[0]);
			notes.Add(PdNote.Notes[2]);
			notes.Add(PdNote.Notes[3]);
			notes.Add(PdNote.Notes[5]);
			notes.Add(PdNote.Notes[6]);
			notes.Add(PdNote.Notes[7]);
			notes.Add(PdNote.Notes[8]);
			notes.Add(PdNote.Notes[10]);

			Dictionary<int, Key> keys = new Dictionary<int, Key>();
			keys.Add(0, Key.Ab);
			keys.Add(1, Key.A);
			keys.Add(2, Key.Bb);
			keys.Add(3, Key.B);
			keys.Add(4, Key.C);
			keys.Add(5, Key.Db);
			keys.Add(6, Key.D);
			keys.Add(7, Key.Eb);
			keys.Add(8, Key.E);
			keys.Add(9, Key.F);
			keys.Add(10, Key.Fs);
			keys.Add(11, Key.G);

			Dictionary<int, List<int>> noteOffsets = new Dictionary<int, List<int>>();
			noteOffsets.Add(0, new List<int>{4, 7, 11});
			noteOffsets.Add(1, new List<int>{4, 6, 11});
			noteOffsets.Add(2, new List<int>{3, 5, 10});

			Dictionary<int, int> degreeIntvls = new Dictionary<int, int>();
			degreeIntvls.Add(0, 2);
			degreeIntvls.Add(1, 7);
			degreeIntvls.Add(2, 0);

			Dictionary<int, List<ChordExt>> chordExts = new Dictionary<int, List<ChordExt>>();
			chordExts.Add(0, new List<ChordExt>{new ChordExt(9), new ChordExt(), new ChordExt()});
			chordExts.Add(1, new List<ChordExt>{new ChordExt(13), new ChordExt(9), new ChordExt()});
			chordExts.Add(2, new List<ChordExt>{new ChordExt(9), new ChordExt(6), new ChordExt()});

			Dictionary<int, Quality> qualities = new Dictionary<int, Quality>();
			qualities.Add(0, Quality.Minor7th);
			qualities.Add(1, Quality.Dominant7th);
			qualities.Add(2, Quality.Major);

			const VoicingForm form = VoicingForm.A;
			Voicing initVoicing = new Voicing();
			List<VoicingProgression> progs = new List<VoicingProgression>();

			Dictionary<int, int> lowNoteOffsets = new Dictionary<int, int>{{0, 0}, {1, 0}, {2, -1}};
			int baseLowNoteID = 49;

			_populating = true;
			for (int i = 0; i < 12; i++) {
				VoicingProgression prog = new VoicingProgression();
				prog.VoicingForm = form;
				prog.Key = keys[i];

				for (int j = 0; j < 3; j++) {
					int chordNoteIdx = NoteIndexFromDegreeIntvl(i, degreeIntvls[j]);

					Voicing v = initVoicing.Clone();
					v.Form = form;
					v.Chord.Note.CopyFrom(notes[chordNoteIdx]);
					v.Chord.Quality = qualities[j];
					for (int k = 0; k < 3; k++) {
						v.Chord.ChordExts[0].Accidental = chordExts[j][0].Accidental;
						v.Chord.ChordExts[0].Degree = chordExts[j][0].Degree;
						v.Chord.ChordExts[1].Accidental = chordExts[j][1].Accidental;
						v.Chord.ChordExts[1].Degree = chordExts[j][1].Degree;
						v.Chord.ChordExts[2].Accidental = chordExts[j][2].Accidental;
						v.Chord.ChordExts[2].Degree = chordExts[j][2].Degree;
					}

					v.NoteIds.Clear();
					int lowNote = baseLowNoteID + lowNoteOffsets[j];
					v.NoteIds.Add(lowNote);
					v.NoteIds.Add(lowNote + noteOffsets[j][0]);
					v.NoteIds.Add(lowNote + noteOffsets[j][1]);
					v.NoteIds.Add(lowNote + noteOffsets[j][2]);

					prog.Voicings[j] = v;

					_bindingSource.Add(v);
				}

				progs.Add(prog);
				baseLowNoteID++;

				_bindingSource.ResetBindings(false);
				_populating = false;
				InvokeNeedSavingEvent();
			}

			Utils.XmlSerializeToFile(progs, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Progressions_A.xml"));

			MessageBox.Show("Done.");
		}

		private static int NoteIndexFromDegreeIntvl(int baseIdx, int intvl)
		{
			int idx = baseIdx + intvl;
			if (idx > 11)
				return idx - 12;
			return idx;
		}

		#region Unused

		//private class VoicingsComparer : IComparer<Voicing>
		//{
		//    public int Compare(Voicing x, Voicing y)
		//    {
		//        return x.DisplayName.CompareTo(y.DisplayName);
		//    }
		//}

		//[DllImport("user32.dll")]
		//public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		//private const int WM_SETREDRAW = 11;

		//public static void SuspendDrawing(Control parent)
		//{
		//    SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
		//}

		//public static void ResumeDrawing(Control parent)
		//{
		//    SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
		//    parent.Refresh();
		//}

		#endregion
	}
}