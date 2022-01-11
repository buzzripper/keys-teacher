using System;

namespace KeysTeacher
{
	[Serializable]
	public class TestBase
	{
		#region Properties

		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int ExamDurationSecs { get; set; }

		public int QuestionDurationSecs { get; set; }

		#endregion
	}
}