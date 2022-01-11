using System;
using System.Windows.Forms;

namespace KeysTeacher.HomeControls
{
	public interface IHomeControlBase
	{
		event EventHandler NeedSaving;

		bool IsActive { get; }
		DockStyle Dock { get; set; }
		bool Visible { get; set; }

		void Activate();
		void Deactivate();
		void SendKeyDown(KeyEventArgs e);
	}
}