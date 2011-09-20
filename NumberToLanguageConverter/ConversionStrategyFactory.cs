namespace NumberToLanguageConverter
{
    public class ConversionStrategyFactory
    {
        private readonly IDescribeNumbers numberDescriber;

        public ConversionStrategyFactory(IDescribeNumbers numberDescriber)
        {
            this.numberDescriber = numberDescriber;
        }

        public ConversionStrategy CreateConversionStrategy(HundredGroup hundredGroup)
        {
            if (HasHundredsAndTensOrUnits(hundredGroup))
                return new HundredsTensAndUnitsConversionStrategy(numberDescriber);
            if (HasHundreds(hundredGroup)) 
                return new HundredsConversionStrategy(numberDescriber);
            return new TensAndUnitsConversionStrategy(numberDescriber);
        }

        private static bool HasHundredsAndTensOrUnits(HundredGroup hundredGroup)
        {
            return HasHundreds(hundredGroup) && HasTensOrUnits(hundredGroup);
        }

        private static bool HasHundreds(HundredGroup hundredGroup)
        {
            return hundredGroup.Hundreds > 0;
        }

        private static bool HasTensOrUnits(HundredGroup hundredGroup)
        {
            return (hundredGroup.Tens + hundredGroup.Units) > 0;
        }
    }
}