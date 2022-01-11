using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class NoteSymbol : UserControl
	{
		#region Constants

		#endregion

		#region Fields

		private readonly Dictionary<Accidental, Bitmap> _accidentalImgs = new Dictionary<Accidental, Bitmap>();
		private PdNote _note;

		#endregion

		public NoteSymbol()
		{
			InitializeComponent();

			if (!this.DesignMode) {
				Assembly assy = Assembly.GetExecutingAssembly();

				// Accidentals
				List<Accidental> accidentals = new List<Accidental>((Accidental[]) Enum.GetValues(typeof(Accidental)));
				foreach (Accidental accidental in accidentals) {
					string resName = string.Format("{0}.AccidentalSm.{1}.gif", Globals.ImgsRoot, accidental);
					Bitmap bmp = Utils.GetBmpFromResource(assy, resName);
					_accidentalImgs.Add(accidental, bmp);
				}
			}
		}

		public PdNote Note
		{
			get { return _note; }
			set
			{
				_note = value;
				if (value != null) {
					lblLetter.Text = value.Letter;
					picAccidental.Image = _accidentalImgs[value.Accidental];
				}
			}
		}

		private void NoteSymbol_EnabledChanged(object sender, EventArgs e)
		{
			lblLetter.Text = "C";
			picAccidental.Image = _accidentalImgs[Accidental.Natural];
		}
	}
}