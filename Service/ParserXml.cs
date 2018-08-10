using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using Model;
using System.Text;

namespace Service
{
    public class ParserXml : ParserBase
    {
        public override string Parse(Content text)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(text.GetType());
                tw = new XmlTextWriter(sw);
                tw.Formatting = Formatting.Indented;
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(tw, text, ns);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }

            var swSplittedByLine = sw.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var xmlString = new StringBuilder();
            foreach (var line in swSplittedByLine)
            {
                xmlString.Append($"{line.TrimStart(' ')}{Environment.NewLine}");
            }
            return xmlString.ToString();
        }
    }
}
