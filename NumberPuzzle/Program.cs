using System;
using NumberToLanguageConverter;

namespace NumberPuzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var argumentsParser = new ArgumentsParser(args);
            if (argumentsParser.ParsedSuccessfully)
            {
                var numberConverter = new NumberConverter();
                Console.WriteLine(numberConverter.Convert(argumentsParser.ParsedValue));
            }
        }
    }
}
