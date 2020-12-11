using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day10
    {
        public IEnumerable<int> GetInput(string fileName) => File.ReadLines(fileName).Select(i => int.Parse(i));

        [Theory]
        [InlineData("../../Input/inputDay10Small.txt", 220)]
        [InlineData("../../Input/inputDay10.txt", 2590)]
        public void Part1(string testData, int expected)
        {
            var input = GetInput(testData).OrderBy(i => i).ToList();
            var input2 = input.Prepend(0).Append(input.Max() + 3).ToList();

            var actual = input2.Zip(input2.Skip(1), (i, i1) => i - i1).GroupBy(i => i)
                  .Aggregate(1, (current, next) => current * next.Count());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("../../Input/inputDay10Small.txt", 19208)]
        [InlineData("../../Input/inputDay10.txt", 226775649501184)]
        public void Part2(string testData, long expected)
        {
            var input = GetInput(testData).OrderBy(i => i).Prepend(0).ToList();

            var actual = GetNumberOfValidInputs(input);
            Assert.Equal(expected, actual);
        }

        private long GetNumberOfValidInputs(List<int> input)
        {
            var result = new long[input.Count];
            result[input.Count - 1] = 1;
            for (var i = input.Count - 1; i > 0; i--)
            {
                var nbr = input.Skip(i).Count(j => j -  input[i - 1] <= 3);
                result[i - 1] = result.Skip(i).Take(nbr).Sum();
            }

            return result.First();
        }
    }
}
