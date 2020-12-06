using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Matchers
{
    public interface IMatcher
    {
        bool Match(string str);
    }

    public class CombinedAnyMatcher : IMatcher
    {
        private IEnumerable<IMatcher> Matchers { get; }

        public CombinedAnyMatcher(params IMatcher[] matchers)
        {
            Matchers = matchers;
        }
        public bool Match(string str) => Matchers.Any(matcher => matcher.Match(str));
    }
}