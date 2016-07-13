using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Generic.Framework.Helpers.Serialization
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(XmlDocument xmlDocument)
        {
            return Deserialize<T>(xmlDocument.OuterXml);
        }

        public static T Deserialize<T>(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var stringReader = new StringReader(xml);

            var imageProcessingConfiguration = (T)xmlSerializer.Deserialize(stringReader);

            return imageProcessingConfiguration;
        }

        public static XmlDocument Serialize<T>(this T t)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            var textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, t);

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(textWriter.ToString());

            return xmlDocument;
        }
    }
}