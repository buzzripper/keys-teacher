using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.VoicingTests
{
	public class SystemVoicingLibBuilder : ISystemVoicingLibBuilder
	{
		#region Fields

		private List<PdNote> _notes;
		private int _currNoteIdx;
		private List<int> _bassNoteIds;
		private int _currBassNoteIdx;

		#endregion

		#region Initialization / Finalization

		public SystemVoicingLibBuilder()
		{
			_notes = BuildNoteList();
			_bassNoteIds = BuildBassNoteIdList();
		}

		private List<PdNote> BuildNoteList()
		{
			List<PdNote> notes = new List<PdNote>();
			notes.Add(PdNote.Notes[0]);
			notes.Add(PdNote.Notes[2]);
			notes.Add(PdNote.Notes[3]);
			notes.Add(PdNote.Notes[5]);
			notes.Add(PdNote.Notes[6]);
			notes.Add(PdNote.Notes[7]);
			notes.Add(PdNote.Notes[8]);
			notes.Add(PdNote.Notes[10]);
			notes.Add(PdNote.Notes[12]);
			notes.Add(PdNote.Notes[13]); // A
			notes.Add(PdNote.Notes[15]);
			notes.Add(PdNote.Notes[16]);

			return notes;
		}

		private List<int> BuildBassNoteIdList()
		{
			var bassNoteIds = new List<int>();

			var startNoteId = 34; // Bb

			for (var i = startNoteId; i < (startNoteId + 12); i++)
				bassNoteIds.Add(i);

			return bassNoteIds;
		}

		#endregion

		#region Public Methods

		public List<VoicingLib> BuildAllSystemLibs()
		{
			var systemLibs = new List<VoicingLib>();

			systemLibs.Add(BuildMajorALib());
			systemLibs.Add(BuildMajorBLib());
			systemLibs.Add(BuildMinorALib());
			systemLibs.Add(BuildMinorBLib());

			return systemLibs;
		}

		#endregion

		#region Build Methods

		private VoicingLib BuildMajorALib()
		{
			var voicingLib = new VoicingLib();
			voicingLib.Name = "Major - A Form";

			// I voicings
			_currNoteIdx = 10;
			_currBassNoteIdx = 0;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Major, VoicingForm.A, new[] { 3, 5, 10 }));

			// II voicings
			_currNoteIdx = 0;
			_currBassNoteIdx = 2;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor7th, VoicingForm.A, new[] { 4, 7, 11 }, 51));

			// V voicings
			_currNoteIdx = 5;
			_currBassNoteIdx = 7;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Dominant7th, VoicingForm.A, new[] { 4, 6, 11 }, 51));

			return voicingLib;
		}

		private VoicingLib BuildMajorBLib()
		{
			var voicingLib = new VoicingLib();
			voicingLib.Name = "Major - B Form";

			// I voicings
			_currNoteIdx = 5;
			_currBassNoteIdx = 7;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Major, VoicingForm.B, new[] { 5, 7, 10 }));

			// II voicings
			_currNoteIdx = 7;
			_currBassNoteIdx = 9;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor7th, VoicingForm.B, new[] { 4, 5, 9 }, 53));

			// V voicings
			_currNoteIdx = 0;
			_currBassNoteIdx = 2;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Dominant7th, VoicingForm.B, new[] { 5, 6, 10 }, 52));

			return voicingLib;
		}

		private VoicingLib BuildMinorALib()
		{
			var voicingLib = new VoicingLib();
			voicingLib.Name = "Minor - BAA";

			// I voicings - B
			_currNoteIdx = 5;
			_currBassNoteIdx = 7;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor, VoicingForm.B, new[] { 5, 6, 10 }));

			// II voicings - A
			_currNoteIdx = 8;
			_currBassNoteIdx = 10;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor7th, VoicingForm.A, new[] { 4, 6, 11 }));

			// V voicings - A
			_currNoteIdx = 10;
			_currBassNoteIdx = 0;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Dominant7th, VoicingForm.A, new[] { 4, 6, 11 }));

			return voicingLib;
		}

		private VoicingLib BuildMinorBLib()
		{
			var voicingLib = new VoicingLib();
			voicingLib.Name = "Minor - ABB";

			// I voicings - A
			_currNoteIdx = 11;
			_currBassNoteIdx = 1;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor, VoicingForm.A, new[] { 4, 6, 11 }));

			// II voicings - B
			_currNoteIdx = 2;
			_currBassNoteIdx = 4;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Minor7th, VoicingForm.B, new[] { 5, 6, 10 }));

			// V voicings - B
			_currNoteIdx = 4;
			_currBassNoteIdx = 6;
			voicingLib.Voicings.AddRange(BuildVoicings(Quality.Dominant7th, VoicingForm.B, new[] { 5, 6, 10 }));

			return voicingLib;
		}

		#endregion

		#region Helper Methods

		private List<Voicing> BuildVoicings(Quality voicingQuality, VoicingForm voicingForm, int[] intervals, int startNote = 50)
		{
			var voicings = new List<Voicing>();

			for (int i = 0; i < 12; i++)
			{
				Voicing voicing = new Voicing();
				voicing.Chord.Note = NextNote();
				voicing.Chord.Quality = voicingQuality;
				voicing.Form = voicingForm;

				voicing.BassNoteId = NextBassNoteId();

				voicing.NoteIds.Add(startNote + i);
				for (var j = 0; j < 3; j++)
					voicing.NoteIds.Add(startNote + i + intervals[j]);

				voicings.Add(voicing);
			}
			return voicings;
		}

		private static int NoteIndexFromDegreeIntvl(int baseIdx, int intvl)
		{
			int idx = baseIdx + intvl;
			if (idx > 11)
				return idx - 12;
			return idx;
		}

		private PdNote NextNote()
		{
			var note = _notes[_currNoteIdx];

			if (_currNoteIdx >= (_notes.Count - 1))
				_currNoteIdx = 0;
			else
				_currNoteIdx++;

			return note;
		}

		private int NextBassNoteId()
		{
			var bassNoteId = _bassNoteIds[_currBassNoteIdx];

			if (_currBassNoteIdx >= (_bassNoteIds.Count - 1))
				_currBassNoteIdx = 0;
			else
				_currBassNoteIdx++;

			return bassNoteId;
		}

		#endregion


	}
}
/*
private VoicingLib BuildMajorALib_Old()
{
	var voicingLib = new VoicingLib();
	voicingLib.Name = "Major - A Form";

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

	var bassNoteIds = new Dictionary<PdNote, int>();
	var n = 32;
	foreach (var pdNote in notes)
		bassNoteIds.Add(pdNote, n++);

	//Dictionary<int, Key> keys = new Dictionary<int, Key>();
	//keys.Add(0, Key.Ab);
	//keys.Add(1, Key.A);
	//keys.Add(2, Key.Bb);
	//keys.Add(3, Key.B);
	//keys.Add(4, Key.C);
	//keys.Add(5, Key.Db);
	//keys.Add(6, Key.D);
	//keys.Add(7, Key.Eb);
	//keys.Add(8, Key.E);
	//keys.Add(9, Key.F);
	//keys.Add(10, Key.Fs);
	//keys.Add(11, Key.G);

	Dictionary<int, List<int>> noteOffsets = new Dictionary<int, List<int>>();
	noteOffsets.Add(0, new List<int> { 4, 7, 11 });
	noteOffsets.Add(1, new List<int> { 4, 6, 11 });
	noteOffsets.Add(2, new List<int> { 3, 5, 10 });

	Dictionary<int, int> degreeIntvls = new Dictionary<int, int>();
	degreeIntvls.Add(0, 2);
	degreeIntvls.Add(1, 7);
	degreeIntvls.Add(2, 0);

	Dictionary<int, List<ChordExt>> chordExts = new Dictionary<int, List<ChordExt>>();
	chordExts.Add(0, new List<ChordExt> { new ChordExt(9), new ChordExt(), new ChordExt() });
	chordExts.Add(1, new List<ChordExt> { new ChordExt(13), new ChordExt(9), new ChordExt() });
	chordExts.Add(2, new List<ChordExt> { new ChordExt(9), new ChordExt(6), new ChordExt() });

	Dictionary<int, Quality> qualities = new Dictionary<int, Quality>();
	qualities.Add(0, Quality.Minor7th);
	qualities.Add(1, Quality.Dominant7th);
	qualities.Add(2, Quality.Major);

	const VoicingForm form = VoicingForm.A;

	Dictionary<int, int> lowNoteOffsets = new Dictionary<int, int> { { 0, 0 }, { 1, 0 }, { 2, -1 } };
	int baseLowNoteID = 49;

	for (int i = 0; i < 12; i++) {
		for (int j = 0; j < 3; j++) {
			int chordNoteIdx = NoteIndexFromDegreeIntvl(i, degreeIntvls[j]);
			var note = notes[chordNoteIdx];
			Voicing v = new Voicing();
			v.Form = form;
			v.Chord.Note.CopyFrom(note);
			v.Chord.Quality = qualities[j];
			for (int k = 0; k < 3; k++) {
				v.Chord.ChordExts[k].Accidental = chordExts[j][k].Accidental;
				v.Chord.ChordExts[k].Degree = chordExts[j][k].Degree;
			}

			v.NoteIds.Clear();

			v.BassNoteId = bassNoteIds[note];

			int lowNote = baseLowNoteID + lowNoteOffsets[j];
			v.NoteIds.Add(lowNote);
			v.NoteIds.Add(lowNote + noteOffsets[j][0]);
			v.NoteIds.Add(lowNote + noteOffsets[j][1]);
			v.NoteIds.Add(lowNote + noteOffsets[j][2]);

			voicingLib.Voicings.Add(v);
		}
		baseLowNoteID++;
	}

	return voicingLib;
}

 		private VoicingLib BuildMajorBLib()
		{
			var voicingLib = new VoicingLib();
			voicingLib.Name = "Major - B Form";

			List<PdNote> notes = new List<PdNote>();
			notes.Add(PdNote.Notes[5]);
			notes.Add(PdNote.Notes[6]);
			notes.Add(PdNote.Notes[7]);
			notes.Add(PdNote.Notes[8]);
			notes.Add(PdNote.Notes[10]);
			notes.Add(PdNote.Notes[12]);
			notes.Add(PdNote.Notes[13]); // A
			notes.Add(PdNote.Notes[15]);
			notes.Add(PdNote.Notes[16]);
			notes.Add(PdNote.Notes[0]);
			notes.Add(PdNote.Notes[2]);
			notes.Add(PdNote.Notes[3]);

			var bassNoteIds = new Dictionary<PdNote, int>();
			var n = 27;
			foreach (var pdNote in notes)
				bassNoteIds.Add(pdNote, n++);

			//Dictionary<int, Key> keys = new Dictionary<int, Key>();
			//keys.Add(0, Key.Ab);
			//keys.Add(1, Key.A);
			//keys.Add(2, Key.Bb);
			//keys.Add(3, Key.B);
			//keys.Add(4, Key.C);
			//keys.Add(5, Key.Db);
			//keys.Add(6, Key.D);
			//keys.Add(7, Key.Eb);
			//keys.Add(8, Key.E);
			//keys.Add(9, Key.F);
			//keys.Add(10, Key.Fs);
			//keys.Add(11, Key.G);

			Dictionary<int, List<int>> noteOffsets = new Dictionary<int, List<int>>();
			noteOffsets.Add(0, new List<int> { 4, 5, 9 });
			noteOffsets.Add(1, new List<int> { 5, 6, 10 });
			noteOffsets.Add(2, new List<int> { 5, 7, 10 });

			Dictionary<int, int> degreeIntvls = new Dictionary<int, int>();
			degreeIntvls.Add(0, 2);
			degreeIntvls.Add(1, 7);
			degreeIntvls.Add(2, 0);

			Dictionary<int, List<ChordExt>> chordExts = new Dictionary<int, List<ChordExt>>();
			chordExts.Add(0, new List<ChordExt> { new ChordExt(9), new ChordExt(), new ChordExt() });
			chordExts.Add(1, new List<ChordExt> { new ChordExt(13), new ChordExt(9), new ChordExt() });
			chordExts.Add(2, new List<ChordExt> { new ChordExt(9), new ChordExt(6), new ChordExt() });

			Dictionary<int, Quality> qualities = new Dictionary<int, Quality>();
			qualities.Add(0, Quality.Minor7th);
			qualities.Add(1, Quality.Major);
			qualities.Add(2, Quality.Major);

			const VoicingForm form = VoicingForm.B;

			Voicing initVoicing = new Voicing();

			Dictionary<int, int> lowNoteOffsets = new Dictionary<int, int> { { 0, 0 }, { 1, -1 }, { 2, -3 } };
			int baseLowNoteID = 51;

			for (int i = 0; i < 12; i++)
			{
				VoicingProgression prog = new VoicingProgression();
				prog.VoicingForm = form;
				//prog.Key = keys[i];

				for (int j = 0; j < 3; j++)
				{
					int chordNoteIdx = NoteIndexFromDegreeIntvl(i, degreeIntvls[j]);
					var note = notes[chordNoteIdx];

					Voicing v = initVoicing.Clone();
					v.Form = form;
					v.Chord.Note.CopyFrom(note);
					v.Chord.Quality = qualities[j];
					for (int k = 0; k < 3; k++)
					{
						v.Chord.ChordExts[k].Accidental = chordExts[j][k].Accidental;
						v.Chord.ChordExts[k].Degree = chordExts[j][k].Degree;
					}

					v.NoteIds.Clear();

					v.BassNoteId = bassNoteIds[note];

					int lowNote = baseLowNoteID + lowNoteOffsets[j];
					v.NoteIds.Add(lowNote);
					v.NoteIds.Add(lowNote + noteOffsets[j][0]);
					v.NoteIds.Add(lowNote + noteOffsets[j][1]);
					v.NoteIds.Add(lowNote + noteOffsets[j][2]);

					voicingLib.Voicings.Add(v);
				}
				baseLowNoteID++;
			}

			return voicingLib;
		}

*/
