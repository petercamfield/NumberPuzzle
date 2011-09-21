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
            var results = GetResults(numberGroups, converters);
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

        private IEnumerable<string> GetResults(IEnumerable<HundredGroup> numberGroups, IEnumerable<ConversionStrategy> converters)
        {
            var numberGroupEnumerator = numberGroups.GetEnumerator();
            var converterEnumerator = converters.GetEnumerator();
            var positionalEnumerator = GetPositionalIndexEnumerator();
            var results = new List<string>();
            while(numberGroupEnumerator.MoveNext() && converterEnumerator.MoveNext() && positionalEnumerator.MoveNext())
            {
                results.Add(GetResult(numberGroupEnumerator.Current, converterEnumerator.Current, positionalEnumerator.Current));
            }
            if (ShouldAddConjunctionBeforeLastGroup(numberGroups)) results.Insert(results.Count - 1, numberDescriber.Conjunction);

            return results.Where(result => result.Length > 0);
        }

        private static bool ShouldAddConjunctionBeforeLastGroup(IEnumerable<HundredGroup> numberGroups)
        {
            var otherGroups = numberGroups.Take(2);
            var lastGroup = numberGroups.Last();
            var lastGroupRequiresConjunction = lastGroup.Hundreds==0 && lastGroup.Number>0;
            var otherGroupsHaveAValue =
                otherGroups.Select(group => group.Number > 0).Aggregate((sofar, current) => sofar || current);
            return (lastGroupRequiresConjunction && otherGroupsHaveAValue);
        }

        private string GetResult(HundredGroup numberGroup, ConversionStrategy converter, int position)
        {
            var result = converter.Convert(numberGroup);
            var postfix = numberDescriber.LookupPositionalName(position).Description;
            var shouldPostfixResult = result.Length > 0 && postfix.Length > 0;
            return shouldPostfixResult ? string.Format("{0} {1}", result, postfix) : result;
        }

        private static IEnumerator<int> GetPositionalIndexEnumerator()
        {
            return new[] {1000000, 1000, 1}.AsEnumerable().GetEnumerator();
        }
    }
}