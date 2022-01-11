using System.Windows.Forms;

namespace KeysTeacher.Misc
{
	public class MsgBox : IMsgBox
	{
		public DialogResult ShowError(string message, string caption = null)
		{
			return MessageBox.Show(message, caption ?? "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}