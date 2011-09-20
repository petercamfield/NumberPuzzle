namespace NumberToLanguageConverter
{
    public interface IDescribeNumbers
    {
        LookupResult LookupNumber(int number);
        LookupResult LookupPowerOfTen(int powerOfTen);
    }
}