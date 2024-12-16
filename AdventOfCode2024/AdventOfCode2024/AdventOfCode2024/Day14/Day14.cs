using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day12;

public class Day14
{
    private const int Width = 101;
    private const int Height = 103;
    private const int iterations = 100;

    public string GetSum2()
    {
        var lines = File.ReadLines("../../../Day14/Input.txt")
            .Select(Parse)
            .Select(r => Move(r, 3000))
            .Select(Positive)
            .ToList();

        var count = 0;
        while (true)
        {
            lines = lines
                .Select(r => Move(r, 1))
                .Select(Positive)
                .ToList();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(lines.Any(r => r.x == j && r.y == i) ? "#" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(count++);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            //Console.ReadLine();
        }

        return "";
    }
    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day14/Input.txt")
            .Select(Parse)
            .Select(r => Move(r, iterations))
            .Select(Positive)
            .ToList();

        var q1 = lines.Count(r => r is { x: < Width / 2, y: < Height / 2 });
        var q2 = lines.Count(r => r is { x: > Width / 2, y: < Height / 2 });
        var q3 = lines.Count(r => r is { x: < Width / 2, y: > Height / 2 });
        var q4 = lines.Count(r => r is { x: > Width / 2, y: > Height / 2 });

        return $"{q1 * q2 * q3 * q4}";
    }

    private Robot Positive(Robot arg)
        => arg with {x = arg.x < 0 ? arg.x + Width : arg.x, y = arg.y < 0 ? arg.y + Height : arg.y};

    private Robot Move(Robot arg, int length)
        => arg with { x = (arg.x + arg.dx * length) % Width, y = (arg.y + arg.dy * length) % Height };

    private Robot Parse(string arg)
    {
        var regex = new Regex("p=(\\d+),(\\d+) v=(.+),(.+)");
        var match = regex.Match(arg);
        return new Robot(
            int.Parse(match.Groups[1].Value),
            int.Parse(match.Groups[2].Value),
            int.Parse(match.Groups[3].Value),
            int.Parse(match.Groups[4].Value));
    }

    private record Robot(
        int x,
        int y,
        int dx,
        int dy);

}
