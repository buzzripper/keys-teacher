using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher
{
	public class ProgressionsBuilder
	{
		public List<VoicingProgression> BuildProgressions()
		{
			List<VoicingProgression> progressions = new List<VoicingProgression>();

			progressions.AddRange(GenMajorAProgressions());
			progressions.AddRange(GenMajorBProgressions());

			return progressions;
		}

		#region A Form

		private static IEnumerable<VoicingProgression> GenMajorAProgressions()
		{
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
				}

				progs.Add(prog);
				baseLowNoteID++;
			}
			//Utils.XmlSerializeToFile(progs, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Progressions_A.xml"));

			return progs;
		}

		#endregion

		#region B Form

		private static IEnumerable<VoicingProgression> GenMajorBProgressions()
		{
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

			Dictionary<int, Key> keys = new Dictionary<int, Key>();
			keys.Add(0, Key.Eb);
			keys.Add(1, Key.E);
			keys.Add(2, Key.F);
			keys.Add(3, Key.Fs);
			keys.Add(4, Key.G);
			keys.Add(5, Key.Ab);
			keys.Add(6, Key.A);
			keys.Add(7, Key.Bb);
			keys.Add(8, Key.B);
			keys.Add(9, Key.C);
			keys.Add(10, Key.Db);
			keys.Add(11, Key.D);

			Dictionary<int, List<int>> noteOffsets = new Dictionary<int, List<int>>();
			noteOffsets.Add(0, new List<int>{4, 5, 9});
			noteOffsets.Add(1, new List<int>{5, 6, 10});
			noteOffsets.Add(2, new List<int>{5, 7, 10});

			Dictionary<int, int> degreeIntvls = new Dictionary<int, int>();
			degreeIntvls.Add(0, 2);
			degreeIntvls.Add(1, 7);
			degreeIntvls.Add(2, 0);

			Dictionary<int, List<ChordExt>> chordExts = new Dictionary<int, List<ChordExt>>();
			chordExts.Add(0, new List<ChordExt>{new ChordExt(), new ChordExt(), new ChordExt()});
			chordExts.Add(1, new List<ChordExt>{new ChordExt(6), new ChordExt(), new ChordExt()});
			chordExts.Add(2, new List<ChordExt>{new ChordExt(6), new ChordExt(), new ChordExt()});

			Dictionary<int, Quality> qualities = new Dictionary<int, Quality>();
			qualities.Add(0, Quality.Minor7th);
			qualities.Add(1, Quality.Major);
			qualities.Add(2, Quality.Major);

			const VoicingForm form = VoicingForm.B;

			Voicing initVoicing = new Voicing();
			List<VoicingProgression> progs = new List<VoicingProgression>();

			Dictionary<int, int> lowNoteOffsets = new Dictionary<int, int>{{0, 0}, {1, -1}, {2, -3}};
			int baseLowNoteID = 51;

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
						v.Chord.ChordExts[0].Accidental = chordExts[j][k].Accidental;
						v.Chord.ChordExts[0].Degree = chordExts[j][k].Degree;
					}

					v.NoteIds.Clear();
					int lowNote = baseLowNoteID + lowNoteOffsets[j];
					v.NoteIds.Add(lowNote);
					v.NoteIds.Add(lowNote + noteOffsets[j][0]);
					v.NoteIds.Add(lowNote + noteOffsets[j][1]);
					v.NoteIds.Add(lowNote + noteOffsets[j][2]);

					prog.Voicings[j] = v;
				}

				progs.Add(prog);
				baseLowNoteID++;
			}
			//Utils.XmlSerializeToFile(progs, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Progressions_A.xml"));

			return progs;
		}

		#endregion

		private static int NoteIndexFromDegreeIntvl(int baseIdx, int intvl)
		{
			int idx = baseIdx + intvl;
			if (idx > 11)
				return idx - 12;
			return idx;
		}
	}
}