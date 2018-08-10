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
        
		[TestCase("Al ma kota, kot ma Ala. Pies ma kota, kot ma psa.")]
        [TestCase("Al ma kota,    kot ma   Ala. Pies ma   kota, kot ma psa.")]
        public void ParseTest_OneStatement_ReturnOneStatement(string statement)
        {
            var expectResult = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Text>\r\n<Statement>\r\n<Word>Al</Word>\r\n<Word>Ala</Word>\r\n<Word>kot</Word>\r\n<Word>kota</Word>\r\n<Word>ma</Word>\r\n<Word>ma</Word>\r\n</Statement>\r\n<Statement>\r\n<Word>kot</Word>\r\n<Word>kota</Word>\r\n<Word>ma</Word>\r\n<Word>ma</Word>\r\n<Word>Pies</Word>\r\n<Word>psa</Word>\r\n</Statement>\r\n</Text>\r\n";
            var resultAfter = _parserXml.Convert(statement);
            Assert.IsNotNull(resultAfter);
            Assert.AreEqual(expectResult, resultAfter);
        }
    }
}