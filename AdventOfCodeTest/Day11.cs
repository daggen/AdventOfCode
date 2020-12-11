using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day11
    {
        public IEnumerable<string> GetInput(string fileName) => File.ReadLines(fileName);

        [Theory]
        [InlineData("../../Input/inputDay11Small.txt", 37)]
        [InlineData("../../Input/inputDay11.txt", 2324)]
        public void Part1(string testData, int expected)
        {
            var seatingModel = new SeatingModel(GetInput(testData).ToList());

            seatingModel.RunAdjacent();

            var occupiedSeats = seatingModel.GetNumberOfOccupiedSeats();
            Assert.Equal(expected, occupiedSeats);
        }

        [Theory]
        [InlineData("../../Input/inputDay11Small.txt", 26)]
        [InlineData("../../Input/inputDay11.txt", 2068)]
        public void Part2(string testData, int expected)
        {
            var seatingModel = new SeatingModel(GetInput(testData).ToList());

            seatingModel.RunLineOfSight();

            var occupiedSeats = seatingModel.GetNumberOfOccupiedSeats();
            Assert.Equal(expected, occupiedSeats);
        }
    }

    public class SeatingModel
    {
        private SeatTypes[][] m_Model;

        public SeatingModel(List<string> toList)
        {
            m_Model = new SeatTypes[toList.Count][];

            for (var i = 0; i < toList.Count; i++)
            {
                m_Model[i] = ParseLine(toList[i]);
            }
        }

        private static SeatTypes[] ParseLine(string to) => to.ToCharArray().Select(CharToSeatStatus).ToArray();

        private static SeatTypes CharToSeatStatus(char arg)
        {
            switch (arg)
            {
                case 'L':
                    return SeatTypes.Free;
                case '.':
                    return SeatTypes.Floor;
                case '#': return SeatTypes.Occupied;
            }
            throw new ArgumentException(arg.ToString());
        }

        public void RunLineOfSight()
        {
            Run(GetNumberOfOccupiedSeatsLineOfSight, 5);
        }

        private void RunOnce(Func<int, int, int> getNumberOfOccupiedSeats, int max)
        {
            var copy = new SeatTypes[m_Model.Length][];

            for (var i = 0; i < copy.Length; i++)
            {
                copy[i] = new SeatTypes[m_Model[0].Length];
                for (var j = 0; j < copy[i].Length; j++)
                {
                    copy[i][j] = GetSeatType(i, j, max, getNumberOfOccupiedSeats);
                }
            }

            m_Model = copy;
        }

        private SeatTypes GetSeatType(int i, int j, int max, Func<int,int, int> getNumberOfOccupiedSeats)
        {
            var current = m_Model[i][j];
            if (current == SeatTypes.Floor) return SeatTypes.Floor;

            var numberOfOccupiedAround = getNumberOfOccupiedSeats(i, j);

            switch (current)
            {
                case SeatTypes.Free:
                    return numberOfOccupiedAround == 0
                               ? SeatTypes.Occupied
                               : SeatTypes.Free;
                case SeatTypes.Occupied:
                    return numberOfOccupiedAround >= max
                               ? SeatTypes.Free
                               : SeatTypes.Occupied;
            }

            throw new ArgumentException();
        }

        private int GetNumberOfAdjacentOccupiedSeats(int i, int j)
        {
            var list = new List<(int, int)>{(1, 1), (0, 1), (1, 0), (-1, -1), (-1, 0), (0, -1), (-1, 1), (1, -1)};
            var coordinates = list.Select(a => (a.Item1 + i, a.Item2 + j))
                .Where(a => a.Item1 >= 0 && a.Item2 >= 0)
                .Where(a => a.Item1 < m_Model.Length && a.Item2 < m_Model[0].Length);

            var numberOfOccupied = coordinates.Count(a => m_Model[a.Item1][a.Item2] == SeatTypes.Occupied);
            return numberOfOccupied;
        }

        public int GetNumberOfOccupiedSeats()
        {
            return m_Model.Sum(r => r.Count(c => c == SeatTypes.Occupied));
        }

        public void RunAdjacent()
        {
            Run(GetNumberOfAdjacentOccupiedSeats, 4);
        }

        private void Run(Func<int, int, int> getNumberOfOccupiedSeats, int max)
        {
            SeatTypes[][] copy;
            do
            {
                copy = m_Model;
                RunOnce(getNumberOfOccupiedSeats, max);
            }
            while (IsDifferent(m_Model, copy));
        }

        private static bool IsDifferent(SeatTypes[][] model, SeatTypes[][] copy)
        {
            for (var i = 0; i < model.Length; i++)
            {
                for (var j = 0; j < model[0].Length; j++)
                {
                    if (model[i][j] != copy[i][j]) return true;
                }
            }

            return false;
        }
        
        private int GetNumberOfOccupiedSeatsLineOfSight(int i, int j)
        {
            var list = new List<(int, int)>{(1, 1), (0, 1), (1, 0), (-1, -1), (-1, 0), (0, -1), (-1, 1), (1, -1)};
            var numberOfOccupied = 0;
            foreach (var direction in list)
            {
                var x = i;
                var y = j;
                while (IsInModel(x += direction.Item1, m_Model.Length) &&
                       IsInModel(y += direction.Item2, m_Model[0].Length))
                {
                    var seat = m_Model[x][y];
                    if (seat == SeatTypes.Floor)
                    {
                        continue;
                    }
                    if (seat == SeatTypes.Occupied)
                    {
                        numberOfOccupied++;
                    }
                    break;
                }
            }
            return numberOfOccupied;
        }

        private static bool IsInModel(int value, int max) => value >= 0 && value < max;
    }

    public enum SeatTypes
    {
        Floor, Free, Occupied
    }
}
