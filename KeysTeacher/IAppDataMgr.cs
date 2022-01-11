using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysTeacher
{
	public interface IAppDataMgr
	{
		AppData AppData { get; }

		void Load();
		void Save();
	}
}
