using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day12
    {
        public IEnumerable<string> GetInput(string fileName) => File.ReadLines(fileName);

        [Theory]
        [InlineData("../../Input/inputDay12Small.txt", 25)]
        [InlineData("../../Input/inputDay12.txt", 582)]
        public void Part1(string testData, int expected)
        {
            var boat = new Boat();

            foreach (var instruction in GetInput(testData))
            {
                boat.HandleInstruction(instruction);
            }

            var distance = boat.DistanceFrom(new Point(0,0));
            Assert.Equal(expected, distance);
        }

        [Theory]
        [InlineData("../../Input/inputDay12Small.txt", 286)]
        [InlineData("../../Input/inputDay12.txt", 52069)]
        public void Part2(string testData, int expected)
        {
            var boat = new Boat();

            foreach (var instruction in GetInput(testData))
            {
                boat.HandleInstruction2(instruction);
            }

            var distance = boat.DistanceFrom(new Point(0,0));
            Assert.Equal(expected, distance);
        }
    }

    public class Boat
    {
        private readonly Dictionary<string, Point> m_Cardinals = new Dictionary<string, Point>
        {
            {"N", new Point(0,1)},
            {"S", new Point(0,-1)},
            {"E", new Point(1,0)},
            {"W", new Point(-1,0)},
        };
        
        public Point Position { get; set; } = new Point(0,0);
        public Point Direction { get; set; } = new Point(1,0);

        public Point WayPoint { get; set; } =  new Point(10, 1);

        public int DistanceFrom(Point point)
        {
            return Math.Abs(Position.X - point.X) + Math.Abs(Position.Y - point.Y);
        }

        public void HandleInstruction(string instruction)
        {
            var mode = instruction.Substring(0, 1);
            var value = int.Parse(instruction.Substring(1, instruction.Length - 1));

            switch (mode)
            {
                case "F":
                    MoveForward(value);
                    break;
                case "L":
                    Turn(value);
                    break;
                
                case "R":
                    Turn(-value);
                    break;

                default:
                    Move(mode, value);
                    break;
            }
        }

        public void HandleInstruction2(string instruction)
        {
            var mode = instruction.Substring(0, 1);
            var value = int.Parse(instruction.Substring(1, instruction.Length - 1));

            switch (mode)
            {
                case "F":
                    MoveToWayPoint(value);
                    break;
                case "L":
                    TurnWayPoint(value);
                    break;
                
                case "R":
                    TurnWayPoint(-value);
                    break;

                default:
                    MoveWayPoint(mode, value);
                    break;
            }
        }

        private void TurnWayPoint(int angle)
        {
            while (angle < 0) angle += 360;
            angle %= 360;
            for (var i = 0; i < angle / 90; i++)
            {
                var temp = WayPoint.X;
                WayPoint.X = -WayPoint.Y;
                WayPoint.Y = temp;
            }
        }

        private void MoveWayPoint(string mode, int value)
        {
            var direction = m_Cardinals[mode];
            WayPoint.Add(direction, value);
        }

        private void MoveToWayPoint(int value)
        {
            Position.Add(WayPoint, value);
        }

        

        private void Move(string mode, int value)
        {
            var direction = m_Cardinals[mode];
            Position.Add(direction, value);
        }

        private void Turn(int angle)
        {
            while (angle < 0) angle += 360;
            angle %= 360;
            for (var i = 0; i < angle / 90; i++)
            {
                var temp = Direction.X;
                Direction.X = -Direction.Y;
                Direction.Y = temp;
            }
        }

        private void MoveForward(int value)
        {
            Position.Add(Direction, value);
        }
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Add(Point direction, int times)
        {
            X += direction.X * times;
            Y += direction.Y * times;
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
