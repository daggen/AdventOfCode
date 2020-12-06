using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Utils;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day6
    {
        private const string FileNameInput = "../../Input/inputDay6.txt";
        public IEnumerable<string> Input => File.ReadLines(FileNameInput);

        [Fact]
        public void TestCountNUmberOfYes()
        {
            var totalCount = Input.Split("")
                                  .Select(ls => string.Join("", ls))
                                  .Select(answer => answer.Distinct())
                                  .Select(nbrOfAnswers => nbrOfAnswers.Count())
                                  .Sum();
            Assert.Equal(6170, totalCount);
        }

        [Fact]
        public void TestReadFile()
        {
            var count = Input.Split("").Select(l => l.Intersect().Count()).Sum();
            Assert.Equal(2947, count);
        }
    }
}
