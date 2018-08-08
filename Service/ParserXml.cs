using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Model;

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
            return sw.ToString();
        }
    }
}
