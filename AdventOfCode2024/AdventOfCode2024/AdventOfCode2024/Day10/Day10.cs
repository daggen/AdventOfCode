namespace AdventOfCode2024.Day10;

public class Day10
{
    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day10/Input.txt")
            .Select(line => line.Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();

        var nodes = new List<Node>();

        for (var row = 0; row < lines.Length; row++)
        {
            for (int column = 0; column < lines[row].Length; column++)
            {
                nodes.Add(new Node(lines[row][column], row, column));
            }
        }

        foreach (var node in nodes)
        {
            var neighbours = nodes.Where(n =>
                (n.Column == node.Column && Math.Abs(n.Row - node.Row) == 1)
                || (n.Row == node.Row && Math.Abs(n.Column - node.Column) == 1))
                .ToList();
            node.AddNeighbours(neighbours);
        }

        var starts = nodes.Where(n => n.Value == 0);

        var sum = starts.Select(start => FindWayToEnd(start, new HashSet<Node>())).Sum();

        return sum.ToString();
    }

    private int FindWayToEnd(Node start, HashSet<Node> visitedNodes)
    {
        // if (!visitedNodes.Add(start))
        //     return 0;
        if (start.Value == 9)
            return 1;
        return start.AvailableNodes.Select(n => FindWayToEnd(n, visitedNodes)).Sum();
    }

    public class Node(
        int value, int row, int column)
    {
        private readonly List<Node> _neighbours = new();
        public int Row { get; } = row;
        public int Column { get; } = column;
        public int Value => value;
        public IEnumerable<Node> AvailableNodes => _neighbours.Where(n => n.Value == value + 1);

        public void AddNeighbours(List<Node> neighbours)
        {
            _neighbours.AddRange(neighbours);
        }
    }
}
