using System;
using System.Runtime.Serialization;

namespace KeysTeacher
{
	[Serializable]
	public enum Accidental
	{
		[EnumMember]
		Natural,

		[EnumMember]
		Flat,

		[EnumMember]
		Sharp
	}
}