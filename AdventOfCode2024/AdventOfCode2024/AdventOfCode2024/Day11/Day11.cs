using System.Collections.Concurrent;
using System.Numerics;

namespace AdventOfCode2024.Day11;

public class Day11
{
    public string GetSum2()
    {
        var lines = File.ReadLines("../../../Day11/Input.txt").First().Split(" ")
            .Select(AsStone);

        var sum = lines.Select(s => s.Blink(75)).Aggregate((acc, i) => acc + i);

        return sum.ToString();
    }

    private Stone AsStone(string arg)
    {
        return new Stone(arg);
    }

    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day11/Input.txt").First().Split(" ")
            .Select(AsStone);

        var stones = new List<Stone>(lines);
        for (var i = 0; i < 75; i++)
        {
            Console.WriteLine($"Iteration {i + 1}: {stones.Count}");
            stones = stones.AsParallel().Select(stone => stone.Blink())
                .SelectMany(x => x)
                .ToList();
        }

        return stones.Count.ToString();
    }
}

internal class Stone(string value)
{
    public IEnumerable<Stone> Blink()
    {
        if (value == "0")
            return [new Stone("1")];
        if (value.Length % 2 == 0)
        {
            var secondHalf = value[(value.Length / 2)..].TrimStart('0');
            secondHalf = string.IsNullOrWhiteSpace(secondHalf) ? "0" : secondHalf;
            return
            [
                new Stone(value[..(value.Length / 2)]),
                new Stone(secondHalf)
            ];
        }

        return [new Stone((BigInteger.Parse(value) * 2024).ToString())];
    }

    public override string ToString()
    {
        return value;
    }

    public BigInteger Blink(int times)
    {
        if (times == 0)
            return 1;

        return _cache.GetOrAdd((times, value), t => Blink().Select(s => s.Blink(t.level - 1))
            .Aggregate(new BigInteger(0), (acc, i) => acc + i));
    }

    private static ConcurrentDictionary<(int level, string value), BigInteger> _cache = new();
}
