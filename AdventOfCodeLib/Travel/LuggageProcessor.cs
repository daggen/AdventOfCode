using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeLib.Travel
{
    public class LuggageProcessor
    {
        private static readonly Regex s_Regex = new Regex("(.*?) bags contain( (\\d) (.*?) bags?,?)+");
        private static readonly Regex s_RegexNoInnerBags = new Regex(".*? bags contain no other bags.");
        
        private Dictionary<string, Bag> Bags { get; set; } = new Dictionary<string, Bag>();

        public void Add(string input)
        {
            if (s_RegexNoInnerBags.IsMatch(input)) return;
            
            var match = s_Regex.Match(input);
            if (!match.Success) throw new ArgumentException(input);

            var topBag = match.Groups[1];
            var numbersOfInnerBags = match.Groups[3].Captures;
            var innerBags = match.Groups[4].Captures;

            for (var i = 0; i < numbersOfInnerBags.Count; i++)
            {
                Add(topBag.ToString(), int.Parse(numbersOfInnerBags[i].ToString()), innerBags[i].ToString());
            }
        }

        private void Add(string topBag, int count, string innerBag)
        {
            var top = GetOrAddBag(topBag);
            var inner = GetOrAddBag(innerBag);

            top.AddInnerBag(count, inner);
        }

        private Bag GetOrAddBag(string topBag)
        {
            if (!Bags.TryGetValue(topBag, out var bag))
            {
                bag = new Bag(topBag);
                Bags.Add(topBag, bag);
            }

            return bag;
        }

        public int GetNumberOfBagsContaining(string bagColor)
        {
            var bag = Bags[bagColor];
            return Bags.Sum(b => b.Value.Contains(bag) ? 1 : 0);
        }

        public int GetNumberOfBagsIn(string bagColor) => Bags[bagColor].SumBags() - 1;
    }
}