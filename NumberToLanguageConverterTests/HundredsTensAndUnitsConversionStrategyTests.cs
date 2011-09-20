using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class HundredsTensAndUnitsConversionStrategyTests
    {
        private static readonly ConversionStrategy Converter = new HundredsTensAndUnitsConversionStrategy(new BritishEnglishNumbers());

        [Test]
        public void ConvertsOneHundredAndOne()
        {
            var result = Converter.Convert(new HundredGroup(101));
            Assert.That(result, Is.EqualTo("one hundred and one"));
        }

        [Test]
        public void ConvertsTwoHundredAndTwentyTwo()
        {
            var result = Converter.Convert(new HundredGroup(222));
            Assert.That(result, Is.EqualTo("two hundred and twenty two"));
        }
    }
}