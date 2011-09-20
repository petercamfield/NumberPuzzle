using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumbersTests
    {
        private readonly IDescribeNumbers britishEnglishNumbers = new BritishEnglishNumbers();

        [Test]
        public void LooksUpOne()
        {
            Assert.That(britishEnglishNumbers.Lookup(1), Is.EqualTo("one"));
        }

        [Test]
        public void LooksUpTwo()
        {
            Assert.That(britishEnglishNumbers.Lookup(2), Is.EqualTo("two"));
        }

        [Test]
        public void LooksUpThree()
        {
            Assert.That(britishEnglishNumbers.Lookup(3), Is.EqualTo("three"));
        }

        [Test]
        public void LooksUpFour()
        {
            Assert.That(britishEnglishNumbers.Lookup(4), Is.EqualTo("four"));
        }

        [Test]
        public void LooksUpFive()
        {
            Assert.That(britishEnglishNumbers.Lookup(5), Is.EqualTo("five"));
        }
        
        [Test]
        public void LooksUpSix()
        {
            Assert.That(britishEnglishNumbers.Lookup(6), Is.EqualTo("six"));
        }
        
        [Test]
        public void LooksUpSeven()
        {
            Assert.That(britishEnglishNumbers.Lookup(7), Is.EqualTo("seven"));
        }

        [Test]
        public void LooksUpEight()
        {
            Assert.That(britishEnglishNumbers.Lookup(8), Is.EqualTo("eight"));
        }

        [Test]
        public void LooksUpNine()
        {
            Assert.That(britishEnglishNumbers.Lookup(9), Is.EqualTo("nine"));
        }

        [Test]
        public void LooksUpTen()
        {
            Assert.That(britishEnglishNumbers.Lookup(10), Is.EqualTo("ten"));
        }

        [Test]
        public void LooksUpEleven()
        {
            Assert.That(britishEnglishNumbers.Lookup(11), Is.EqualTo("eleven"));
        }

        [Test]
        public void LooksUpTwelve()
        {
            Assert.That(britishEnglishNumbers.Lookup(12), Is.EqualTo("twelve"));
        }

        [Test]
        public void LooksUpThirteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(13), Is.EqualTo("thirteen"));
        }

        [Test]
        public void LooksUpFourteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(14), Is.EqualTo("fourteen"));
        }

        [Test]
        public void LooksUpFifteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(15), Is.EqualTo("fifteen"));
        }

        [Test]
        public void LooksUpSixteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(16), Is.EqualTo("sixteen"));
        }

        [Test]
        public void LooksUpSeventeen()
        {
            Assert.That(britishEnglishNumbers.Lookup(17), Is.EqualTo("seventeen"));
        }

        [Test]
        public void LooksUpEighteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(18), Is.EqualTo("eighteen"));
        }

        [Test]
        public void LooksUpNineteen()
        {
            Assert.That(britishEnglishNumbers.Lookup(19), Is.EqualTo("nineteen"));
        }

        [Test]
        public void LooksUpTwenty()
        {
            Assert.That(britishEnglishNumbers.Lookup(20), Is.EqualTo("twenty"));
        }
    }

}