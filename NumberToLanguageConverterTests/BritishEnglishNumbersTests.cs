using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumbersTests
    {
        [Test]
        public void LooksUpOne()
        {
            Assert.That(new BritishEnglishNumbers().Lookup(1), Is.EqualTo("one"));
        }

    }
}