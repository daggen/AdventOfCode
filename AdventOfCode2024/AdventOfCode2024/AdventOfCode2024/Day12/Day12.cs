namespace AdventOfCode2024.Day12;

public class Day12
{
    public string GetSum2()
    {
        var matrix = File.ReadLines("../../../Day12/Input.txt")
            .Select((line, row) => line.Select((type, column) => (row, column, type)))
            .SelectMany(x => x)
            .GroupBy(c => c.type)
            .ToList();

        var regions = new List<List<(int row, int column, char type)>>();
        foreach (var group in matrix)
        {
            var picked = new HashSet<(int, int, char)>();
            foreach (var plant in group.Where(p => !picked.Contains(p)))
            {
                picked.Add(plant);
                regions.Add(GetNeighbours(plant, group.AsEnumerable(), picked).ToList());
            }
        }

        var sum = 0;
        foreach (var region in regions)
        {
            var type = region[0].type;
            var upperLeft = region.Count(p => !region.Any(p2 => p.row == p2.row - 1 && p.column == p2.column)
                                              && !region.Any(p2 => p.row == p2.row && p.column == p2.column - 1));
            var upperRight = region.Count(p => !region.Any(p2 => p.row == p2.row - 1 && p.column == p2.column)
                                               && !region.Any(p2 => p.row == p2.row && p.column == p2.column + 1));
            var downLeft = region.Count(p => !region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column)
                                             && !region.Any(p2 => p.row == p2.row && p.column == p2.column - 1));
            var downRight = region.Count(p => !region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column)
                                              && !region.Any(p2 => p.row == p2.row && p.column == p2.column + 1));

            var diag = region.Count(p => region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column + 1)
                && region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column)
                ^ region.Any(p2 => p.row == p2.row && p.column == p2.column + 1));

            var diag2 = region.Count(p => region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column - 1)
                && region.Any(p2 => p.row == p2.row + 1 && p.column == p2.column)
                ^ region.Any(p2 => p.row == p2.row && p.column == p2.column - 1));

            int cost = upperLeft + upperRight + downLeft + downRight + diag + diag2;
            cost *= region.Count;
            Console.WriteLine($"Region: {type}, cost: {cost}");
            sum += cost;
        }


        return sum.ToString();
        // 569489 To low
    }

    private int IsLowerRight((int row, int column, char type) p, List<(int row, int column, char type)> plants)
    {
        return plants.Where(p2 => p != p2)
            .Any(p2 => (p.row == p2.row + 1 && p.column == p2.column) || (p.row == p2.row && p.column == p2.column + 1))
            ? 0
            : 1;
    }

    public string GetSum1()
    {
        var matrix = File.ReadLines("../../../Day12/Input.txt")
            .Select((line, row) => line.Select((type, column) => (row, column, type)))
            .SelectMany(x => x)
            .GroupBy(c => c.type)
            .ToList();

        var regions = new List<List<(int row, int column, char type)>>();
        foreach (var group in matrix)
        {
            var picked = new HashSet<(int, int, char)>();
            foreach (var plant in group.Where(p => !picked.Contains(p)))
            {
                picked.Add(plant);
                regions.Add(GetNeighbours(plant, group.AsEnumerable(), picked).ToList());
            }
        }

        return regions.Sum(r => r.Count * r.Sum(p =>
            4 - r.Count(p2 =>
                Math.Abs(p2.column - p.column) +
                Math.Abs(p.row - p2.row) == 1))).ToString();
    }

    private IEnumerable<(int row, int column, char type)> GetNeighbours(
        (int row, int column, char type) plant,
        IEnumerable<(int row, int column, char type)> group,
        HashSet<(int, int, char)> picked)
    {
        picked.Add(plant);
        return group.Where(g
                => Math.Abs(g.column - plant.column) + Math.Abs(g.row - plant.row) == 1 && !picked.Contains(g))
            .SelectMany(g => GetNeighbours(g, group, picked))
            .Append(plant);
    }
}
