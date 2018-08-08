using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private ParserBase _parserCsv { get; set; }
        private ParserBase _parserXml { get; set; }
        public SampleDataController()
        {
            _parserCsv = new ParserCsv();
            _parserXml = new ParserXml();
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class Content{
            public string TextFormatted {get; set;}
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
