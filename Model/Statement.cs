using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Model
{
    public class Statement
    {
        [XmlElement("Word")]
        public List<string> Words { get; set; }
        public Statement() : this(new List<string>()){
        }
        public Statement(List<String> words){
            Words = words;
        }
    }
}
