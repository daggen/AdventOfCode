using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Computer;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day9
    {
        public IEnumerable<long> GetInput(string fileName) => File.ReadLines(fileName).Select(i => long.Parse(i));

        [Theory]
        [InlineData("../../Input/inputDay9Small.txt", 127, 5)]
        [InlineData("../../Input/inputDay9.txt", 257342611, 25)]
        public void Part1(string testData, int expectedValue, int preamble)
        {
            var validator = new Validator(GetInput(testData));
            var firstNotValid = validator.FirstNotValid(preamble);
            Assert.Equal(expectedValue, firstNotValid);
        }

        [Theory]
        [InlineData("../../Input/inputDay9small.txt", 62, 5, 127)]
        [InlineData("../../Input/inputDay9.txt", 35602097, 25, 257342611)]
        public void Part2(string testData, int expectedValue, int preamble, int key)
        {
            var validator = new Validator(GetInput(testData).Where(w => w < key));
            var findKey = validator.FindKey(key);

            Assert.Equal(expectedValue, findKey);
        }
    }

    internal class Validator
    {
        public Validator(IEnumerable<long> take)
        {
            Numbers = take.ToList();
        }

        public List<long> Numbers { get; set; }

        public long FirstNotValid(int preamble)
        {
            var list = Numbers.Take(preamble).ToList();
            return Numbers.Skip(preamble).First(n => !AddToList(n, list));
        }

        private static bool AddToList(long number, List<long> list)
        {
            var noHits = list.SelectMany((first, index) => Enumerable.Range(index + 1, list.Count - index - 1)
                                                            .Select(second => first + list[second] != number))
                             .All(b => b);
            if (noHits) return false;

            list.RemoveAt(0);
            list.Add(number);
            return true;
        }

        public long FindKey(int key)
        {
            var result = Numbers.SelectMany((value, index) => 
                                                Enumerable.Range(2, Numbers.Count - index)
                                                          .Select(size => Numbers.Skip(index).Take(size)))
                                                          .First(range => range.Sum() == key)
                                                          .ToList();
            return result.Min() + result.Max();
        }
    }
}
