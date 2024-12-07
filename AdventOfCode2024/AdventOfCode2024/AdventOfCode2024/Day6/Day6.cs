
namespace AdventOfCode2024.Day6;

public class Day6
{
    public int GetSum1()
    {
        var lines = File.ReadLines("../../../Day6/Input.txt").ToArray();
        var obstacles = new List<Position>();
        Position guardOriginalPosition = null;
        var blankSpots = new List<Position>();
        for (int row = 0; row < lines.Length; row++)
        {
            for (int column = 0; column < lines[row].Length; column++)
            {
                var c = lines[row][column];
                switch (c)
                {
                    case '#':
                        obstacles.Add(new Position(column, row));
                        break;
                    case '^':
                        guardOriginalPosition = new Position(column, row);
                        break;
                    case '.':
                        blankSpots.Add(new Position(column, row));
                        break;
                }
            }
        }


        if (guardOriginalPosition == null)
            throw new Exception("No guard found");

        blankSpots.Remove(guardOriginalPosition);
        var guard = new Guard(guardOriginalPosition, obstacles, new Position(lines[0].Length, lines.Length));
        while (guard.WillGoOffMap())
            guard.Move();

        var count = guard.VisitedLocations.AsParallel().Where(p =>
        {
            var o = obstacles.ToList();
            o.Add(p);
            var guard = new Guard(guardOriginalPosition, o, new Position(lines[0].Length, lines.Length));
            while (guard.WillGoOffMap())
                if (guard.Move())
                {
                    obstacles.Remove(p);
                    return true;
                }

            return false;
        }).Count();

        return count;
    }

    private class Guard
    {
        private Position currentPosition;
        private readonly List<Position> _obstacles;
        private readonly Position _maxPosition;
        private Position direction = new(0, -1);
        private readonly HashSet<Position> visited = new();
        private readonly HashSet<Position> turningPoints = new();

        public Guard(Position position, List<Position> obstacles, Position maxPosition)
        {
            currentPosition = position;
            _obstacles = obstacles;
            _maxPosition = maxPosition;
            visited.Add(currentPosition);
        }

        public int Length => visited.Count;

        public bool WillGoOffMap()
        {
            var (nextPosition, _) = NextPosition();
            return nextPosition.X >= 0 && nextPosition.X < _maxPosition.X && nextPosition.Y >= 0 && nextPosition.Y < _maxPosition.Y;
        }

        private bool CanGoStraight
            => !_obstacles.Contains(new Position(currentPosition.X + direction.X, currentPosition.Y + direction.Y));

        private bool CanGoTo(Position position)
            => !_obstacles.Contains(position);

        public IEnumerable<Position> VisitedLocations => visited;

        private (Position position, bool turning) NextPosition()
        {
            if (CanGoStraight)
                return (new Position(currentPosition.X + direction.X, currentPosition.Y + direction.Y), false);

            var position = new Position(currentPosition.X + -direction.Y, currentPosition.Y + direction.X);
            if (CanGoTo(position))
                return (position, true);

            position = new Position(currentPosition.X - direction.X, currentPosition.Y - direction.Y);
            return (position, true);
        }

        public bool Move()
        {
            var (next, turning) = NextPosition();
            var infinityLoop = false;
            if (turning)
            {
                direction = new Position(next.X - currentPosition.X, next.Y - currentPosition.Y);
                infinityLoop = !turningPoints.Add(currentPosition);
            }
            currentPosition = next;
            visited.Add(currentPosition);

            return infinityLoop;
        }
    }
    private record Position(int X, int Y);
}
