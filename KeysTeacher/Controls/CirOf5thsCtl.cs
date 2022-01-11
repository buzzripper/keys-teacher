using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeysTeacher
{
	public partial class CirOf5thsCtl : UserControl
	{
		#region Fields

		private Key _key;
		private readonly Bitmap _noKeyPic;
		private readonly Dictionary<Key, Bitmap> _majorPics;
		private readonly Dictionary<Key, Bitmap> _minorPics;

		#endregion

		#region Constructors

		public CirOf5thsCtl()
		{
			InitializeComponent();

			const string prefix = "KeysTeacher.Images.CircleOf5ths";

			_majorPics = new Dictionary<Key, Bitmap>();
			_minorPics = new Dictionary<Key, Bitmap>();
			List<Key> allKeys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));
			foreach (Key key in allKeys) {
				if (key.GetQuality() == Quality.Major)
					_majorPics.Add(key, Utils.GetBmpFromResource(string.Format("{0}Cir_{1}.gif", prefix, key)));
				else
					_minorPics.Add(key, Utils.GetBmpFromResource(string.Format("{0}Cir_{1}.gif", prefix, key)));
			}
			_noKeyPic = Utils.GetBmpFromResource(string.Format("{0}Cir_NoKey.gif", prefix));
		}

		#endregion

		public Key Key
		{
			get { return _key; }
			set
			{
				_key = value;
				switch (_key.GetQuality()) {
					case Quality.Major:
						pictureBox1.Image = _majorPics[_key];
						break;
					case Quality.Minor:
						pictureBox1.Image = _minorPics[_key];
						break;
					default:
						pictureBox1.Image = _noKeyPic;
						break;
				}
			}
		}
	}
}