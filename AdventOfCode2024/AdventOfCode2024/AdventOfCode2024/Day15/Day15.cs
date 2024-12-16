using System.Text;

namespace AdventOfCode2024.Day15;

public class Day15
{
    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day15/Input.txt")
            .ToList();

        var enumerable = lines.TakeWhile(l => !string.IsNullOrWhiteSpace(l)).ToList();
        var maze = new Maze(enumerable
            .Select((line, row) => line.Select((c, column) => new Node(column, row, c)))
            .SelectMany(x => x)
            .ToList());

        var instructions = lines.Skip(enumerable.Count).SelectMany(x => x);

        foreach (var instruction in instructions)
        {
            maze.MoveRobot(instruction);
        }

        // To low 74041
        return maze.SumOfAllBoxes().ToString();
    }

    private class Maze
    {
        private readonly List<Node> _nodes;
        private Position _robotPosition;

        public Maze( List<Node> nodes)
        {
            _nodes = nodes;
            var node = nodes.First(n => n.IsRobot);
            _nodes.Remove(node);
            _nodes.Add(new Node(node.X, node.Y, '.'));
            _robotPosition =  new Position(node.X, node.Y);
        }
        public void MoveRobot(char instruction)
        {
            var newPosition = GetPositionInDirection(instruction, _robotPosition);

            var node = FindInPosition(newPosition);
            if (node.IsWall)
                return;

            if (node.IsFree)
            {
                _robotPosition = newPosition;
                return;
            }

            // it is a box
            var next = node;
            while (next.IsBox)
            {
                var pos = GetPositionInDirection(instruction, next);
                next = FindInPosition(pos);
            }

            if (next.IsWall)
                return;

            _nodes.Remove(next);
            _nodes.Add(new Node(next.X, next.Y, 'O'));
            _robotPosition = newPosition;
            _nodes.Remove(node);
            _nodes.Add(new Node(node.X, node.Y, '.'));
        }

        private Position GetPositionInDirection(char instruction, Position position)
        {
            return instruction switch
            {
                '^' => position with { Y = position.Y - 1 },
                'v' => position with { Y = position.Y + 1 },
                '<' => position with { X = position.X - 1 },
                '>' => position with { X = position.X + 1 },
                _ => throw new InvalidOperationException()
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var down = _nodes.Max(n => n.Y);
            var right = _nodes.Max(n => n.X);
            for (var row = 0; row <= down; row++)
            {
                for (var column = 0; column <= right; column++)
                {
                    var node = _nodes.First(n => n.X == column && n.Y == row);
                    if (node == _robotPosition)
                    {
                        sb.Append('@');
                    }
                    else if (node.IsWall)
                    {
                        sb.Append('#');
                    }
                    else if (node.IsBox)
                    {
                        sb.Append('O');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private Node FindInPosition(Position position) => _nodes.First(n => n.X == position.X && n.Y == position.Y);

        public long SumOfAllBoxes() => _nodes.Where(n => n.IsBox).Sum(n => n.X + 100 * n.Y);
    }

    private record Position(int X, int Y);

    private class Node(
        int x,
        int y,
        char value)
    {
        public bool IsBox => value == 'O';
        public int Y => y;
        public int X => x;
        public char Value => value;
        public bool IsRobot => value == '@';
        public bool IsWall => value == '#';
        public bool IsFree => value == '.';

        public static implicit operator Position(Node node) => new(node.X, node.Y);
    }
}
