namespace NumberToLanguageConverter
{
    public abstract class ConversionStrategy
    {
        protected readonly IDescribeNumbers NumberDescriber;

        protected ConversionStrategy(IDescribeNumbers numberDescriber)
        {
            NumberDescriber = numberDescriber;
        }

        public abstract string Convert(HundredGroup hundredGroup);
    }
}