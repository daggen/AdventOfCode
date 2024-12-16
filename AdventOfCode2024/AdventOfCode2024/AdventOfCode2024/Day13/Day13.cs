using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day12;

public class Day13
{
    public string GetSum2()
    {
        var lines = File.ReadLines("../../../Day13/Input.txt").GetEnumerator();
        var machines = new List<Machine>();
        while (lines.MoveNext())
        {
            var regex = new Regex("\\d+");
            var buttonANum = regex.Matches(lines.Current);
            var valueX = int.Parse(buttonANum[0].Value);
            var valueY = int.Parse(buttonANum[1].Value);

            var buttonA = new Button(valueX, valueY, 3);

            lines.MoveNext();
            buttonANum = regex.Matches(lines.Current);
            valueX = int.Parse(buttonANum[0].Value);
            valueY = int.Parse(buttonANum[1].Value);
            var buttonB = new Button(valueX, valueY, 1);

            lines.MoveNext();
            var prizeNum = regex.Matches(lines.Current);
            valueX = int.Parse(prizeNum[0].Value);
            valueY = int.Parse(prizeNum[1].Value);
            var prize = new Prize(valueX + 10_000_000_000_000, valueY + 10000000000000);

            var machine = new Machine(buttonA, buttonB, prize);
            machines.Add(machine);

            lines.MoveNext();
        }

        var cost = machines.AsParallel().Sum(m => m.Solve());

        return cost.ToString();
    }

    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day13/Input.txt").GetEnumerator();
        var machines = new List<Machine>();
        while (lines.MoveNext())
        {
            var regex = new Regex("\\d+");
            var buttonANum = regex.Matches(lines.Current);
            var valueX = int.Parse(buttonANum[0].Value);
            var valueY = int.Parse(buttonANum[1].Value);

            var buttonA = new Button(valueX, valueY, 3);

            lines.MoveNext();
            buttonANum = regex.Matches(lines.Current);
            valueX = int.Parse(buttonANum[0].Value);
            valueY = int.Parse(buttonANum[1].Value);
            var buttonB = new Button(valueX, valueY, 1);

            lines.MoveNext();
            var prizeNum = regex.Matches(lines.Current);
            valueX = int.Parse(prizeNum[0].Value);
            valueY = int.Parse(prizeNum[1].Value);
            var prize = new Prize(valueX, valueY);

            var machine = new Machine(buttonA, buttonB, prize);
            machines.Add(machine);

            lines.MoveNext();
        }

        var cost = machines.Sum(m => m.Solve());

        return cost.ToString();
    }

    private class Machine(Button buttonA, Button buttonB, Prize prize)
    {
        public long Solve()
        {
            var minimumCost = 0L;
            var gcd = GCD(buttonA.X, prize.X);
            for (var a = 0L; a <= Math.Min(prize.X / buttonA.X, prize.Y / buttonA.Y); a += gcd)
            {
                var leftX = prize.X - buttonA.X * a;
                var leftY = prize.Y - buttonA.Y * a;

                var b = leftX / buttonB.X;

                if (b * buttonB.X == leftX && b * buttonB.Y == leftY)
                {
                    var cost = a * buttonA.Cost + b * buttonB.Cost;
                    if (minimumCost == 0 || cost < minimumCost)
                    {
                        minimumCost = cost;
                    }
                }
            }

            Console.WriteLine(minimumCost);
            return minimumCost;
        }

        private static long GCD(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }

    private record Button(
        int X,
        int Y,
        int Cost)
    {

    }

    private record Prize(
        long X,
        long Y);
}
