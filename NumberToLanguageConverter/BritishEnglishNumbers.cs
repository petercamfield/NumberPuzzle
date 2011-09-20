using System.Collections.Generic;

namespace NumberToLanguageConverter
{
    public class BritishEnglishNumbers : IDescribeNumbers
    {
        private readonly Dictionary<int, string> numberLookup =
            new Dictionary<int, string>
                {
                    {1, "one"},      {2, "two"},        {3, "three"},     {4, "four"},      {5, "five"}, 
                    {6, "six"},      {7, "seven"},      {8, "eight"},     {9, "nine"},      {10, "ten"}, 
                    {11, "eleven"},  {12, "twelve"},    {13, "thirteen"}, {14, "fourteen"}, {15, "fifteen"},
                    {16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"}, {20, "twenty"},
                    {30, "thirty"},  {40, "fourty"},    {50, "fifty"},    {60, "sixty"},    {70, "seventy"},
                    {80, "eighty"},  {90, "ninety"}
                };

        private readonly Dictionary<int, string> powerOfTenLookup =
            new Dictionary<int, string>
                {
                    {2, "hundred"}
                };

        public LookupResult LookupNumber(int number)
        {
            return LookupValue(number, numberLookup);
        }

        public LookupResult LookupPowerOfTen(int powerOfTen)
        {
            return LookupValue(powerOfTen, powerOfTenLookup);
        }

        private static LookupResult LookupValue(int key, Dictionary<int,string> lookup)
        {
            return lookup.ContainsKey(key) ? new LookupResult(lookup[key]) : LookupResult.NotFound;
        }
    }
}