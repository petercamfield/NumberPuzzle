namespace NumberToLanguageConverter
{
    public class NumberConverter : IConvertNumbers
    {
        private readonly IDescribeNumbers numberDescriber;

        public NumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        public NumberConverter(IDescribeNumbers numberDescriber)
        {
            this.numberDescriber = numberDescriber;
        }

        public string Convert(int number)
        {
            var hundredGroup = new HundredGroup(number);
            var converter = GetConversionStrategy(hundredGroup, numberDescriber);
            return converter.Convert(hundredGroup);
        }

        private static ConversionStrategy GetConversionStrategy(HundredGroup hundredGroup, IDescribeNumbers numberDescriber)
        {
            if (HasHundreds(hundredGroup) && HasTensOrUnits(hundredGroup))
                return new HundredsTensAndUnitsConversionStrategy(numberDescriber);
            if (HasHundreds(hundredGroup)) return new HundredsConversionStrategy(numberDescriber);
            return new TensAndUnitsConversionStrategy(numberDescriber);
        }

        private static bool HasTensOrUnits(HundredGroup hundredGroup)
        {
            return (hundredGroup.Tens + hundredGroup.Units) > 0;
        }

        private static bool HasHundreds(HundredGroup hundredGroup)
        {
            return hundredGroup.Hundreds > 0;
        }
    }
}