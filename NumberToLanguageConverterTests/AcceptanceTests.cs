using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture(Category="Acceptance")]
    public class AcceptanceTests
    {
        [Test]
        public void ReturnsOne()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(1), Is.EqualTo("one"));
        }

        [Test]
        public void ReturnsTwentyOne()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(21), Is.EqualTo("twenty one"));
        }

        [Test]
        public void ReturnsOneHundredAndFive()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(105), Is.EqualTo("one hundred and five"));
        }

        [Test]
        public void ReturnsFiftySixMillionNineHundredAndFortyFiveThousandSevenHundredAndEightyOne()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(56945781), Is.EqualTo("fifty six million nine hundred and forty five thousand seven hundred and eighty one"));
        }

        [Test]
        public void ReturnsOneMillion()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(1000000), Is.EqualTo("one million"));
        }

        [Test]
        public void ReturnsOneThousand()
        {
            Assert.That(new BritishEnglishNumberConverter().Convert(1000), Is.EqualTo("one thousand"));
        }
    }
}