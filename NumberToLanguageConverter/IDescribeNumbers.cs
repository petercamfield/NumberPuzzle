namespace NumberToLanguageConverter
{
    public interface IDescribeNumbers
    {
        LookupResult LookupNumber(int number);
        LookupResult LookupPositionalName(int number);
    }
}