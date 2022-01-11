using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysTeacher
{
	[Serializable]
	public enum Key
	{
		C,
		G,
		D,
		A,
		E,
		B,
		Fs,
		Db,
		Ab,
		Eb,
		Bb,
		F,
		Am,
		Em,
		Bm,
		Fsm,
		Csm,
		Gsm,
		Ebm,
		Bbm,
		Fm,
		Cm,
		Gm,
		Dm
	}

	public static class KeyExt
	{
		#region Static

		public static List<Key> GetMajors()
		{
			return new List<Key>((Key[]) Enum.GetValues(typeof(Key))).Take(12).ToList();
		}

		public static List<Key> GetMinors()
		{
			return new List<Key>((Key[]) Enum.GetValues(typeof(Key))).Skip(12).ToList();
		}

		#endregion

		#region Extension methods

		public static string Name(this Key key)
		{
			return key.ToString().Replace("s", "#");
		}

		public static Quality GetQuality(this Key key)
		{
			return key.ToString().Contains("m") ? Quality.Minor : Quality.Major;
		}

		#endregion
	}
}