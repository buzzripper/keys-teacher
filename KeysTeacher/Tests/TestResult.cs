using System;
using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests
{
	[Serializable]
	public class TestResult
	{
		#region Initialization / Finalization

		public TestResult()
		{
			this.WrongAnswerVoicings = new List<Voicing>();
		}
		
		#endregion

		#region Properties

		public int TestId { get; set; }
		public string TestName { get; set; }
		public DateTime StartTime { get; set; }
		public int TotalDurationSecs { get; set; }
		public int TotalQuestions { get; set; }
		public int TotalCorrect { get; set; }
		public List<Voicing> WrongAnswerVoicings { get; private set; }

		public decimal Score
		{
			get
			{
				if (this.TotalQuestions > 0)
					return this.TotalCorrect / (decimal) this.TotalQuestions;
				return -1;
			}
		}

		public bool AddWrongAnswersToErrorsTest { get; set; }
		
		#endregion
	}
}