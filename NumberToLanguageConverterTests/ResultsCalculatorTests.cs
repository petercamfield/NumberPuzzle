using System.Collections.Generic;
using System.Linq;
using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class ResultsCalculatorTests
    {
        private readonly IDescribeNumbers numberDescriber = new BritishEnglishNumbers();

        [Test]
        public void ReturnsMillionsResult()
        {
            IEnumerable<HundredGroup> numberGroups = new[] { new HundredGroup(1), new HundredGroup(0), new HundredGroup(0) };
            var converters = GetConverters();
            var resultsCalculator = new ResultsCalculator(numberGroups, converters, numberDescriber);
            AssertResultIs("one million", resultsCalculator);
        }

        [Test]
        public void ReturnsThousandsResult()
        {
            IEnumerable<HundredGroup> numberGroups = new[] { new HundredGroup(0), new HundredGroup(1), new HundredGroup(0) };
            var converters = GetConverters();
            var resultsCalculator = new ResultsCalculator(numberGroups, converters, numberDescriber);
            AssertResultIs ("one thousand", resultsCalculator);
        }

        [Test]
        public void ReturnsUnitsResult()
        {
            IEnumerable<HundredGroup> numberGroups = new[] { new HundredGroup(0), new HundredGroup(0), new HundredGroup(1) };
            var converters = GetConverters();
            var resultsCalculator = new ResultsCalculator(numberGroups, converters, numberDescriber);
            AssertResultIs("one", resultsCalculator);
        }

        [Test]
        public void JoinsMillionsToTensAndUnits()
        {
            IEnumerable<HundredGroup> numberGroups = new[] { new HundredGroup(1), new HundredGroup(0), new HundredGroup(1) };
            var converters = GetConverters();
            var resultsCalculator = new ResultsCalculator(numberGroups, converters, numberDescriber);
            var results = resultsCalculator.CalculateResults();
            Assert.That(results.ElementAt(1), Is.EqualTo("and"));
        }

        [Test]
        public void JoinsThousandsToTensAndUnits()
        {
            IEnumerable<HundredGroup> numberGroups = new[] { new HundredGroup(0), new HundredGroup(1), new HundredGroup(1) };
            var converters = GetConverters();
            var resultsCalculator = new ResultsCalculator(numberGroups, converters, numberDescriber);
            var results = resultsCalculator.CalculateResults();
            Assert.That(results.ElementAt(1), Is.EqualTo("and"));
        }

        private IEnumerable<ConversionStrategy> GetConverters()
        {
            return new ConversionStrategy[]
                       {
                           new TensAndUnitsConversionStrategy(numberDescriber),
                           new TensAndUnitsConversionStrategy(numberDescriber),
                           new TensAndUnitsConversionStrategy(numberDescriber)
                       };
        }

        private static void AssertResultIs(string result, ResultsCalculator resultsCalculator)
        {
            var results = resultsCalculator.CalculateResults();
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.First(), Is.EqualTo(result));
        }
    }
}