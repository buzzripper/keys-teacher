using System;

namespace KeysTeacher
{
	public class QuickRnd : RandomBase
	{
		#region Constructors

		public QuickRnd() : this(Convert.ToInt32(DateTime.Now.Ticks & 0x000000007FFFFFFF))
		{}

		public QuickRnd(int seed)
			: base(seed)
		{
			i = Convert.ToUInt64(GetBaseNextInt32());
		}

		#endregion

		#region Member Variables

		private static readonly uint a = 1099087573;
		private ulong i;

		#endregion

		#region Methods

		public override int Next()
		{
			#region Execution

			i = a * i; // overflow occurs here!
			return ConvertToInt32(i);

			#endregion
		}

		#endregion
	}
}