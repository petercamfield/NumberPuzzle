using System;
using System.IO;
using NumberPuzzle;
using NUnit.Framework;

namespace NumberPuzzleTests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void ReturnsOne()
        {
            Assert.That(RunProgram(1), Is.EqualTo("one"));
        }

        [Test]
        public void ReturnsTwentyOne()
        {
            Assert.That(RunProgram(21), Is.EqualTo("twenty one"));
        }

        [Test]
        public void ReturnsOneHundredAndFive()
        {
            Assert.That(RunProgram(105), Is.EqualTo("one hundred and five"));
        }

        [Test]
        public void ReturnsFiftySixMillionNineHundredAndFortyFiveThousandSevenHundredAndEightyOne()
        {
            Assert.That(RunProgram(56945781), Is.EqualTo("fifty six million nine hundred and forty five thousand seven hundred and eighty one"));
        }

        [Test]
        public void ReturnsOneMillion()
        {
            Assert.That(RunProgram(1000000), Is.EqualTo("one million"));
        }

        [Test]
        public void ReturnsOneThousand()
        {
            Assert.That(RunProgram(1000), Is.EqualTo("one thousand"));
        }

        private static string RunProgram(int input)
        {
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);
            Program.Main(new[] {input.ToString()});
            return outputWriter.GetStringBuilder().ToString();
        }
    }
}