using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace KeysTeacher
{
	public static class Utils
	{
		public static Bitmap GetBmpFromResource(string resourceName)
		{
			using (Stream imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
				return Bitmap.FromStream(imgStream) as Bitmap;
			}
		}

		public static string TimeDisplay(int seconds)
		{
			int secs = seconds % 60;
			int mins = Convert.ToInt32(seconds / 60);
			return string.Format("{0}:{1}", mins, secs.ToString("0#"));
		}

		public static Bitmap GetBmpFromResource(Assembly assy, string resourceName)
		{
			using (Stream imgStream = assy.GetManifestResourceStream(resourceName)) {
				if (imgStream == null)
					return null;
				return Image.FromStream(imgStream) as Bitmap;
			}
		}

		public static void XmlSerializeToFile<T>(T obj, string filepath)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

			// Create a new file stream to write the serialized object to a file
			using (StreamWriter textWriter = new StreamWriter(filepath)) {
				xmlSerializer.Serialize(textWriter, obj);
				textWriter.Close();
			}
		}

		public static T XmlDeserializeFromFile<T>(string filepath)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			T returnObj;

			using (FileStream readFileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
				returnObj = (T) xmlSerializer.Deserialize(readFileStream);
				readFileStream.Close();
			}
			return returnObj;
		}
	}
}