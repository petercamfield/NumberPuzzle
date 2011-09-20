using NumberToLanguageConverter;
using NUnit.Framework;

namespace NumberToLanguageConverterTests
{
    [TestFixture]
    public class HundredGroupTests
    {
        [Test]
        public void HundredsTensAndUnitsAreZero()
        {
            var hundredGroup = new HundredGroup(0);
            Assert.That(hundredGroup.Hundreds, Is.EqualTo(0));
            Assert.That(hundredGroup.Tens, Is.EqualTo(0));
            Assert.That(hundredGroup.Units, Is.EqualTo(0));
        }

        [Test]
        public void UnitsAreOne()
        {
            var hundredGroup = new HundredGroup(321);
            Assert.That(hundredGroup.Units, Is.EqualTo(1));
        }

        [Test]
        public void TensAreTen()
        {
            var hundredGroup = new HundredGroup(610);
            Assert.That(hundredGroup.Tens, Is.EqualTo(10));
        }
        
        [Test]
        public void HundredsAreOneHundred()
        {
            var hundredGroup = new HundredGroup(147);
            Assert.That(hundredGroup.Hundreds, Is.EqualTo(100));
        }

    }
}