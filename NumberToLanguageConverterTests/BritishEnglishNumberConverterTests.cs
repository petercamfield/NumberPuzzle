using NumberToLanguageConverter;
using NUnit.Framework;
using Moq;
namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumberConverterTests
    {
        [Test]
        public void AttemptsToLookUpNumberForConversion()
        {
            var numberDescriber = new Mock<IDescribeNumbers>();
            numberDescriber.Setup(n => n.Lookup(1)).Returns(new LookupResult("1"));
            var converter = new BritishEnglishNumberConverter(numberDescriber.Object);
            converter.Convert(1);
            numberDescriber.Verify(n=>n.Lookup(1));
        }
    }
}