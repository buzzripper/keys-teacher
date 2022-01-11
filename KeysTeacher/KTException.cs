using System;
using System.Runtime.Serialization;

namespace KeysTeacher
{
	[Serializable]
	public class KTException : Exception
	{
		#region Static

		public static void Throw(string message, params object[] args)
		{
			throw new KTException(string.Format(message, args));
		}

		#endregion

		public KTException()
		{}

		public KTException(string msg)
			: base(msg)
		{}

		public KTException(string msgFormat, params object[] args)
			: base(string.Format(msgFormat, args))
		{}

		public KTException(string msg, Exception innerException)
			: base(msg, innerException)
		{}

		public KTException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{}
	}
}