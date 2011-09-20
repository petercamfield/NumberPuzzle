using NumberToLanguageConverter;
using NUnit.Framework;
using Moq;
namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumberConverterTests
    {
        private readonly BritishEnglishNumberConverter converter = new BritishEnglishNumberConverter();

        [Test]
        public void AttemptsToLookUpNumberForConversion()
        {
            var numberDescriber = new Mock<IDescribeNumbers>();
            numberDescriber.Setup(n => n.LookupNumber(1)).Returns(new LookupResult("1"));
            var numberConverter = new BritishEnglishNumberConverter(numberDescriber.Object);
            numberConverter.Convert(1);
            numberDescriber.Verify(n=>n.LookupNumber(1));
        }

        [Test]
        public void ReturnsTwentyOne()
        {
            Assert.That(converter.Convert(21), Is.EqualTo("twenty one"));
        }

        [Test]
        public void ReturnsTwentyTwo()
        {
            Assert.That(converter.Convert(22), Is.EqualTo("twenty two"));
        }

        [Test]
        public void ReturnsNinetyNine()
        {
            Assert.That(converter.Convert(99), Is.EqualTo("ninety nine"));
        }

        [Test]
        public void ReturnsOneHundred()
        {
            Assert.That(converter.Convert(100), Is.EqualTo("one hundred"));
        }

        [Test]
        public void ReturnsTwoHundred()
        {
            Assert.That(converter.Convert(200), Is.EqualTo("two hundred"));
        }
    }
}