using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests.VoicingTests
{
	public interface ISystemVoicingLibBuilder
	{
		List<VoicingLib> BuildAllSystemLibs();
	}
}