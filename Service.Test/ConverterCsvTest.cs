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

        [TestCase("Al ma kota, kot ma ala. Pies ma kota, kot ma psa.")]
        [TestCase("Al  ma kota,   kot ma  ala. Pies   ma kota, kot   ma psa.")]
        public void ParseTest_OneStatement_ReturnOneStatement(string statement)
        {
            var resultAfter = _converterCsv.Convert(statement);
            var expectResult = ", Word  + 1, Word  + 2, Word  + 3, Word  + 4, Word  + 5, Word  + 6\r\nStatement 1, Al, ala, kot, kota, ma, ma\r\nStatement 2, kot, kota, ma, ma, Pies, psa\r\n";
            Assert.IsNotNull(resultAfter);
            Assert.AreEqual(expectResult, resultAfter);
        }
    }
}