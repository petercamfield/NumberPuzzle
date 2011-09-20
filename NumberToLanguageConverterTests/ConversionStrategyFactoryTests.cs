using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class ConversionStrategyFactoryTests
    {
        private static readonly ConversionStrategyFactory Factory = new ConversionStrategyFactory(new BritishEnglishNumbers());

        [Test]
        public void ReturnsHundredsStrategy()
        {
            var hundredGroup = new HundredGroup(100);
            Assert.That(Factory.CreateConversionStrategy(hundredGroup), Is.TypeOf<HundredsConversionStrategy>());
        }

        [Test]
        public void ReturnsTensAndUnitsStrategy()
        {
            var hundredGroup = new HundredGroup(25);
            Assert.That(Factory.CreateConversionStrategy(hundredGroup), Is.TypeOf<TensAndUnitsConversionStrategy>());
        }

        [Test]
        public void ReturnsHundredsTensAndUnitsStrategy()
        {
            var hundredGroup = new HundredGroup(101);
            Assert.That(Factory.CreateConversionStrategy(hundredGroup), Is.TypeOf<HundredsTensAndUnitsConversionStrategy>());
        }
    }
}