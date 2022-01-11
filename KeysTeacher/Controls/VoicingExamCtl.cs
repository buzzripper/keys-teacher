using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KeysTeacher.Music;

namespace KeysTeacher
{
	public partial class VoicingExamCtl : UserControl
	{
		#region Events

		public event EventHandler OnPlayVoicingClick;

		#endregion

		#region Fields

		#endregion

		#region Constructors / Initialization / Finalization

		public VoicingExamCtl()
		{
			InitializeComponent();
		}

		private void VoicingExamCtl_Load(object sender, EventArgs e)
		{
			if (!DesignMode) {
				this.ResultPics = new Bitmap[2];
				try {
					this.ResultPics[0] = Utils.GetBmpFromResource(string.Format("{0}.correct_32.png", Globals.ImgsRoot));
					this.ResultPics[1] = Utils.GetBmpFromResource(string.Format("{0}.wrong_32.png", Globals.ImgsRoot));
				} catch (Exception ex) {
					throw new Exception(ex.ToString());
				}
			}
		}

		#endregion

		#region Properties

		private Bitmap[] ResultPics { get; set; }

		public bool PlayButtonEnabled
		{
			get { return btnPlayVoicing.Enabled; }
			set { btnPlayVoicing.Enabled = value; }
		}

		public bool SymbolVisible
		{
			get { return chordSymbol1.Visible; }
			set { chordSymbol1.Visible = value; }
		}

		#endregion

		public void SetVoicing(Voicing voicing)
		{
			chordSymbol1.Chord = voicing.Chord;
			picResult.Image = null;
			btnPlayVoicing.Enabled = false;
			pianoControl1.ReleaseAllPianoKeys();
		}

		public void SetDegree(int degree)
		{
			switch (degree) {
				case 2:
					lblDegree.Text = "II";
					break;
				case 5:
					lblDegree.Text = "V";
					break;
				default:
					lblDegree.Text = "I";
					break;
			}
		}

		public void SetNoteIDs(List<int> noteIDs)
		{
			pianoControl1.ReleaseAllPianoKeys();
			foreach (int noteId in noteIDs) {
				pianoControl1.PressPianoKey(noteId);
			}
		}

		private void btnPlayVoicing_Click(object sender, EventArgs e)
		{
			if (OnPlayVoicingClick != null)
				OnPlayVoicingClick(this, new EventArgs());
		}

		public void SetResult(AnswerResult result)
		{
			switch (result) {
				case AnswerResult.Correct:
					picResult.Image = ResultPics[0];
					break;
				case AnswerResult.Wrong:
					picResult.Image = ResultPics[1];
					break;
				default:
					picResult.Image = null;
					break;
			}
			btnPlayVoicing.Visible = true;
		}

		public void PressPianoKey(int noteID)
		{
			pianoControl1.PressPianoKey(noteID);
		}
	}

	public enum AnswerResult
	{
		None,
		Correct,
		Wrong
	}
}