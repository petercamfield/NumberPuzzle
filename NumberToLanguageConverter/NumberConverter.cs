namespace NumberToLanguageConverter
{
    public class NumberConverter : IConvertNumbers
    {
        private readonly ConversionStrategyFactory factory;

        public NumberConverter(): this(new BritishEnglishNumbers())
        {
        }

        public NumberConverter(IDescribeNumbers numberDescriber)
        {
            factory = new ConversionStrategyFactory(numberDescriber);
        }

        public string Convert(int number)
        {
            var hundredGroup = new HundredGroup(number);
            var converter = factory.CreateConversionStrategy(hundredGroup);
            return converter.Convert(hundredGroup);
        }
    }
}