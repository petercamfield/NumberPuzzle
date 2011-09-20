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
            var lookupResult = britishEnglishNumbers.Lookup(number);
            if (lookupResult.Found) return lookupResult.Description;

            var hundredGroup = new HundredGroup(number);
            return GetTensAndUnits(hundredGroup);
            
        }

        private string GetTensAndUnits(HundredGroup hundredGroup)
        {
            const string numberFormat = "{0} {1}";
            var tens = britishEnglishNumbers.Lookup(hundredGroup.Tens).Description;
            var units = britishEnglishNumbers.Lookup(hundredGroup.Units).Description;
            return string.Format(numberFormat, tens, units);
        }
    }
}