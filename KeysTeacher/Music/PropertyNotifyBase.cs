using System;
using System.ComponentModel;

namespace KeysTeacher
{
	[Serializable]
	public class PropertyNotifyBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void FirePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}