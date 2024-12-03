using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public class Day3
{
    public int GetSum()
    {
        var lines = File.ReadLines("../../../Day2/Input.txt");

        var regex = new Regex("mul\\((\\d{1,3}),(\\d{1,3})\\)|do\\(\\)|don't\\(\\)");
        var sum = 0;
        var include = true;
        foreach (var line in lines)
        {
            var matches = regex.Matches(line);
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                if (include && match.ToString().StartsWith("mul"))
                    sum += int.Parse(match.Groups[1].ToString()) * int.Parse(match.Groups[2].ToString());
                else
                    include = match.ToString() == "do()";
            }
        }

        return sum;
    }

    private int CalculateLine(string arg)
    {
        var regex = new Regex("mul\\((\\d{1,3}),(\\d{1,3})\\)");
        var matches = regex.Matches(arg);
        var sum = 0;
        for (int i = 0; i < matches.Count; i++)
        {
            var match = matches[i];
            sum += int.Parse(match.Groups[1].ToString()) * int.Parse(match.Groups[2].ToString());
        }

        return sum;
    }
}
