namespace NumberToLanguageConverter
{
    public interface IDescribeNumbers
    {
        LookupResult Lookup(int number);
    }
}