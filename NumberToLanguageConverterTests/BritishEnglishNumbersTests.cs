using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class BritishEnglishNumbersTests
    {
        private readonly IDescribeNumbers britishEnglishNumbers = new BritishEnglishNumbers();

        private void AssertLookupNumberEquals(int number, string description)
        {
            var lookupResult = britishEnglishNumbers.LookupNumber(number);
            Assert.That(lookupResult.Description, Is.EqualTo(description));
            Assert.That(lookupResult.Found, Is.True);
        }

        [Test]
        public void LooksUpOne()
        {
            AssertLookupNumberEquals(1, "one");
        }

        [Test]
        public void LooksUpTwo()
        {
            AssertLookupNumberEquals(2, "two");
        }

        [Test]
        public void LooksUpThree()
        {
            AssertLookupNumberEquals(3, "three");
        }

        [Test]
        public void LooksUpFour()
        {
            AssertLookupNumberEquals(4, "four");
        }

        [Test]
        public void LooksUpFive()
        {
            AssertLookupNumberEquals(5, "five");
        }
        
        [Test]
        public void LooksUpSix()
        {
            AssertLookupNumberEquals(6, "six");
        }
        
        [Test]
        public void LooksUpSeven()
        {
            AssertLookupNumberEquals(7, "seven");
        }

        [Test]
        public void LooksUpEight()
        {
            AssertLookupNumberEquals(8, "eight");
        }

        [Test]
        public void LooksUpNine()
        {
            AssertLookupNumberEquals(9, "nine");
        }

        [Test]
        public void LooksUpTen()
        {
            AssertLookupNumberEquals(10, "ten");
        }

        [Test]
        public void LooksUpEleven()
        {
            AssertLookupNumberEquals(11, "eleven");
        }

        [Test]
        public void LooksUpTwelve()
        {
            AssertLookupNumberEquals(12, "twelve");
        }

        [Test]
        public void LooksUpThirteen()
        {
            AssertLookupNumberEquals(13, "thirteen");
        }

        [Test]
        public void LooksUpFourteen()
        {
            AssertLookupNumberEquals(14, "fourteen");
        }

        [Test]
        public void LooksUpFifteen()
        {
            AssertLookupNumberEquals(15, "fifteen");
        }

        [Test]
        public void LooksUpSixteen()
        {
            AssertLookupNumberEquals(16, "sixteen");
        }

        [Test]
        public void LooksUpSeventeen()
        {
            AssertLookupNumberEquals(17, "seventeen");
        }

        [Test]
        public void LooksUpEighteen()
        {
            AssertLookupNumberEquals(18, "eighteen");
        }

        [Test]
        public void LooksUpNineteen()
        {
            AssertLookupNumberEquals(19, "nineteen");
        }

        [Test]
        public void LooksUpTwenty()
        {
            AssertLookupNumberEquals(20, "twenty");
        }

        [Test]
        public void LooksUpThirty()
        {
            AssertLookupNumberEquals(30, "thirty");
        }

        [Test]
        public void LooksUpFourty()
        {
            AssertLookupNumberEquals(40, "fourty");
        }

        [Test]
        public void LooksUpFifty()
        {
            AssertLookupNumberEquals(50, "fifty");
        }

        [Test]
        public void LooksUpSixty()
        {
            AssertLookupNumberEquals(60, "sixty");
        }

        [Test]
        public void LooksUpSeventy()
        {
            AssertLookupNumberEquals(70, "seventy");
        }

        [Test]
        public void LooksUpEighty()
        {
            AssertLookupNumberEquals(80, "eighty");
        }
        
        [Test]
        public void LooksUpNinety()
        {
            AssertLookupNumberEquals(90, "ninety");
        }

        [Test]
        public void LooksUpHundredByPosition()
        {
            Assert.That(britishEnglishNumbers.LookupPositionalName(100).Description, Is.EqualTo("hundred"));
        }

        [Test]
        public void ReturnsNotFoundLookupResult()
        {
            Assert.That(britishEnglishNumbers.LookupNumber(-1), Is.EqualTo(LookupResult.NotFound));
        }
    }

}