namespace AdventOfCodeLib.Matchers
{
    public class IntWithUnitMatcher : IntMatcher
    {
        public IntWithUnitMatcher(string unit, int min, int max) : base(min, max)
        {
            Unit = unit;
        }

        public override bool Match(string str)
        {
            var value = str.Substring(0, str.Length - Unit.Length);
            var unit = str.Substring(value.Length);

            return base.Match(value) && unit == Unit;
        }

        public string Unit { get; }
    }
}