namespace NumberToLanguageConverter
{
    public class HundredsTensAndUnitsConversionStrategy : ConversionStrategy
    {
        public HundredsTensAndUnitsConversionStrategy(IDescribeNumbers numberDescriber) : base(numberDescriber)
        {
        }

        public override string Convert(HundredGroup hundredGroup)
        {
            var hundreds = new HundredsConversionStrategy(NumberDescriber).Convert(new HundredGroup(hundredGroup.Hundreds));
            var tensAndUnits = new TensAndUnitsConversionStrategy(NumberDescriber).Convert(new HundredGroup(hundredGroup.Tens + hundredGroup.Units));
            return Format(hundreds, tensAndUnits);
        }

        private static string Format(string hundreds, string tensAndUnits)
        {
            const string numberFormat = "{0} and {1}";
            return string.Format(numberFormat, hundreds, tensAndUnits);
        }
    }
}