using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KeysTeacher.Controls
{
	public partial class PianoControl : Control
	{
		private enum KeyType
		{
			White,
			Black
		}

		#region Events

		public event EventHandler<PianoKeyEventArgs> PianoKeyDown;
		public event EventHandler<PianoKeyEventArgs> PianoKeyUp;
		public event EventHandler<PianoKeyEventArgs> BassKeyDown;
		public event EventHandler<PianoKeyEventArgs> BassKeyUp;

		#endregion

		#region Static

		private static readonly Hashtable _keyTable;
		private static readonly KeyType[] _keyTypeTable;

		static PianoControl()
		{
			_keyTable = CreateKeyTable();
			_keyTypeTable = CreateKeyTypeTable();
		}

		private static Hashtable CreateKeyTable()
		{
			Hashtable keyTable = new Hashtable();

			keyTable.Add(Keys.A, 0);
			keyTable.Add(Keys.W, 1);
			keyTable.Add(Keys.S, 2);
			keyTable.Add(Keys.E, 3);
			keyTable.Add(Keys.D, 4);
			keyTable.Add(Keys.F, 5);
			keyTable.Add(Keys.T, 6);
			keyTable.Add(Keys.G, 7);
			keyTable.Add(Keys.Y, 8);
			keyTable.Add(Keys.H, 9);
			keyTable.Add(Keys.U, 10);
			keyTable.Add(Keys.J, 11);
			keyTable.Add(Keys.K, 12);
			keyTable.Add(Keys.O, 13);
			keyTable.Add(Keys.L, 14);
			keyTable.Add(Keys.P, 15);

			return keyTable;
		}

		private static KeyType[] CreateKeyTypeTable()
		{
			return new[] {
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White,
				       KeyType.White, KeyType.Black, KeyType.White, KeyType.Black, KeyType.White, KeyType.White, KeyType.Black, KeyType.White
			       };
		}
		
		#endregion

		#region Fields

		private const int DefaultLowNoteID = 21;
		private const int DefaultHighNoteID = 109;
		private const double BlackKeyScale = 0.666666666;
		private int lowNoteID = DefaultLowNoteID;
		private int highNoteID = DefaultHighNoteID;
		private int octaveOffset = 5;
		private Color noteOnColor = Color.SkyBlue;
		private Color _bassNoteOnColor = Color.LightSteelBlue;
		private PianoKey[] _keys;
		private int whiteKeyCount;
		
		#endregion

		#region Initialization / Finalization

		public PianoControl()
		{
			CreatePianoKeys();
			InitializePianoKeys();

			this.PressedKeyIDs = new List<int>();
		}

		private void CreatePianoKeys()
		{
			// If piano keys have already been created.
			if (_keys != null) {
				// Remove and dispose of current piano keys.
				foreach (PianoKey key in _keys) {
					this.Controls.Remove(key);
					key.Dispose();
				}
			}

			_keys = new PianoKey[this.HighNoteID - this.LowNoteID];

			whiteKeyCount = 0;

			for (int i = 0; i < _keys.Length; i++) {
				_keys[i] = new PianoKey(this) {
					           NoteID = i + this.LowNoteID
				           };

				if (_keyTypeTable[_keys[i].NoteID] == KeyType.White) {
					whiteKeyCount++;
				}
				else {
					_keys[i].SetNoteOffColor(Color.Black);
					_keys[i].BringToFront();
				}

				_keys[i].SetNoteOnColor(this.NoteOnColor);
				_keys[i].SetBassNoteOnColor(this.BassNoteOnColor);

				this.Controls.Add(_keys[i]);
			}
		}

		private void InitializePianoKeys()
		{
			#region Guard

			if (_keys.Length == 0) {
				return;
			}

			#endregion

			int whiteKeyWidth = this.Width / whiteKeyCount;
			int blackKeyWidth = (int)(whiteKeyWidth * BlackKeyScale);
			int blackKeyHeight = (int)(this.Height * BlackKeyScale);
			int offset = whiteKeyWidth - blackKeyWidth / 2;
			int n = 0;
			int w = 0;

			while (n < _keys.Length) {
				if (_keyTypeTable[_keys[n].NoteID] == KeyType.White) {
					_keys[n].Height = this.Height;
					_keys[n].Width = whiteKeyWidth;
					_keys[n].Location = new Point(w * whiteKeyWidth, 0);
					w++;
					n++;
				}
				else {
					_keys[n].Height = blackKeyHeight;
					_keys[n].Width = blackKeyWidth;
					_keys[n].Location = new Point(offset + (w - 1) * whiteKeyWidth);
					_keys[n].BringToFront();
					n++;
				}
			}
		}
		
		#endregion

		#region Properties

		public List<int> PressedKeyIDs { get; private set; }
		public int PressedBassKeyID { get; private set; }

		#endregion

		public void PressPianoKey(int noteID)
		{
			#region Require

			if (noteID < lowNoteID || noteID > highNoteID) {
				return;
			}

			#endregion

			_keys[noteID - lowNoteID].Press();
		}

		public void PressBassKey(int bassNoteID)
		{
			#region Require

			if (bassNoteID < lowNoteID || bassNoteID > highNoteID) {
				return;
			}

			#endregion

			var key = _keys[bassNoteID - lowNoteID];
			key.IsBassNote = true;
			key.Press();
		}

		public void ReleaseAllPianoKeys()
		{
			for (int i = lowNoteID; i < highNoteID; i++)
				ReleasePianoKey(i);
		}

		public void ReleasePianoKey(int noteID)
		{
			#region Require

			if (noteID < lowNoteID || noteID > highNoteID) {
				throw new ArgumentOutOfRangeException();
			}

			#endregion

			_keys[noteID - lowNoteID].Release();
		}

		public void TogglePianoKey(int noteID)
		{
			int idx = noteID - lowNoteID;
			if (idx > -1 && idx < _keys.Length)
				_keys[idx].Toggle();
		}

		public void PressPianoKey(Keys k)
		{
			if (!this.Focused) {
				return;
			}

			if (_keyTable.Contains(k)) {
				int noteID = (int)_keyTable[k] + 12 * octaveOffset;

				if (noteID >= this.LowNoteID && noteID <= this.HighNoteID) {
					if (!_keys[noteID - lowNoteID].IsPressed) {
						_keys[noteID - lowNoteID].Press();
					}
				}
			}
			else {
				if (k == Keys.D0) {
					octaveOffset = 0;
				}
				else if (k == Keys.D1) {
					octaveOffset = 1;
				}
				else if (k == Keys.D2) {
					octaveOffset = 2;
				}
				else if (k == Keys.D3) {
					octaveOffset = 3;
				}
				else if (k == Keys.D4) {
					octaveOffset = 4;
				}
				else if (k == Keys.D5) {
					octaveOffset = 5;
				}
				else if (k == Keys.D6) {
					octaveOffset = 6;
				}
				else if (k == Keys.D7) {
					octaveOffset = 7;
				}
				else if (k == Keys.D8) {
					octaveOffset = 8;
				}
				else if (k == Keys.D9) {
					octaveOffset = 9;
				}
			}
		}

		public void ReleasePianoKey(Keys k)
		{
			#region Guard

			if (!_keyTable.Contains(k))
				return;

			#endregion

			int noteID = (int)_keyTable[k] + 12 * octaveOffset;

			if (noteID >= this.LowNoteID && noteID <= this.HighNoteID) {
				_keys[noteID - lowNoteID].Release();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			InitializePianoKeys();

			base.OnResize(e);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				foreach (PianoControl.PianoKey key in _keys) {
					key.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		protected virtual void OnPianoKeyDown(PianoKeyEventArgs e)
		{
			if (!this.PressedKeyIDs.Contains(e.NoteID)) {
				this.PressedKeyIDs.Add(e.NoteID);
			}

			PianoKeyDown?.Invoke(this, e);
		}

		protected virtual void OnPianoKeyUp(PianoKeyEventArgs e)
		{
			if (this.PressedKeyIDs.Contains(e.NoteID))
				this.PressedKeyIDs.Remove(e.NoteID);

			PianoKeyUp?.Invoke(this, e);
		}

		protected virtual void OnBassKeyDown(PianoKeyEventArgs e)
		{
			if (this.PressedBassKeyID != e.NoteID) {
				// Release the previous bass key (if there was one)
				if (this.PressedBassKeyID != 0)
					_keys[this.PressedBassKeyID - lowNoteID].Release();

				this.PressedBassKeyID = e.NoteID;
			}

			BassKeyDown?.Invoke(this, e);
		}

		protected virtual void OnBassKeyUp(PianoKeyEventArgs e)
		{
			if (this.PressedBassKeyID == e.NoteID)
				this.PressedBassKeyID = 0;

			BassKeyUp?.Invoke(this, e);
		}

		public int LowNoteID
		{
			get { return lowNoteID; }
			set {
				#region Require

				if (value < 0 || value > Globals.DataMaxValue)
					throw new ArgumentOutOfRangeException("LowNoteID", value, "Low note ID out of range.");

				#endregion

				#region Guard

				if (value == lowNoteID) {
					return;
				}

				#endregion

				lowNoteID = value;

				if (lowNoteID > highNoteID) {
					highNoteID = lowNoteID;
				}

				CreatePianoKeys();
				InitializePianoKeys();
			}
		}

		public int HighNoteID
		{
			get { return highNoteID; }
			set {
				#region Require

				if (value < 0 || value > Globals.DataMaxValue)
					throw new ArgumentOutOfRangeException("HighNoteID", value, "High note ID out of range.");

				#endregion

				#region Guard

				if (value == highNoteID)
					return;

				#endregion

				highNoteID = value;

				if (highNoteID < lowNoteID) {
					lowNoteID = highNoteID;
				}

				CreatePianoKeys();
				InitializePianoKeys();
			}
		}

		[Description("Color when key is pressed"), Category("Behavior")]
		public Color NoteOnColor
		{
			get { return noteOnColor; }
			set {
				#region Guard

				if (value == noteOnColor) {
					return;
				}

				#endregion

				noteOnColor = value;

				foreach (PianoControl.PianoKey key in _keys) {
					key.SetNoteOnColor(noteOnColor);
				}
			}
		}

		[Description("Color when bass key is pressed"), Category("Behavior")]
		public Color BassNoteOnColor
		{
			get { return _bassNoteOnColor; }
			set {
				#region Guard

				if (value == _bassNoteOnColor) {
					return;
				}

				#endregion

				_bassNoteOnColor = value;

				foreach (PianoControl.PianoKey key in _keys) {
					key.SetBassNoteOnColor(_bassNoteOnColor);
				}
			}
		}

		[Description("Keys act as toggle buttons"), Category("Behavior")]
		public bool StickyKeys { get; set; }
	}
}