using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeysTeacher.Controls
{
	public partial class PianoControl
	{
		private class PianoKey : Control
		{
			#region Constants

			#endregion

			#region Fields

			private readonly Controls.PianoControl _owner;
			private SolidBrush _onBrush;
			private readonly SolidBrush _normalOnBrush = new SolidBrush(Color.SkyBlue);
			private readonly SolidBrush _bassNoteOnBrush = new SolidBrush(Color.LightSteelBlue);
			private readonly SolidBrush _offBrush = new SolidBrush(Color.White);
			private int _noteID = 60;
			private bool _isBassNote;

			#endregion

			#region Constructors / Initialization / Finalization

			public PianoKey(Controls.PianoControl owner)
			{
				_owner = owner;
				this.TabStop = false;
				_onBrush = _normalOnBrush;
			}

			#endregion

			#region Properties

			private bool StickyKeys => _owner.StickyKeys;
			public bool IsPressed { get; private set; }

			public bool IsBassNote
			{
				get { return _isBassNote; }
				set {
					if (value != _isBassNote) {
						_isBassNote = value;
						_onBrush = _isBassNote ? _bassNoteOnBrush : _onBrush;
					}
				}
			}

			#endregion

			public void Press()
			{
				#region Guard

				if (this.IsPressed) {
					return;
				}

				#endregion

				this.IsPressed = true;
				Invalidate();
				if (!this.IsBassNote)
					_owner.OnPianoKeyDown(new PianoKeyEventArgs(_noteID));
				else
					_owner.OnBassKeyDown(new PianoKeyEventArgs(_noteID));
			}

			public void Release()
			{
				#region Guard

				if (!this.IsPressed) {
					return;
				}

				#endregion

				this.IsPressed = false;
				Invalidate();

				if (!this.IsBassNote)
					_owner.OnPianoKeyUp(new PianoKeyEventArgs(_noteID));
				else
					_owner.OnBassKeyUp(new PianoKeyEventArgs(_noteID));
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing) {
					_normalOnBrush.Dispose();
					_bassNoteOnBrush.Dispose();
					_onBrush.Dispose();
					_offBrush.Dispose();
				}

				base.Dispose(disposing);
			}

			protected override void OnMouseEnter(EventArgs e)
			{
				if (MouseButtons == MouseButtons.Left) {
					Press();
				}
				base.OnMouseEnter(e);
			}

			protected override void OnMouseLeave(EventArgs e)
			{
				if (MouseButtons == MouseButtons.Left) {
					if (this.IsPressed)
						Release();
				}
				base.OnMouseLeave(e);
			}

			protected override void OnMouseDown(MouseEventArgs e)
			{
				if (this.StickyKeys) {
					if (!this.IsPressed)
						this.IsBassNote = e.Button == MouseButtons.Right;
					Toggle();
				}
				else {
					Press();
					if (!_owner.Focused)
						_owner.Focus();
				}

				base.OnMouseDown(e);
			}

			protected override void OnMouseUp(MouseEventArgs e)
			{
				if (!this.StickyKeys)
					Release();

				base.OnMouseUp(e);
			}

			protected override void OnMouseMove(MouseEventArgs e)
			{
				if (e.X < 0 || e.X > this.Width || e.Y < 0 || e.Y > this.Height) {
					this.Capture = false;
				}

				base.OnMouseMove(e);
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				if (this.IsPressed) {
					e.Graphics.FillRectangle(_onBrush, 0, 0, this.Size.Width, this.Size.Height);
				}
				else {
					e.Graphics.FillRectangle(_offBrush, 0, 0, this.Size.Width, this.Size.Height);
				}

				e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Size.Width - 1, this.Size.Height - 1);

				base.OnPaint(e);
			}

			public void SetNoteOnColor(Color color)
			{
				_normalOnBrush.Color = color;

				if (this.IsPressed && !this.IsBassNote)
					Invalidate();
			}

			public void SetBassNoteOnColor(Color color)
			{
				_bassNoteOnBrush.Color = color;

				if (this.IsPressed && this.IsBassNote) {
					Invalidate();
				}
			}

			public void SetNoteOffColor(Color color)
			{
				_offBrush.Color = color;

				if (!this.IsPressed)
					Invalidate();
			}

			public int NoteID
			{
				get { return _noteID; }
				set {
					#region Require

					if (value < 0 || value > Globals.DataMaxValue) {
						throw new ArgumentOutOfRangeException("NoteID", _noteID, "Note ID out of range.");
					}

					#endregion

					_noteID = value;
				}
			}

			public void Toggle()
			{
				if (this.IsPressed)
					Release();
				else
					Press();
			}
		}
	}
}