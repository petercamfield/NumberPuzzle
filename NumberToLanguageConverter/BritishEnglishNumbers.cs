using System.Collections.Generic;

namespace NumberToLanguageConverter
{
    public class BritishEnglishNumbers : IDescribeNumbers
    {
        private readonly Dictionary<int, string> lookup = new Dictionary<int,string>
                                          {
                                              {1, "one"},
                                              {2, "two"},
                                              {3, "three"}
                                          };

        public string Lookup(int number)
        {
            return lookup[number];
        }
    }
}