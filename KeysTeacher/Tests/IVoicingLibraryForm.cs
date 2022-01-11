using System;
using System.Collections.Generic;
using KeysTeacher.Music;

namespace KeysTeacher.Tests
{
	public interface IVoicingLibraryForm
	{
		event EventHandler<SelectVoicingsArgs> VoicingsSelected;

		void Show();
		void Hide();
		bool Visible { get; set; }

		int Top { get; set; }
		int Left { get; set; }
		int Width { get; set; }
		int Height { get; set; }

		void Show(int left, int top, int height);
		void Reset(List<Voicing> voicings);
	}
}