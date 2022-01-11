using KeysTeacher.Music;

namespace KeysTeacher.Tests.Authoring
{
	public interface IVoicingEditorForm
	{
		bool Run(Voicing voicing);
		Voicing Voicing { get; }
	}
}