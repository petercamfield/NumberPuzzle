using System;
using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class ConversionStrategyFactoryTests
    {
        [Test]
        public void ReturnsTensAndUnitsStrategy()
        {
            var factory = new ConversionStrategyFactory(new BritishEnglishNumbers());
            var hundredGroup = new HundredGroup(25);
            Assert.That(factory.CreateConversionStrategy(hundredGroup), Is.TypeOf<TensAndUnitsConversionStrategy>());
        }
    }

    public class ConversionStrategyFactory
    {
        private readonly IDescribeNumbers numberDescriber;

        public ConversionStrategyFactory(IDescribeNumbers numberDescriber)
        {
            this.numberDescriber = numberDescriber;
        }

        public ConversionStrategy CreateConversionStrategy(object hundredGroup)
        {
            throw new NotImplementedException();
            //Move stuff from NumberConverter class
        }
    }
}