namespace AdventOfCodeLib.Matchers
{
    public class IntMatcher : IMatcher
    {
        public IntMatcher(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public virtual bool Match(string str)
        {
            return int.TryParse(str, out var i) && i <= Max && i >= Min;
        }

        public int Max { get; }

        public int Min { get; }
    }
}