namespace AdventOfCodeTest;

public class Day2
{
    public static string PuzzleInput
        => "9100-11052,895949-1034027,4408053-4520964,530773-628469,4677-6133,2204535-2244247,55-75,77-96,6855-8537,55102372-55256189,282-399,228723-269241,5874512-6044824,288158-371813,719-924,1-13,496-645,8989806846-8989985017,39376-48796,1581-1964,699387-735189,85832568-85919290,6758902779-6759025318,198-254,1357490-1400527,93895907-94024162,21-34,81399-109054,110780-153182,1452135-1601808,422024-470134,374195-402045,58702-79922,1002-1437,742477-817193,879818128-879948512,407-480,168586-222531,116-152,35-54";

    public static string SampleInput
        => "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\n824824821-824824827,2121212118-2121212124";

    [Theory]
    [MemberData(nameof(TestDataPartOne))]
    public void PartOne(long expected, string input)
    {
        var sum = input.Split(',')
            .Select(i => i.Split('-'))
            .Select(i => new Interval(long.Parse(i[0]), long.Parse(i[1])))
            .SelectMany(Range)
            .Where(str => str.ToString().Length % 2 == 0)
            .Where(i =>
            {
                var str = i.ToString();
                return str[..(str.Length / 2)] == str[(str.Length / 2)..];
            })
            .Sum();

        Assert.Equal(expected, sum);
    }

    public record Interval(
        long From,
        long To);

    public static IEnumerable<long> Range(Interval interval)
    {
        for(var i = interval.From; i <= interval.To; i++)
        {
            yield return i;
        }
    }

    public static IEnumerable<object[]> TestDataPartOne()
    {
        yield return [1227775554, SampleInput];
        yield return [18952700150, PuzzleInput];
    }

    [Theory]
    [MemberData(nameof(TestDataPartTwo))]
    public void PartTwo(long expected, string input)
    {
        var sum = input.Split(',')
            .Select(i => i.Split('-'))
            .Select(i => new Interval(long.Parse(i[0]), long.Parse(i[1])))
            .SelectMany(Range)
            .Select(FindInvalidIds2)
            .Sum();

        Assert.Equal(expected, sum);
    }

    private static long FindInvalidIds2(long i)
    {
        var sum = 0L;
        var str = i.ToString();

        for (var j = 1; j <= str.Length / 2; j++)
        {
            if (str.Length % j != 0)
                continue;
            var sub = str[..j];
            var ok = true;
            for (var k = 1; k < str.Length / j; k++)
            {
                var sub2 = str.Substring(k * j, j);
                if (sub != sub2)
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
            {
                sum += i;
                break;
            }
        }

        return sum;
    }

    public static IEnumerable<object[]> TestDataPartTwo()
    {
        yield return [4174379265, SampleInput];
        yield return [28858486244, PuzzleInput];
    }
}
