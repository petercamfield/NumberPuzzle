using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumbersTests
    {
        private readonly IDescribeNumbers britishEnglishNumbers = new BritishEnglishNumbers();

        private void AssertLookupEquals(int number, string description)
        {
            var lookupResult = britishEnglishNumbers.Lookup(number);
            Assert.That(lookupResult.Description, Is.EqualTo(description));
            Assert.That(lookupResult.Found, Is.True);
        }

        [Test]
        public void LooksUpOne()
        {
            AssertLookupEquals(1, "one");
        }

        [Test]
        public void LooksUpTwo()
        {
            AssertLookupEquals(2, "two");
        }

        [Test]
        public void LooksUpThree()
        {
            AssertLookupEquals(3, "three");
        }

        [Test]
        public void LooksUpFour()
        {
            AssertLookupEquals(4, "four");
        }

        [Test]
        public void LooksUpFive()
        {
            AssertLookupEquals(5, "five");
        }
        
        [Test]
        public void LooksUpSix()
        {
            AssertLookupEquals(6, "six");
        }
        
        [Test]
        public void LooksUpSeven()
        {
            AssertLookupEquals(7, "seven");
        }

        [Test]
        public void LooksUpEight()
        {
            AssertLookupEquals(8, "eight");
        }

        [Test]
        public void LooksUpNine()
        {
            AssertLookupEquals(9, "nine");
        }

        [Test]
        public void LooksUpTen()
        {
            AssertLookupEquals(10, "ten");
        }

        [Test]
        public void LooksUpEleven()
        {
            AssertLookupEquals(11, "eleven");
        }

        [Test]
        public void LooksUpTwelve()
        {
            AssertLookupEquals(12, "twelve");
        }

        [Test]
        public void LooksUpThirteen()
        {
            AssertLookupEquals(13, "thirteen");
        }

        [Test]
        public void LooksUpFourteen()
        {
            AssertLookupEquals(14, "fourteen");
        }

        [Test]
        public void LooksUpFifteen()
        {
            AssertLookupEquals(15, "fifteen");
        }

        [Test]
        public void LooksUpSixteen()
        {
            AssertLookupEquals(16, "sixteen");
        }

        [Test]
        public void LooksUpSeventeen()
        {
            AssertLookupEquals(17, "seventeen");
        }

        [Test]
        public void LooksUpEighteen()
        {
            AssertLookupEquals(18, "eighteen");
        }

        [Test]
        public void LooksUpNineteen()
        {
            AssertLookupEquals(19, "nineteen");
        }

        [Test]
        public void LooksUpTwenty()
        {
            AssertLookupEquals(20, "twenty");
        }

        [Test]
        public void LooksUpThirty()
        {
            AssertLookupEquals(30, "thirty");
        }

        [Test]
        public void LooksUpFourty()
        {
            AssertLookupEquals(40, "fourty");
        }

        [Test]
        public void LooksUpFifty()
        {
            AssertLookupEquals(50, "fifty");
        }

        [Test]
        public void LooksUpSixty()
        {
            AssertLookupEquals(60, "sixty");
        }

        [Test]
        public void LooksUpSeventy()
        {
            AssertLookupEquals(70, "seventy");
        }

        [Test]
        public void LooksUpEighty()
        {
            AssertLookupEquals(80, "eighty");
        }
        
        [Test]
        public void LooksUpNinety()
        {
            AssertLookupEquals(90, "ninety");
        }

        [Test]
        public void ReturnsNotFoundLookupResult()
        {
            Assert.That(britishEnglishNumbers.Lookup(-1), Is.EqualTo(LookupResult.NotFound));
        }
    }

}