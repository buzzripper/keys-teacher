﻿using System;
using System.Collections.Generic;

namespace KeysTeacher.Music
{
	[Serializable]
	public class VoicingLib
	{
		#region Initialization / Finalization

		public VoicingLib()
		{
			this.Voicings = new List<Voicing>();
		}

		#endregion

		#region Properties

		public string Name { get; set; }
		public List<Voicing> Voicings { get; private set; }

		#endregion

		public override string ToString()
		{
			return Name;
		}
	}
}