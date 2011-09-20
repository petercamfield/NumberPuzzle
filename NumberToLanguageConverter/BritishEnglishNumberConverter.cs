using System;

namespace NumberToLanguageConverter
{
    public class BritishEnglishNumberConverter : IConvertNumbers
    {
        private readonly IDescribeNumbers numberDescriber;

        public BritishEnglishNumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        public BritishEnglishNumberConverter(IDescribeNumbers numberDescriber)
        {
            this.numberDescriber = numberDescriber;
        }

        public string Convert(int number)
        {
            var hundredGroup = new HundredGroup(number);
            var strategy = ConversionStrategy(hundredGroup);
            return strategy(hundredGroup);
            
        }

        private Func<HundredGroup, string> ConversionStrategy(HundredGroup hundredGroup)
        {
            if (HasHundreds(hundredGroup) && HasTensOrUnits(hundredGroup)) return GetHundredsAndTensAndUnits;
            if (HasHundreds(hundredGroup)) return GetHundreds;
            return GetTensAndUnits;
        }

        private static bool HasTensOrUnits(HundredGroup hundredGroup)
        {
            return (hundredGroup.Tens + hundredGroup.Units) > 0;
        }

        private static bool HasHundreds(HundredGroup hundredGroup)
        {
            return hundredGroup.Hundreds > 0;
        }

        private string GetHundreds(HundredGroup hundredGroup)
        {
            const string numberFormat = "{0} {1}";
            var numberOfHundreds = numberDescriber.LookupNumber(hundredGroup.NumberOfHundreds);
            var hundred = numberDescriber.LookupPositionalName(100);
            return string.Format(numberFormat, numberOfHundreds.Description, hundred.Description);
        }

        private string GetTensAndUnits(HundredGroup hundredGroup)
        {
            var lookupResult = numberDescriber.LookupNumber(hundredGroup.Number);
            if (lookupResult.Found) return lookupResult.Description;
            
            const string numberFormat = "{0} {1}";
            var tens = numberDescriber.LookupNumber(hundredGroup.Tens);
            var units = numberDescriber.LookupNumber(hundredGroup.Units);
            return string.Format(numberFormat, tens.Description, units.Description);
        }

        private string GetHundredsAndTensAndUnits(HundredGroup hundredGroup)
        {
            const string numberFormat = "{0} and {1}";
            var hundreds = Convert(hundredGroup.Hundreds);
            var tensAndUnits = Convert(hundredGroup.Tens + hundredGroup.Units);
            return string.Format(numberFormat, hundreds, tensAndUnits);
        }
    }
}