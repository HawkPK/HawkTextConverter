using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ConverterTextController : Controller
    {
        private ParserBase _parserCsv { get; set; }
        private ParserBase _parserXml { get; set; }
        public ConverterTextController()
        {
            _parserCsv = new ParserCsv();
            _parserXml = new ParserXml();
        }

        [HttpGet("[action]")]
        public Content ConvertToXml(string text){
            var textParsed = _parserXml.Convert(text);
            var textFormatted = new Content(){
                TextFormatted = textParsed
            };
            return textFormatted;
        }

        [HttpGet("[action]")]
        public Content ConvertToCsv(string text)
        {
            var textParsed = _parserCsv.Convert(text);
            var textFormatted = new Content()
            {
                TextFormatted = textParsed
            };
            return textFormatted;
        }

        public class Content{
            public string TextFormatted {get; set;}
        }
    }
}
