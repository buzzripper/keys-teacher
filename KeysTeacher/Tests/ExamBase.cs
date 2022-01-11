using System;

namespace KeysTeacher
{
	[Serializable]
	public class ExamBase
	{
		#region Properties

		public int QuestionDurationSecs { get; set; }

		public int TestDurationSecs { get; set; }

		#endregion
	}
}