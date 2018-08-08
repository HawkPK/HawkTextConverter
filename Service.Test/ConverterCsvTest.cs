using NUnit.Framework;
using Service;

namespace ConverterCsvTest
{
	[TestFixture]	
    public class ConverterCsvTest
    {
        private ParserBase _converterCsv;
        [SetUp]
        public void Setup()
        {
            _converterCsv = new ParserCsv();
        }

		
		[Test]
        public void ParseTest_OneStatement_ReturnOneStatement()
        {
            var statement = "Al ma kota, kot ma ala. Pies ma kota, kot ma psa";
            var resultAfter = _converterCsv.Convert(statement);
            var expectResult = ", Word  + 1, Word  + 2, Word  + 3, Word  + 4, Word  + 5, Word  + 6\r\nStatement 1, Al, ala, kot, kota, ma, ma\r\n";
            Assert.IsNotNull(resultAfter);
            Assert.AreEqual(expectResult, resultAfter);
        }
    }
}