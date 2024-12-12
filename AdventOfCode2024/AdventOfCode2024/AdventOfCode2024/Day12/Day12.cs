namespace AdventOfCode2024.Day12;

public class Day12
{

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
        return group.Where(g => Math.Abs(g.column - plant.column) + Math.Abs(g.row - plant.row) == 1 && !picked.Contains(g))
            .SelectMany(g => GetNeighbours(g, group, picked))
            .Append(plant);
    }
}
