using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Avtec.Tools.LogViewer.Data
{
	[Serializable]
	public class LogViewerData
	{
		#region Fields

		private string _windowPlacementStr;

		#endregion

		#region Constructor

		public LogViewerData()
		{
			DbConns = new List<DbConn>();
		}

		#endregion

		[XmlAttribute]
		public string MRUConnStringName { get; set; }

		[XmlAttribute]
		public bool MRUSortAsc { get; set; }

		[XmlArray("DbConns")]
		[XmlArrayItem("DbConn", typeof(DbConn))]
		public List<DbConn> DbConns { get; set; }

		[XmlElement("CDataElement")]
		public XmlCDataSection WindowPlacement
		{
			get
			{
				XmlDocument doc = new XmlDocument();
				return doc.CreateCDataSection(_windowPlacementStr);
			}
			set
			{
				_windowPlacementStr = value.Value;
			}
		}

		//[XmlIgnore]
		//public string WindowPlacement
		//{
		//	get
		//	{
		//		if (SerializedXmlString == null)
		//			return "";
		//		return SerializedXmlString.Value;
		//	}
		//	set
		//	{
		//		if (SerializedXmlString == null)
		//			SerializedXmlString = new RawString();
		//		SerializedXmlString.Value = value;
		//	}
		//}

		//[XmlElement("XmlString")]
		//[Browsable(false)]
		//[EditorBrowsable(EditorBrowsableState.Never)]
		//public RawString SerializedXmlString;
	}

	//public class RawString : IXmlSerializable
	//{
	//	public string Value { get; set; }

	//	public XmlSchema GetSchema()
	//	{
	//		return null;
	//	}

	//	public void ReadXml(System.Xml.XmlReader reader)
	//	{
	//		this.Value = reader.ReadInnerXml();
	//	}

	//	public void WriteXml(System.Xml.XmlWriter writer)
	//	{
	//		writer.WriteRaw(this.Value);
	//	}
	//}
}
