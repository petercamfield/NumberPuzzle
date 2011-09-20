using System;

namespace NumberToLanguageConverter
{
    public class BritishEnglishNumberConverter : IConvertNumbers
    {
        private readonly IDescribeNumbers britishEnglishNumbers;

        public BritishEnglishNumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        private BritishEnglishNumberConverter(IDescribeNumbers britishEnglishNumbers)
        {
            this.britishEnglishNumbers = britishEnglishNumbers;
        }

        public string Convert(int number)
        {
            return britishEnglishNumbers.Lookup(number);
        }
    }
}