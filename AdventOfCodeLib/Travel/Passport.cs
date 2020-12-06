using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCodeLib.Matchers;

namespace AdventOfCodeLib.Travel
{
    public class Passport
    {
        public Dictionary<string, string> Fields { get; set; }

        public Passport(string text)
        {
            Fields = text.Split(' ')
                       .Where(w => !string.IsNullOrWhiteSpace(w))
                       .Select(s => s.Split(':'))
                       .ToDictionary(s => s[0], s => s[1]);
        }

        public static IEnumerable<Passport> ParsePassports(List<string> input)
        {
            foreach (var passport in input)
            {
                yield return new Passport(passport);
            }
        }
    }
}
