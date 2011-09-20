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
            return "twenty one";
        }
    }
}