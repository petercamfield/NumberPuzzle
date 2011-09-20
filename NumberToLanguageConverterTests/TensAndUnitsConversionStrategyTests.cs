using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class TensAndUnitsConversionStrategyTests
    {
        private static readonly ConversionStrategy Converter = new TensAndUnitsConversionStrategy(new BritishEnglishNumbers());

        [Test]
        public void ConvertsTen()
        {
            var result = Converter.Convert(new HundredGroup(10));
            Assert.That(result, Is.EqualTo("ten"));
        }

        [Test]
        public void ConvertsThirtyFive()
        {
            var result = Converter.Convert(new HundredGroup(35));
            Assert.That(result, Is.EqualTo("thirty five"));
        }
    }
}