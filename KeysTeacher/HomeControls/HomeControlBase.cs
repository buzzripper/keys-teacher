using System;
using System.Windows.Forms;

namespace KeysTeacher.HomeControls
{
	public class HomeControlBase : UserControl, IHomeControlBase
	{
		#region Events

		public event EventHandler NeedSaving;

		#endregion

		#region Methods

		public virtual void SendKeyDown(KeyEventArgs e)
		{}

		public bool IsActive => this.Visible;

		public virtual void Activate()
		{
			this.Visible = true;
		}

		public virtual void Deactivate()
		{
			this.Visible = false;
		}

		protected void InvokeNeedSavingEvent()
		{
			if (NeedSaving != null)
				NeedSaving(this, new EventArgs());
		}

		#endregion
	}
}