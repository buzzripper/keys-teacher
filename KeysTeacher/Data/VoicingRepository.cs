using System;
using System.Collections.Generic;
using KeysTeacher.Music;
using KeysTeacher.Tests.VoicingLibs;
using KeysTeacher.Tests.VoicingTests;

namespace KeysTeacher.Data
{
	public class VoicingRepository : IVoicingRepository
	{
		#region Fields

		//private readonly List<Voicing> _allVoicings;

		#endregion

		#region Ctor

		public VoicingRepository()
		{
			//_allVoicings = new VoicingsBuilder().BuildVoicings();
			//_allVoicings.Sort((v1, v2) => String.Compare(v1.ToString(), v2.ToString(), StringComparison.Ordinal));
		}

		#endregion

		//public List<Voicing> GetAllVoicings()
		//{
		//	return _allVoicings;
		//}
	}
}