using NUnit.Framework;
using Service;

namespace Tests
{
	[TestFixture]	
    public class Tests
    {
		private Class1 _primeService;
        [SetUp]
        public void Setup()
        {
			_primeService = new Class1();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
		
		[Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}