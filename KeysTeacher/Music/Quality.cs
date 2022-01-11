using System;

namespace KeysTeacher
{
	[Serializable]
	public enum Quality
	{
		Major = 0x1,
		Minor = 0x2,
		Diminished = 0x4,
		Augmented = 0x8,
		Minor7th = 0x10,
		Major7th = 0x20,
		Dominant7th = 0x40
	}
}