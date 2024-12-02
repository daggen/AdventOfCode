namespace AdventOfCode2024.Day1;

public class Day1
{
    public int GetDistance()
    {
        var left = new List<int>();
        var right = new List<int>();
        var lines = File.ReadLines("../../../Day1/Input.txt");
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[1]));

        }

        left.Sort();
        right.Sort();

        var distance = left.Zip(right, (l, r) => Math.Abs(l - r))
            .Sum();

        return distance;
    }
    public int GetSimilarity()
    {
        var left = new List<int>();
        var right = new List<int>();
        var lines = File.ReadLines("../../../Day1/Input.txt");
        foreach (var line in lines)
        {
            var numbers = line.Split("   ");
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[1]));

        }


        var similarity = left.Aggregate(0, (acc, v) => acc + v * right.Count(r => r == v));

        return similarity;
    }
}
