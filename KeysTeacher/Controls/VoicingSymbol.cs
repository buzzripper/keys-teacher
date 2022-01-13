using System.Windows.Forms;
using KeysTeacher.Music;

namespace KeysTeacher
{
	public partial class VoicingSymbol : UserControl
	{
		#region Fields

		private Voicing _voicing;

		#endregion

		public VoicingSymbol()
		{
			InitializeComponent();
		}

		public Voicing Voicing
		{
			get { return _voicing; }
			set
			{
				_voicing = value;
				if (_voicing != null)
					Populate();
			}
		}

		private void Populate()
		{
			chordSymbol1.Chord = this.Voicing.Chord;
			lblForm.Text = $"{this.Voicing.Form} Form";
		}

        private void lblForm_Click(object sender, System.EventArgs e)
        {

        }
    }
}