namespace NumberToLanguageConverter
{
    public class TensAndUnitsConversionStrategy : ConversionStrategy
    {
        
        public TensAndUnitsConversionStrategy(IDescribeNumbers numberDescriber) : base(numberDescriber)
        {
        }

        public override string Convert(HundredGroup hundredGroup)
        {
            var lookupResult = NumberDescriber.LookupNumber(hundredGroup.Number);
            if (lookupResult.Found) return lookupResult.Description;

            var tens = NumberDescriber.LookupNumber(hundredGroup.Tens);
            var units = NumberDescriber.LookupNumber(hundredGroup.Units);
            return Format(tens, units);
        }

        private static string Format(LookupResult tens, LookupResult units)
        {
            const string numberFormat = "{0} {1}";
            return string.Format(numberFormat, tens.Description, units.Description);
        }
    }
}