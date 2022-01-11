using System.Windows.Forms;

namespace KeysTeacher.Misc
{
	public interface IMsgBox
	{
		DialogResult ShowError(string caption, string message = null);
	}
}
