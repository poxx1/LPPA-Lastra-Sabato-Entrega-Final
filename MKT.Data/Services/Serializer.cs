using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MKT.Entities.Models;

namespace MKT.Data.Services
{
    public class Serializer
    {
        public static List<CartItem> XmlToObject(string data)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<CartItem>));
            var sr = new StringReader(data);
            return xmlSerializer.Deserialize(sr) as List<CartItem>;
        }

        public static string ObjectToXml(List<CartItem> data)
        {
            var xmlSerializer = new XmlSerializer(data.GetType());
            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data);

            return sw.ToString();
        }
    }
}
