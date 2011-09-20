namespace NumberToLanguageConverter
{
    public class BritishEnglishNumberConverter : IConvertNumbers
    {
        private readonly IDescribeNumbers britishEnglishNumbers;

        public BritishEnglishNumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        public BritishEnglishNumberConverter(IDescribeNumbers britishEnglishNumbers)
        {
            this.britishEnglishNumbers = britishEnglishNumbers;
        }

        public string Convert(int number)
        {
            var lookupResult = britishEnglishNumbers.LookupNumber(number);
            if (lookupResult.Found) return lookupResult.Description;

            var hundredGroup = new HundredGroup(number);

            if (hundredGroup.Hundreds > 0) return GetHundreds(hundredGroup);

            return GetTensAndUnits(hundredGroup);
            
        }

        private string GetHundreds(HundredGroup hundredGroup)
        {
            const string numberFormat = "{0} {1}";
            var numberOfHundreds = britishEnglishNumbers.LookupNumber(hundredGroup.NumberOfHundreds);
            var hundred = britishEnglishNumbers.LookupPowerOfTen(2);
            return string.Format(numberFormat, numberOfHundreds.Description, hundred.Description);
        }

        private string GetTensAndUnits(HundredGroup hundredGroup)
        {
            const string numberFormat = "{0} {1}";
            var tens = britishEnglishNumbers.LookupNumber(hundredGroup.Tens);
            var units = britishEnglishNumbers.LookupNumber(hundredGroup.Units);
            return string.Format(numberFormat, tens.Description, units.Description);
        }
    }
}