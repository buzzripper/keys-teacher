using System;

namespace KeysTeacher
{
	[Serializable]
	public class ProgTest : TestBase
	{
		#region Static

		public static ProgTest CreateTest(int newId)
		{
			return new ProgTest{
				       Id = newId,
				       Name = "New Progression Test",
				       ExamDurationSecs = 300,
				       QuestionDurationSecs = 20,
				       IncludeAForm = true,
				       IncludeBForm = true,
				       IncludeOpenForm = true,
				       IncludeAABForm = true,
				       IncludeBBAForm = true
			       };
		}

		#endregion

		#region Properties

		public bool IncludeMajor { get; set; }

		public bool IncludeMinor { get; set; }

		public bool IncludeAForm { get; set; }

		public bool IncludeBForm { get; set; }

		public bool IncludeOpenForm { get; set; }

		public bool IncludeAABForm { get; set; }

		public bool IncludeBBAForm { get; set; }

		#endregion
	}
}