namespace NumberToLanguageConverter
{
    public class LookupResult
    {
        private readonly string description;
        private readonly bool found;

        public LookupResult(string description): this(description, true)
        {
        }

        private LookupResult(string description, bool found)
        {
            this.description = description;
            this.found = found;
        }

        public bool Found
        {
            get { return found; }
        }

        public string Description
        {
            get { return description; }
        }
        
        private static readonly LookupResult NotFoundLookupResult = new LookupResult(string.Empty, false);

        public static LookupResult NotFound
        {
            get { return NotFoundLookupResult; }
        }
    }
}