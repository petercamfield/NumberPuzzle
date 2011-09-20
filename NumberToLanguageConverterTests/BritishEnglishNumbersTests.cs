using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumbersTests
    {
        private readonly IDescribeNumbers britishEnglishNumbers = new BritishEnglishNumbers();

        [Test]
        public void LooksUpOne()
        {
            Assert.That(britishEnglishNumbers.Lookup(1), Is.EqualTo("one"));
        }

        [Test]
        public void LooksUpTwo()
        {
            Assert.That(britishEnglishNumbers.Lookup(2), Is.EqualTo("two"));
        }

        [Test]
        public void LooksUpThree()
        {
            Assert.That(britishEnglishNumbers.Lookup(3), Is.EqualTo("three"));
        }



    }
}