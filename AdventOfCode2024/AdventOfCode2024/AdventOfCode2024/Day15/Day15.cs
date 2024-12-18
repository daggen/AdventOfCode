using System.Text;

namespace AdventOfCode2024.Day15;

public class Day15
{
    public string GetSum2()
    {
        var lines = File.ReadLines("../../../Day15/Input.txt")
            .ToList();

        var enumerable = lines.TakeWhile(l => !string.IsNullOrWhiteSpace(l)).ToList();
        var maze = new Maze(enumerable
            .Select((line, row) => line.Select((c, column) => CreateNode(row, column, c)))
            .SelectMany(x => x)
            .SelectMany(x => x)
            .ToList());

        var instructions = lines.Skip(enumerable.Count).SelectMany(x => x);

        foreach (var instruction in instructions)
        {
            maze.MoveRobot(instruction);
        }

        return maze.SumOfAllBoxes().ToString();
    }

    private IEnumerable<Node> CreateNode(int row, int column, char c)
    {
        switch (c)
        {
            case '@':
                yield return new Node(column, row, c);
                break;
            case '#':
            case '.':
                yield return new Node(column, row, c);
                yield return new Node(column, row, c);
                break;
            case 'O':
                yield return new BoxNode(column, row);
                break;
        }
    }

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

        public Maze(List<Node> nodes)
        {
            _nodes = nodes;
            var node = nodes.First(n => n.IsRobot);
            _nodes.Remove(node);
            _nodes.Add(new Node(node.X, node.Y, '.'));
            _robotPosition = new Position(node.X, node.Y);
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
            if (CanMoveBox(node, instruction))
            {
                MoveBox(node, instruction);
            }
        }

        private void MoveBox(Node node, char instruction)
        {
            var positions = node.GetPositions()
                .Select(p => GetPositionInDirection(instruction, p));

            var itemsInPositions = positions
                .Select(FindInPosition)
                .Distinct()
                .ToList();

            foreach (var box in itemsInPositions.Where(p => p.IsBox && p != node))
                MoveBox(box, instruction);

            foreach (var free in itemsInPositions.Where(n => n.IsFree))
            {
                _nodes.Remove(free);
            }

            _nodes.Remove(node);
            _nodes.Add(node.Move(GetPositionInDirection(instruction, node)));
            _nodes.AddRange(node.GetPositions().Select(p => new Node(p.X, p.Y, '.')));
        }

        private bool CanMoveBox(Node node, char instruction)
        {
            var positions = node.GetPositions()
                .Select(p => GetPositionInDirection(instruction, p));

            var itemsInPositions = positions
                .Select(FindInPosition)
                .Where(n => n != node)
                .Distinct()
                .ToList();
            if (itemsInPositions.Any(n => n.IsWall))
                return false;

            return itemsInPositions.All(p => p.IsFree || CanMoveBox(p, instruction));
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
                    var position = new Position(column, row);
                    var node = FindInPosition(position);
                    if (node == _robotPosition)
                    {
                        sb.Append('@');
                    }
                    else if (node.IsWall)
                    {
                        sb.Append("#");
                    }
                    else if (node.IsBox)
                    {
                        sb.Append("[]");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private Node FindInPosition(Position position) => _nodes.First(
            n => n.IsInPosition(position));

        public long SumOfAllBoxes() => _nodes.Where(n => n.IsBox).Sum(n => n.X + 100 * n.Y);
    }

    public record Position(
        int X,
        int Y);

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

        public IEnumerable<Position> GetPositions()
        {
            yield return new Position(x, y);

            if (IsBox)
                yield return new Position(x + 1, y);
        }

        public bool IsInPosition(Position position) => GetPositions().Contains(position);

        public Node Move(Position to) => new(x + to.X, y + to.Y, value);
    }

    private class BoxNode(
        int x,
        int y) : Node(x, y, 'O')
    {
        public static implicit operator Position(BoxNode node) => new(node.X, node.Y);
    }
}

public static class PositionExtensions
{
    public static Day15.Position Add(this Day15.Position p1, Day15.Position p2)
        => new(X: p1.X + p2.X, Y: p1.Y + p2.Y);
}
