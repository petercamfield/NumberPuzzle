using NumberToLanguageConverter;
using NUnit.Framework;
using Moq;
namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumberConverterTests
    {
        [Test]
        public void UsesDescribedNumbersForConversion()
        {
            var numberDescriber = new Mock<IDescribeNumbers>();
            var converter = new BritishEnglishNumberConverter(numberDescriber.Object);
            converter.Convert(1);
            numberDescriber.Verify(n=>n.Lookup(1));
        }
    }
}