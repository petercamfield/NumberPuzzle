using System.Collections.Generic;
using System.Linq;

namespace NumberToLanguageConverter
{
    public class NumberConverter : IConvertNumbers
    {
        private readonly ConversionStrategyFactory factory;
        private readonly IDescribeNumbers numberDescriber;

        public NumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        public NumberConverter(IDescribeNumbers numberDescriber)
        {
            this.numberDescriber = numberDescriber;
            factory = new ConversionStrategyFactory(numberDescriber);
        }

        public string Convert(int number)
        {
            var numberGroups = GetNumberGroups(number);
            var converters = GetConverters(numberGroups);
            var results =  new ResultsCalculator(numberGroups, converters, numberDescriber).CalculateResults();
            return string.Join(" ", results);
        }

        private static IEnumerable<HundredGroup> GetNumberGroups(int number)
        {
            var numberGroups = number.ToString("000,000,000").Split(',');
            return numberGroups.Select(numberGroup => new HundredGroup(int.Parse(numberGroup)));
        }

        private IEnumerable<ConversionStrategy> GetConverters(IEnumerable<HundredGroup> numberGroups)
        {
            return numberGroups.Select(numberGroup => factory.CreateConversionStrategy(numberGroup));
        }
    }
}