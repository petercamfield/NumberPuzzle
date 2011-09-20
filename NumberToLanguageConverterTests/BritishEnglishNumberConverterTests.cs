using NumberToLanguageConverter;
using NUnit.Framework;
using Moq;
namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumberConverterTests
    {
        private readonly NumberConverter converter = new NumberConverter();

        [Test]
        public void AttemptsToLookUpNumberForConversion()
        {
            var numberDescriber = new Mock<IDescribeNumbers>();
            numberDescriber.Setup(n => n.LookupNumber(1)).Returns(new LookupResult("1"));
            var numberConverter = new NumberConverter(numberDescriber.Object);
            numberConverter.Convert(1);
            numberDescriber.Verify(n=>n.LookupNumber(1));
        }

        [Test]
        public void ReturnsOne()
        {
            Assert.That(converter.Convert(1), Is.EqualTo("one"));
        }

        [Test]
        public void ReturnsTwentyOne()
        {
            Assert.That(converter.Convert(21), Is.EqualTo("twenty one"));
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
        public void ReturnsOneHundredAndOne()
        {
            Assert.That(converter.Convert(101), Is.EqualTo("one hundred and one"));
        }

        [Test]
        public void ReturnsNineHundredAndNinetyNine()
        {
            Assert.That(converter.Convert(999), Is.EqualTo("nine hundred and ninety nine"));
        }

    }
}