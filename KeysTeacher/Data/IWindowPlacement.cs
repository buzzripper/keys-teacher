using System;
using System.Xml;

namespace KeysTeacher.Data
{
	public interface IWindowPlacement
	{
		void SetPlacement(IntPtr windowHandle, XmlCDataSection cDataSection);
		XmlCDataSection GetPlacementData(IntPtr windowHandle);
	}
}
