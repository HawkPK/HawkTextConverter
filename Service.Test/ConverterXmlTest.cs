using NUnit.Framework;
using Service;

namespace ConverterCsvTest
{
	[TestFixture]	
    public class ConverterXmlTest
    {
        private ParserBase _parserXml;
        [SetUp]
        public void Setup()
        {
            _parserXml = new ParserXml();
        }

		
		[Test]
        public void ParseTest_OneStatement_ReturnOneStatement()
        {
            var statement = "Al ma kota, kot ma Ala. Pies ma kota, kot ma psa.";
            var expectResult = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Text><Statement><Word>Al</Word><Word>Ala</Word><Word>kot</Word><Word>kota</Word><Word>ma</Word><Word>ma</Word></Statement><Statement><Word>kot</Word><Word>kota</Word><Word>ma</Word><Word>ma</Word><Word>Pies</Word><Word>psa</Word></Statement></Text>";
            var resultAfter = _parserXml.Convert(statement);
            Assert.IsNotNull(resultAfter);
            Assert.AreEqual(expectResult, resultAfter);
        }
    }
}