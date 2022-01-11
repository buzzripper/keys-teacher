using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class KeySymbol : UserControl
	{
		#region Fields

		private readonly Dictionary<Accidental, Bitmap> _accImgs = new Dictionary<Accidental, Bitmap>();

		#endregion

		#region Constructors

		public KeySymbol()
		{
			InitializeComponent();

			if (!this.DesignMode) {
				List<Accidental> accidentals = new List<Accidental>((Accidental[]) Enum.GetValues(typeof(Accidental)));
				foreach (Accidental accidental in accidentals) {
					string resName = string.Format("{0}.Accidental.{1}.gif", Globals.ImgsRoot, accidental);
					Bitmap bmp = Utils.GetBmpFromResource(Assembly.GetExecutingAssembly(), resName);
					_accImgs.Add(accidental, bmp);
				}
			}
		}

		#endregion

		#region Populate

		public void SetKey(Key key)
		{
			string keyStr = key.ToString();
			lblLetter.Text = keyStr.Substring(0, 1);
			picMinor.Visible = keyStr.IndexOf("m") > 0;
			if (keyStr.IndexOf("s") > 0)
				picAccidental.Image = _accImgs[Accidental.Sharp];
			else if (keyStr.IndexOf("b") > 0)
				picAccidental.Image = _accImgs[Accidental.Flat];
			else
				picAccidental.Image = _accImgs[Accidental.Natural];
		}

		#endregion
	}
}