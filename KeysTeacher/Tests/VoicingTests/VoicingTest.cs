using System;
using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.VoicingLibs
{
	[Serializable]
	public class VoicingTest
	{
		#region Ctor

		public VoicingTest()
		{
			this.Voicings = new List<Voicing>();
		}

		public VoicingTest(int id) : this()
		{
			this.Id = id;
		}

		#endregion

		#region Properties

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ExamDurationSecs { get; set; }
		public int QuestionDurationSecs { get; set; }
		public bool InclBassNote { get; set; }
		public List<Voicing> Voicings { get; set; }

		#endregion

		public override string ToString()
		{
			return this.Name;
		}

		public VoicingTest Clone()
        {
			var newVoicingTest = new VoicingTest();

			newVoicingTest.Id = 0;
			newVoicingTest.Name = this.Name;
			newVoicingTest.InclBassNote = this.InclBassNote;
			newVoicingTest.Description = this.Description;
			newVoicingTest.QuestionDurationSecs = this.QuestionDurationSecs;	
			newVoicingTest.ExamDurationSecs = this.ExamDurationSecs;

			foreach (var voicing in this.Voicings)
				newVoicingTest.Voicings.Add(voicing);

			return newVoicingTest;
		}
	}
}