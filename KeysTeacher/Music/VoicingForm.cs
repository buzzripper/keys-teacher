using System;

namespace KeysTeacher
{
	[Serializable]
	public enum VoicingForm
	{
		None = 0,
		A = 0x1,
		B = 0x2,
		Open = 0x4,
		BBA = 0x8,
		AAB = 0x10
	}
}