
namespace AdventOfCode2024.Day5;

public class Day5
{
    public int GetSum1()
    {
        var lines = File.ReadLines("../../../Day5/Input.txt").ToList();
        var rules = lines.TakeWhile(row => !string.IsNullOrWhiteSpace(row)).ToList();

        var valueTuples = rules.Select(rule => rule.Split('|'))
            .Select(r => new
            {
                From = int.Parse(r[0]),
                To = int.Parse(r[1]),
            })
            .GroupBy(r => r.From, t => t.To)
            .ToDictionary(r => r.Key, m => m.ToList());

        var updates = lines.Skip(rules.Count + 1)
            .Select(r => r.Split(",").Select(int.Parse).ToArray())
            .Where(r => IsCorrect(r, valueTuples))
            .Select(r => r[r.Length/2])
            .Sum();

        return updates;
    }
    public int GetSum2()
    {
        var lines = File.ReadLines("../../../Day5/Input.txt").ToList();
        var rules = lines.TakeWhile(row => !string.IsNullOrWhiteSpace(row)).ToList();

        var valueTuples = rules.Select(rule => rule.Split('|'))
            .Select(r => new
            {
                From = int.Parse(r[0]),
                To = int.Parse(r[1]),
            })
            .GroupBy(r => r.From, t => t.To)
            .ToDictionary(r => r.Key, m => m.ToList());

        var updates = lines.Skip(rules.Count + 1)
            .Select(r => r.Split(",").Select(int.Parse).ToArray())
            .Where(r => !IsCorrect(r, valueTuples))
            .Select(r => FixOrder(r, valueTuples))
            .Select(r => r[r.Length/2])
            .Sum();

        return updates;
    }

    private int[] FixOrder(int[] ints, Dictionary<int, List<int>> valueTuples)
    {
        return ints.OrderBy(i => valueTuples[i].Intersect(ints).Count()).ToArray();
    }

    private bool IsCorrect(int[] arg, Dictionary<int, List<int>> valueTuples)
    {
        var picked = new HashSet<int>();
        foreach (var num in arg)
        {
            var fromRules = valueTuples.TryGetValue(num, out var rules) ? rules : Enumerable.Empty<int>();
            if (fromRules.Any(r => picked.Contains(r)))
            {
                return false;
            }

            picked.Add(num);
        }

        return true;
    }
}
