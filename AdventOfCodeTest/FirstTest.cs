using Xunit;
using Xunit.Abstractions;

namespace AdventOfCodeTest
{
    public class FirstTest
    {
        public FirstTest(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; set; }

        [Fact]
        public void TestMethod()
        {
            Assert.True(true);
        }
    }
}
