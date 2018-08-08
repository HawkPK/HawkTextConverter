using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Service
{
    public abstract class ParserBase
    {
        public abstract string Parse(Content content);
        public string Convert(String text)
        {
            var delimiters = new Char[] { ' '};
            var words = text.Replace(",", "").Split(delimiters).Where(x=> x != String.Empty).ToList();
            var textFormatted = new Content();
            var statement = new Statement();
            foreach (var word in words)
            {
                if (Regex.IsMatch(word, @"\."))
                {
                    if (word.Length != 1)
                    {
                        statement.Words.Add(word.Replace(".", ""));
                        statement.Words.Sort();
                        textFormatted.Text.Add(statement);
                    }
                    statement = new Statement();
                }
                else
                {
                    statement.Words.Add(word);
                }
            }
            string textParsed = Parse(textFormatted);
            return textParsed.ToString();
        }
    }
}
