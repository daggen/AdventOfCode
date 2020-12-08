using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLib.Computer;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day8
    {
        public IEnumerable<string> GetInput(string fileName) => File.ReadLines(fileName);

        [Theory]
        [InlineData("../../Input/inputDay8Small.txt", 5)]
        [InlineData("../../Input/inputDay8.txt", 1949)]
        public void Part1(string testData, int expectedValue)
        {
            var computer = new Computer(GetInput(testData));
            computer.Run();

            Assert.Equal(expectedValue, computer.Acc);
        }
        
        [Theory]
        [InlineData("../../Input/inputDay8Small.txt", 8)]
        [InlineData("../../Input/inputDay8.txt", 2092)]
        public void Part2(string testData, int expectedValue)
        {
            var computer = Computer.FindAWorkingComputer(GetInput(testData));

            Assert.Equal(expectedValue, computer.Acc);
        }
    }
}
