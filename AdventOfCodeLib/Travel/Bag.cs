using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLib.Travel
{
    public class Bag
    {
        public string Name { get; }
        private Dictionary<Bag, int> InnerBags { get; } = new Dictionary<Bag, int>();
        
        public Bag(string name)
        {
            Name = name;
        }

        public void AddInnerBag(int count, Bag inner)
        {
            InnerBags.Add(inner, count);
        }

        public override bool Equals(object obj) => obj is Bag bag && Name == bag.Name;

        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        public bool Contains(Bag bag)
        {
            return InnerBags.ContainsKey(bag) || InnerBags.Any(innerBag => innerBag.Key.Contains(bag));
        }

        public int SumBags() => 1 + InnerBags.Sum(b => b.Key.SumBags() * b.Value);
    }
}