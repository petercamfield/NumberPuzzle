namespace NumberToLanguageConverter
{
    public class HundredsConversionStrategy : ConversionStrategy 
    {

        public HundredsConversionStrategy(IDescribeNumbers numberDescriber) : base(numberDescriber)
        {
        }

        public override string Convert(HundredGroup hundredGroup)
        {
            var numberOfHundreds = NumberDescriber.LookupNumber(hundredGroup.NumberOfHundreds);
            var hundred = NumberDescriber.LookupPositionalName(100);
            return Format(numberOfHundreds, hundred);
        }

        private static string Format(LookupResult numberOfHundreds, LookupResult hundred)
        {
            const string numberFormat = "{0} {1}";
            return string.Format(numberFormat, numberOfHundreds.Description, hundred.Description);
        }
    }
}