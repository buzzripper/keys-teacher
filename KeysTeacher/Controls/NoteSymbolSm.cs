using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class NoteSymbolSm : UserControl
	{
		#region Fields

		private PdNote _note;

		#endregion

		public NoteSymbolSm()
		{
			InitializeComponent();
		}

		public PdNote Note
		{
			get { return _note; }
			set
			{
				_note = value;
				if (value != null) {
					lblNote.Text = value.ToString();
				}
			}
		}
	}
}