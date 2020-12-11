using System.Collections.Generic;
using System.IO;
using AdventOfCodeLib.Travel;
using Xunit;

namespace AdventOfCodeTest.Archive
{
    public class Day7
    {
        private const string FileNameInput = "../../Input/inputDay7.txt";
        public IEnumerable<string> Input => File.ReadLines(FileNameInput);

        [Fact]
        public void TestNumberOfBagsContainShinyGold()
        {
            var luggageProcessor = new LuggageProcessor();

            foreach (var line in Input)
            {
                luggageProcessor.Add(line);
            }

            var count = luggageProcessor.GetNumberOfBagsContaining("shiny gold");
            Assert.Equal(142, count);
        }

        [Fact]
        public void TestNumberOfBagsInAShinyGold()
        {
            var luggageProcessor = new LuggageProcessor();

            foreach (var line in Input)
            {
                luggageProcessor.Add(line);
            }

            var count = luggageProcessor.GetNumberOfBagsIn("shiny gold");
            Assert.Equal(10219, count);
        }
    }
}
