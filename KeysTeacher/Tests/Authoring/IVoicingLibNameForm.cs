using System.Windows.Forms;

namespace KeysTeacher.Tests.Authoring
{
	public interface IVoicingLibNameForm
	{
		string LibName { get; }

		DialogResult Run(string name);
	}
}