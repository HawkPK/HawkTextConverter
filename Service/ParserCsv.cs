using System;

using System.Linq;
using System.Text;
using Model;

namespace Service
{
    public class ParserCsv : ParserBase
    {
        public override string Parse(Content content)
        {
            var csvString = new StringBuilder();
            var statements = content.Text;
            var columnCount = statements.Select(x => x.Words.Count).Max();
            var header = GetHeaderCsv(columnCount);
            csvString.Append(header);
            for(int i=0; i< statements.Count; i++)
            {
                var template = $"Statement {i+1}";
                var statementCsv = template + GetStatementCsv(statements[i]);
                csvString.Append(statementCsv);
            }
            return csvString.ToString();
        }

        internal static string GetStatementCsv(Statement statement)
        {
            var row = new StringBuilder();
            foreach (var word in statement.Words)
            {
                row.Append(", " + word);
            }
            row.Append(Environment.NewLine);
            return row.ToString();
        }

        internal static string GetHeaderCsv(int columnCount)
        {
            var headerCsv = new StringBuilder(); ;
            var header = new StringBuilder();
            for (int i = 0; i < columnCount; i++)
            {
                var template = ", Word ";
                header.Append($"{template} + {i+1}");
            }

            headerCsv.Append(header + Environment.NewLine);
            return headerCsv.ToString();
        }
    }
}
