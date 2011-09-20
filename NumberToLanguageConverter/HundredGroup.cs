using System;

namespace NumberToLanguageConverter
{
    public class HundredGroup
    {
        private readonly int units;
        private readonly int tens;
        private readonly int hundreds;

        public HundredGroup(int number)
        {
            var formattedNumber = number.ToString("000");
            hundreds = NumberAtIndex(formattedNumber, 0) * 100;
            tens = NumberAtIndex(formattedNumber, 1) * 10;
            units = NumberAtIndex(formattedNumber, 2);
        }

        private static int NumberAtIndex(string formattedNumber, int index)
        {
            return int.Parse(formattedNumber.Substring(index, 1));
        }

        public int Tens
        {
            get { return tens; }
        }

        public int Units
        {
            get { return units; }
        }

        public int Hundreds 
        {
            get { return hundreds; }
        }
    }
}