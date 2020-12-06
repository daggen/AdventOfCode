using System.Text.RegularExpressions;

namespace AdventOfCodeLib.Matchers
{
    public class RegexMatcher : IMatcher
    {
        private Regex Regex { get; }

        public RegexMatcher(string regex)
        {
            Regex = new Regex(regex);
        }

        public bool Match(string str) => Regex.IsMatch(str);
    }
}
