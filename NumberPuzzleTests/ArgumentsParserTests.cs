using NumberPuzzle;
using NUnit.Framework;

namespace NumberPuzzleTests
{
    [TestFixture]
    public class ArgumentsParserTests
    {
        [Test]
        public void ParsingFailsWhenNoArgumentsSupplied()
        {
            var parser = new ArgumentsParser(new string[]{});
            Assert.That(parser.ParsedSuccessfully, Is.False);
        }

        [Test]
        public void ParsingSucceedsWhenValidArgumentIsSupplied()
        {
            var parser = new ArgumentsParser(new[] {"1"});
            Assert.That(parser.ParsedSuccessfully, Is.True);
        }

        [Test]
        public void ParsingFailsWhenInvalidArgumentIsSupplied()
        {
            var parser = new ArgumentsParser(new[] { "Invalid" });
            Assert.That(parser.ParsedSuccessfully, Is.False);
        }

        [Test]
        public void ParsingFailsWhenArgumentLessThanMinimumIsSupplied()
        {
            var parser = new ArgumentsParser(new[] { "0" });
            Assert.That(parser.ParsedSuccessfully, Is.False);
        }

        [Test]
        public void ParsingFailsWhenArgumentLargerThanMaximumIsSupplied()
        {
            var parser = new ArgumentsParser(new[] { "1000000000" });
            Assert.That(parser.ParsedSuccessfully, Is.False);
        }

        [Test]
        public void ParsedValueIsAvailableWhenValidArgumentsAreSupplied()
        {
            var parser = new ArgumentsParser(new[] { "1" });
            Assert.That(parser.ParsedValue, Is.EqualTo(1));
        }

    }
}