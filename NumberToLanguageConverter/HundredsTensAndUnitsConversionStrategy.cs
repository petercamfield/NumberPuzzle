namespace NumberToLanguageConverter
{
    public class HundredsTensAndUnitsConversionStrategy : ConversionStrategy
    {
        public HundredsTensAndUnitsConversionStrategy(IDescribeNumbers numberDescriber) : base(numberDescriber)
        {
        }

        public override string Convert(HundredGroup hundredGroup)
        {
            var hundreds = ConvertHundreds(hundredGroup);
            var tensAndUnits = ConvertTensAndUnits(hundredGroup);
            return Format(hundreds, NumberDescriber.Conjunction, tensAndUnits);
        }

        private string ConvertHundreds(HundredGroup hundredGroup)
        {
            var hundreds = new HundredGroup(hundredGroup.Hundreds);
            return GetConversionStrategy(hundreds).Convert(hundreds);
        }

        private string ConvertTensAndUnits(HundredGroup hundredGroup)
        {
            var tensAndUnits = new HundredGroup(hundredGroup.Tens + hundredGroup.Units);
            return GetConversionStrategy(tensAndUnits).Convert(tensAndUnits);
        }

        private ConversionStrategy GetConversionStrategy(HundredGroup hundredGroup)
        {
            var factory = new ConversionStrategyFactory(NumberDescriber);
            return factory.CreateConversionStrategy(hundredGroup);
        }

        private static string Format(string hundreds, string conjunction, string tensAndUnits)
        {
            const string numberFormat = "{0} {1} {2}";
            return string.Format(numberFormat, hundreds, conjunction, tensAndUnits);
        }
    }
}