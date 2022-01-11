using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace KeysTeacher.Misc
{
    public static class XmlTools
    {
        #region Static Fields

        private static readonly XmlSerializerNamespaces Ns = new XmlSerializerNamespaces();

        #endregion

        #region Static Constructor

        static XmlTools()
        {
            Ns.Add(String.Empty, String.Empty);
        }

        #endregion

        #region Static Methods

        public static string Serialize(object obj)
        {
            var xml = UTF8ByteArrayToString(SerializeToBytes(obj).ToArray());

			XDocument doc = XDocument.Parse(xml);
			return doc.ToString();
		}

        public static byte[] SerializeToBytes(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (MemoryStream memStream = new MemoryStream()) {
                using (XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Default)) {
                    serializer.Serialize(writer, obj);
                    return memStream.ToArray();
                }
            }
        }

        public static void SerializeToFile(object obj, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (FileStream writer = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)) {
                serializer.Serialize(writer, obj, Ns);
            }
        }

        public static void SerializeToFileWriteThrough( object obj, string filename )
        {
            XmlSerializer serializer = new XmlSerializer( obj.GetType( ) );
            using( FileStream writer = new FileStream( filename, FileMode.Create, FileSystemRights.FullControl, FileShare.Read, 4096, FileOptions.WriteThrough ) )
            {
                serializer.Serialize( writer, obj, Ns );
                writer.Flush( true );
            }
        }

        public static object DeserializeFromBytes( Type type, byte[] bytes )
        {
            var serializer = new XmlSerializer( type );
            using (var ms = new MemoryStream(bytes))
            using (var xmlReader = XmlReader.Create(ms))
                return serializer.Deserialize(xmlReader);
        }

        public static T DeserializeFromBytes<T>(byte[] serializedBytes) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(serializedBytes))
            using (XmlReader xmlReader = XmlReader.Create(ms)) {
                return serializer.Deserialize(xmlReader) as T;
            }
        }

        public static T Deserialize<T>(string serializedObj) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(serializedObj)))
            using (XmlReader xmlReader = XmlReader.Create(ms)) {
                return serializer.Deserialize(xmlReader) as T;
            }
        }

        public static object Deserialize(Type objectType, string serializedObj)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(serializedObj)))
            using (XmlReader xmlReader = XmlReader.Create(ms))
            {
                return serializer.Deserialize(xmlReader);
            }
        }

        public static T DeserializeFromFile<T>(string filepath) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                return serializer.Deserialize(fs) as T;
            }
        }

        public static object DeserializeFromFile(Type objectType, string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                return serializer.Deserialize(fs);
            }
        }

        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public static T SerializeCopy<T>(T obj) where T : class
        {
            var serObj = Serialize(obj);
            return Deserialize<T>(serObj);
        }

        #endregion
    }
}