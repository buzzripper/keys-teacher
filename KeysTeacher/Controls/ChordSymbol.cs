using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class ChordSymbol : UserControl
	{
		#region Fields

		private PdChord _chord;
		private readonly Dictionary<Quality, Bitmap> _qualityImgs = new Dictionary<Quality, Bitmap>();
		private readonly List<Label> _extLabels = new List<Label>();

		#endregion

		#region Constructors

		public ChordSymbol()
		{
			InitializeComponent();

			_extLabels.Add(lblExt1);
			_extLabels.Add(lblExt2);
			_extLabels.Add(lblExt3);

			if (!this.DesignMode) {
				// Get a reference to the current assembly
				Assembly assy = Assembly.GetExecutingAssembly();

				string imgsFolder = "KeysTeacher.Images";

				// Qualities
				List<Quality> qualities = new List<Quality>((Quality[]) Enum.GetValues(typeof(Quality)));
				foreach (Quality quality in qualities) {
					string resName = string.Format("{0}.Quality.{1}.gif", imgsFolder, quality);
					Bitmap bmp = Utils.GetBmpFromResource(assy, resName);
					_qualityImgs.Add(quality, bmp);
				}
			}
		}

		#endregion

		#region Properties

		public PdChord Chord
		{
			get { return _chord; }
			set
			{
				_chord = value;
				if (_chord != null)
					_chord.PropertyChanged += ChordPropertyChanged;
				Populate();
			}
		}

		#endregion

		#region Populate

		private void Populate()
		{
			if (_chord == null)
				return;

			noteSymbol1.Note = _chord.Note;
			picQuality.Image = _qualityImgs[_chord.Quality];

			lbl7th.Visible = _chord.Quality == Quality.Dominant7th || _chord.Quality == Quality.Major7th
			                 || _chord.Quality == Quality.Minor7th;

			// Extensions
			int idx = 0;
			foreach (ChordExt chordExt in _chord.ChordExts) {
				if (chordExt.Degree > 0) {
					_extLabels[idx].Text = chordExt.ToString();
					idx++;
				}
			}

			for (int i = 0; i < _extLabels.Count; i++) {
				_extLabels[i].Visible = i < idx;
				switch (idx) {
					case 1:
						_extLabels[0].Top = 18;
						break;
					case 2:
						_extLabels[0].Top = 5;
						_extLabels[1].Top = 30;
						break;
					default:
						_extLabels[0].Top = -4;
						_extLabels[1].Top = 18;
						break;
				}
			}

			picLParen.Visible = idx > 0;
			picRParen.Visible = idx > 0;

			// Bass note
			nsmBass.Note = _chord.BassNote;
			nsmBass.Visible = _chord.BassNote != null;
			picBassSlash.Visible = _chord.BassNote != null;
		}

		#endregion

		private void ChordPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Populate();
		}

		private void ChordSymbol_Load(object sender, EventArgs e)
		{}

        private void picRParen_Click(object sender, EventArgs e)
        {

        }

        public void Redraw()
        {
			//Populate();
		}
	}
}