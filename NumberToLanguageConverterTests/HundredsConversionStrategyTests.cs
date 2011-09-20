using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class HundredsConversionStrategyTests
    {
        private static readonly ConversionStrategy Converter = new HundredsConversionStrategy(new BritishEnglishNumbers());

        [Test]
        public void ConvertsOneHundred()
        {
            var result = Converter.Convert(new HundredGroup(100));
            Assert.That(result, Is.EqualTo("one hundred"));
        }

        [Test]
        public void ConvertsNineHundred()
        {
            var result = Converter.Convert(new HundredGroup(900));
            Assert.That(result, Is.EqualTo("nine hundred"));
        }
    }
}