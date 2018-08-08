using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("Text")]
    public class Content
    {
        [XmlElement("Statement")]
        public List<Statement> Text { get; set; }
        public Content() : this(new List<Statement>()){
        }
        public Content(List<Statement> text){
            Text = text;
        }
    }
}
