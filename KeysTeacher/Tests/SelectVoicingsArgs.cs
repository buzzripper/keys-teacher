using System;
using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests
{
	public class SelectVoicingsArgs : EventArgs
	{
		#region Constructors

		public SelectVoicingsArgs(List<Voicing> voicings)
		{
			this.Voicings = voicings;
		}

		#endregion

		#region Properties

		public List<Voicing> Voicings { get; private set; }

		#endregion
	}
}
