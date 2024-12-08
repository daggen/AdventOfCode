namespace AdventOfCode2024.Day8;

public class Day8
{
    const int matrixSize = 50;
    public string GetSum1()
    {
        var lines = File
            .ReadLines("../../../Day8/Input.txt")
            .Select((line, row) =>
                line.Select((value, column) => new Position(column, row, value)))
            .SelectMany(x => x)
            .Where(p => p.Value != '.')
            .ToList();

        var result = lines.Join(
                lines,
                p => p.Value,
                p => p.Value,
                GetAntiNode)
            .SelectMany(x => x)
            .Distinct()
            .ToList();

        for (var i = 0; i < matrixSize; i++)
        {
            for(var j = 0; j < matrixSize; j++)
            {
                var p = new Position(j, i, ' ');
                if (result.Contains(p))
                {
                    Console.Write('X');
                }
                else
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
        }

        return result.Count().ToString();
    }

    private IEnumerable<Position> GetAntiNode(Position arg1, Position arg2)
    {
        if (Equals(arg1, arg2))
            yield break;

        var diffX = arg1.X - arg2.X;
        var diffY = arg1.Y - arg2.Y;

        var move = new Position(diffX, diffY, ' ');
        arg1 = arg2.Move(move);

        while (arg1.IsWithinGrid)
        {
            yield return arg1;
            arg1 = arg1.Move(move);
        }

        move = new Position(-diffX, -diffY, ' ');
        arg2 = arg2.Move(move);
        while (arg2.IsWithinGrid)
        {
            yield return arg2;
            arg2 = arg2.Move(move);
        }
    }

    private class Position(
        int x,
        int y,
        char value)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public char Value { get; } = value;

        public bool IsWithinGrid
        {
            get
            {
                return this is { X: >= 0, X: < matrixSize, Y: >= 0, Y: < matrixSize };
            }
        }

        public Position Move(Position distance) => new(X + distance.X, Y + distance.Y, ' ');

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y && Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Value);
        }
    }
}
