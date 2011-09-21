using System.Collections.Generic;
using System.Linq;

namespace NumberToLanguageConverter
{
    public class ResultsCalculator
    {
        private readonly IEnumerable<HundredGroup> numberGroups;
        private readonly IEnumerable<ConversionStrategy> converters;
        private readonly IDescribeNumbers numberDescriber;

        public ResultsCalculator(IEnumerable<HundredGroup> numberGroups, IEnumerable<ConversionStrategy> converters, IDescribeNumbers numberDescriber)
        {
            this.numberGroups = numberGroups;
            this.converters = converters;
            this.numberDescriber = numberDescriber;
        }

        public IEnumerable<string> CalculateResults()
        {
            var numberGroupEnumerator = numberGroups.GetEnumerator();
            var converterEnumerator = converters.GetEnumerator();
            var positionalEnumerator = GetPositionalIndexEnumerator();
            var results = new List<string>();
            while(IsMoreResults(numberGroupEnumerator, converterEnumerator, positionalEnumerator))
            {
                results.Add(ResultFor(numberGroupEnumerator.Current, converterEnumerator.Current, positionalEnumerator.Current));
            }
            if (ShouldAddConjunctionBeforeLastGroup(numberGroups)) results.Insert(results.Count - 1, numberDescriber.Conjunction);

            return NonEmpty(results);
        }

        private static IEnumerable<string> NonEmpty(IEnumerable<string> results)
        {
            return results.Where(result => result.Length > 0);
        }

        private static bool IsMoreResults(IEnumerator<HundredGroup> numberGroupEnumerator, IEnumerator<ConversionStrategy> converterEnumerator, IEnumerator<int> positionalEnumerator)
        {
            return numberGroupEnumerator.MoveNext() && converterEnumerator.MoveNext() && positionalEnumerator.MoveNext();
        }

        private string ResultFor(HundredGroup numberGroup, ConversionStrategy converter, int position)
        {
            var result = converter.Convert(numberGroup);
            var postfix = numberDescriber.LookupPositionalName(position).Description;
            var shouldPostfixResult = result.Length > 0 && postfix.Length > 0;
            return shouldPostfixResult ? string.Format("{0} {1}", result, postfix) : result;
        }

        private static bool ShouldAddConjunctionBeforeLastGroup(IEnumerable<HundredGroup> numberGroups)
        {
            var otherGroups = numberGroups.Take(2);
            var lastGroup = numberGroups.Last();
            return (RequiresConjunction(lastGroup) && GroupsHaveAValue(otherGroups));
        }

        private static bool RequiresConjunction(HundredGroup lastGroup)
        {
            return lastGroup.Hundreds==0 && lastGroup.Number>0;
        }

        private static bool GroupsHaveAValue(IEnumerable<HundredGroup> groups)
        {
            return groups.Any(group => group.Number > 0);
        }

        private static IEnumerator<int> GetPositionalIndexEnumerator()
        {
            return new[] {1000000, 1000, 1}.AsEnumerable().GetEnumerator();
        }
    }
}