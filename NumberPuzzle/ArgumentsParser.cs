using System.Collections.Generic;

namespace NumberPuzzle
{
    public class ArgumentsParser
    {
        private readonly bool parsedSuccessfully;

        public ArgumentsParser(IList<string> arguments)
        {
            parsedSuccessfully = arguments.Count == 1 && IsValid(arguments[0]);
        }

        private bool IsValid(string argument)
        {
            int result;
            var isInt =  int.TryParse(argument, out result);
            var isValid = isInt && result > 0 && result < 1000000000;
            if (isValid) ParsedValue = result;
            return isValid;
        }

        public bool ParsedSuccessfully
        {
            get { return parsedSuccessfully; }
        }

        public int ParsedValue { get; private set; }
    }
}