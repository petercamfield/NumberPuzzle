namespace NumberToLanguageConverter
{
    public class HundredGroup
    {
        private readonly int units;
        private readonly int tens;
        private readonly int numberOfHundreds;
        private readonly int number;

        public HundredGroup(int number)
        {
            this.number = number;
            var formattedNumber = number.ToString("000");
            numberOfHundreds = NumberAtIndex(formattedNumber, 0);
            tens = NumberAtIndex(formattedNumber, 1) * 10;
            units = NumberAtIndex(formattedNumber, 2);
        }

        public int Number
        {
            get { return number; }
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
            get { return numberOfHundreds * 100; }
        }

        public int NumberOfHundreds
        {
            get { return numberOfHundreds; }
        }
    }
}