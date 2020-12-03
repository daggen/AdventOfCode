﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day3
    {
        [Fact]
        public void TestTraverseMap()
        {
            var numberOfTrees = GetNumberOfTrees(3, 1, Input);
            Assert.Equal(187, numberOfTrees);
        }

        [Fact]
        public void TestTraverseDifferentAngles()
        {
            var angles = new List<(int, int)>{(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};
            var map = Input;
            var totalNumberOfTrees =
                angles.Aggregate(1L, (product, angle) => product *= GetNumberOfTrees(angle.Item1, angle.Item2, map));
            Assert.Equal(4723283400, totalNumberOfTrees);
        }

        private int GetNumberOfTrees(int right, int down, List<string> map)
        {
            var numberOfTrees = 0;
            var position = -right;
            for (var rowNum = 0; rowNum < map.Count; rowNum += down)
            {
                var row = map[rowNum];
                position += right;
                position %= row.Length;
                if (row[position] == '#') numberOfTrees++;
            }
            return numberOfTrees;
        }

        public List<string> InputLight = new List<string>{"..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#"};

        public List<string> Input => new List<string>
        {
            "...#...#..#....#..#...#..##..#.", ".#..#.....#.#............###...", ".#...###....#.............##..#", "...##...##....#.....##..#.##...", ".....###.#.###..##.#.##.......#", "#...##.....#..........#..#.#.#.", "......##.......##..#....#.#....", "....#.###.##..#.#..##.##....#.#", ".......#.......###.#.#.##.....#", ".........#.#....#..........#.#.", ".#...##.....##.........#..#....", ".##....#.#.#...##......#.......", "##.#.#..#....#....#....#...#.#.", "##....#.#..##......#....##...#.", "....#..#..##..#.###.......#.#..", ".....##....###...........#.#.##", "#.....##.........#....##......#", "........###.#..#....#....#.....", "...#.......#.##..#.###......#..", "...............#..#....#.##....", "..#..###..#.#..#.........##..#.", "####..#..####..................", "#...####...#.......#.#.#...#...", "......###.....#......#..#..#...", "#...#.....##.....#.#..##...#.#.", "#...........##.......#.........", ".#..#.........#.#..##....#.....", "........##...#................#", "........#.###.#.###.#.#.##..##.", ".#....##.....#...##.#..#.#.....", "..#..#.....###....##.#....#.#.#", "#......##.##...##..#.........#.", "#..#..#.....#.....#.........#..", "#....#.#...###.........#...#...", ".#.#.....##......#.#......#....", "..##......##...#.#.#.#.........", "..#......#.....##.###.#.#..#...", "....#..#.......#..#..#.....#...", ".#.#.....#...#..........#......", "#.#..#...........#.#.##.#...#.#", "..#.#....###...#...#.....#.#...", "....##.#.###....####.......#...", ".....##....#.......#..#..#....#", "...##..#.#.#.#......#......#...", "...##...#....#...#......###...#", "........#..#.#.....#.###.......", "..#..##.#....#.#.........#...#.", ".....#.####....#.##.........#..", "......#...#...#.....#......###.", ".##.....#....#..#.#....#.....#.", "...........#...#....##..#...#..", ".....#....#.....#...##..#...#.#", ".#...#.........#.......#...#..#", "...#..#...#........#......#....", "..#..#####.#.....#.#....#...#.#", "...#.......#.#....#...##..#..#.", "####..#.#.###.#.#..............", ".##........#...#.#....#..#.....", "..#..............#.#..##...#.##", ".###.#.....#.#.....##.#......##", "....###.....#...#...#.#..#.....", "....###.#.##.......#....#...#..", "#..#...#......##..#.....#.#...#", "....#.#.........#..............", "#.##.##...#..#.#.#.....#...#.##", "#...#...#......#...........##..", "#.#.#......#............#.#....", ".#.#..######...#.#.........#.##", "..#.#..#...#......#............", "....#.....#......##..#.....#...", ".##............#....##..#......", ".#.#.#...#.##.............###.#", "#.#...#...#.....#....#.#.#.....", "........#..#......##.##.#.....#", ".....#.....#.#####...#....#....", ".#...#......#.........#.#......", "...#...#..##.....##....#..#....", "....#....##..#.........#.......", "..#........##..#.#........#....", "...#...##...........#...#....#.", ".....##.........#..#....#..#.#.", "#..#....##..#...##.....#..##.#.", "..#.#.#.#...#...#.....#.#....#.", ".......#.###...#.#.......#.#...", "....#..#..#.###.#.....###..#.#.", ".#..##......#..#..#....#.####..", "..##...........#...#.........#.", "......#..#...#..........#......", "....#..........#......##...#...", "....#..#.##........#.#...##.#..", "#.##......#........##.#...#...#", "#..#....#.....###........##....", "...........##.....##..#....#.##", "..#....#..#..#......#.#.....#..", "#....#.##....#.....##.......#..", ".#.....#.#..............#.##..#", ".#..#..#...#...#....#.#.....#..", "...###...##.#...#..#........#..", "#...#.##.#.....#.#....#..#.....", "#.....###.#.......#.#..#.#..##.", "....#..#..##.......###.#...#...", ".#...####...............#.....#", ".#.##.#.....#.....#.#......##.#", "#...........#.##....###.##....#", "...............#..........#....", ".....#..#.##.###.#.............", "...##.............#.....#.#..#.", "....#.#...#.#..#..#..#....#....", "..#.......#..........#...#...#.", "...............#.#.#...###....#", "....#...#.##....#..##....#.....", "........#.#.##.........##.##.##", "#.....###.......#.#....#..#..##", ".#..#...#......#.#..##.......#.", "#.....#.#........#.##..#..#....", ".###..##.#.......#......###....", ".#...###.....#.....#....###...#", "........##.##......#.#....#...#", ".#....#..#.........#..##...##..", ".......#.......##.#..#..##.....", "#..##..##......#.#......#.##...", "..#..###..#...#....#..#...#....", "#.............#.####.........##", "..#..................#...#..#..", "..#......#........##.......#.#.", ".#.#.#.#..###.....#....#.#.....", "...#.##.###.......#....#.......", "................##...#.....#...", "..#.###.#...#.####....#..#..#..", "..#....###....##..#.#.........#", ".#..#.#.....#........#....##...", ".....#..#......#..#..##.#.#....", ".#..#.........##....##......#..", ".....#.#...#...#.#...#.#...#.#.", "..#..#...#...#...##.#..###.....", "..#..##......#..##.#...##......", ".......#..##....##.#......#..#.", "..#......#.#.....#.##....##....", "..#....#......#......##........", "....##.#.#....#.......#.##.....", "#.....#...###....#....#...#....", "............#.#..#...#...#..#..", "..##.............##....#.......", ".#.......#.##.#......#....##...", "...##............#....#..#...#.", ".##.####.....#.#..###.#....#.##", "....##.#........#..#...#.......", "...#...###.##...........##..#..", "..##..##....#...#..#..........#", "..#.........#.#...##..........#", ".......##....#.#...##.....#..#.", ".............#.....#.#.......#.", "#.......#..##..##...##.#.......", "..............#.....#.#..#...##", "........##..#.....#...#...#.#..", "###.#.................#........", "...#........#...#.#######..#..#", "...#.##...##.#.#..######...#...", "#.......#..#....#..#.##.....#..", "#..#....##....#.##.......#....#", "#...#..#.#.#...#..#.##..#......", "....#..##....#..#.#...........#", ".##..#.#.............###.......", "#....##......#..#..#.....###...", "..#..........#...###.#.........", ".####......#....#......#.#....#", "..#....#.#.#......#....#.......", ".....#.....#....#....#####....#", ".##..........#...#.###....#....", "....##.....##......#...#.#.....", ".#...#...#..#.#.#...#####......", "...#.##..####.##.##.......##...", "............#.......#..........", ".#..##.#..#####........#..#...#", "#......##..##..##.........##...", "....#....#.............#.#....#", "###..#.....#.....#.#...#..#.###", "#...#.......##......#....#.#.#.", "...#......#..#...#....#...###.#", "....#....##.......#....#......#", "............#......##.##.....#.", "...#.........#......#....##..##", ".....##....##...#..###...#..#..", ".......##.#..........#.##.##...", "....##...........#.#..#..#.##.#", "#...#..##.##.#....#....#.#.....", "...##.#.....#..#..#..###....##.", "#.##.#..#..#.#.............#...", "..#.#.............###.....#....", "...#..#....#..#.....#.#..#..#..", "...#.....##.#...........#..##.#", ".........#.#.##..#..#.#...#....", "...#..##..#...#...###.##.#..#..", ".#..##...##......##..##........", "......##....##.#.##.#.#........", "...#..................#.....#..", ".##................#.#..#..###.", ".##.##.....#................#..", ".....#.#..........#...#..#.#..#", ".............#......#..#.#..#..", "...#...##..#........#....#.....", "#......#........##.##...##.....", "##..#..##....#...#............#", "..##..##.##....##..##........#.", "...#....#.#.#.#....#.#...##....", "....#...##..##.#.##...#..#...#.", "#..#....##.#.....#.......#...##", "##.#....#.............#..#.....", ".##..#..#.#.....#.......#.#..#.", ".......#..#...##...#...###..#..", "..........#...#.#..##.....#...#", "..#....#...........#####....#..", "#....#..#.......##.............", ".........##..#####.......##....", "#..#..........#.....###...#..#.", ".#.#.#..#...#.......##...#####.", ".....#....#.###...#.......#....", "#.#.....##...###....###....#...", ".#.....#..#.#.#........#...#...", ".##.#.#.#......#....###....#...", ".#..##..####......###......#...", "......#.#.#.#.#...#...####.##..", ".#........##..#.....#....#....#", ".....###......##..#....#.......", "#.#.##...#.#......###..........", "........#.#...#..#......#....#.", "..##...##.........#.......#.#..", "..#.##....#...##.....#.###.....", ".........#..#.#....#....#.#.##.", "#.........#......#..#.......#..", "...#...##.......#.........#....", "............#......#...........", "##.....#.....#.#...#.....#.....", "..#.#...#..#...#.#...........#.", "#.#.#..#..#...##.#...#.#.....#.", ".#..###.#..##.#.....#.....#....", "##....##....#.......##..##.....", ".#..#...........###..........#.", ".#..#..#..........###..#.......", "#..###......#............##...#", "#......#........#..#..#..#.#...", ".......#.###...#.##............", ".##....#.......#.#...##.....#.#", "....#..#.#.......#.#...........", "##....#.###.#....#.#..##.#....#", "..#..#..#....#...#........##...", "...#...##....#..#.#...#..#.....", "......#..#......#....#.......#.", "#.#..............#...###...#..#", "...#....#..#..........#.#...#..", "#.....##..##.....#........#....", ".#...##..#.#..............#....", "##.#....#..##...#..#.####.#..#.", ".....#.......#.#.#.#..#.....###", "...#.##....#.#........##.......", "#...#.#...#.#..###..##.##...#.#", "###..............#.#.###.......", "...###..#.#..#....##...###.#...", "......##...........#...#..#...#", ".#..#.........##.......#..#...#", ".#.......###......##...#...#...", ".#......##...#........#.......#", ".#..#.....#.........#.#........", "#...#.#.....#...#..##.........#", "......##.#......##.#..##.#.....", "...............#.#..#....#....#", "#....#..#..#..#.#.....##...##..", "#.#......#.###......#..#...####", ".#.#..#...#...#.#..#.##.##.#.#.", ".....#.#...###...#.#.....##....", "...#..#.#..........##.#....#.#.", "...#..#.#.##.....###.##.#....#.", "..........#..###......#..#.#...", "###.....#..###..#...#..###.#...", "..#..#.....##.#.#..###.......#.", "....#....##........##..........", ".......#..........#...#......#.", ".#........#.#.#.#.#.......#....", ".#..#.......##..##....#.#...#..", ".#.#.#.......#..#..............", "#.#....#.#...#.#.#.....#.#...##", ".....#..........##..#.......#..", ".##......#.#....#.#.......#....", "..#.##....#.##.#...#...........", "...##......##..##.............#", "..........##.#.#..#..........#.", ".##....#..#..#.#....##.#...#.#.", "...........#....#.....#.#..#...", ".#.....#....##..#.........#....", ".....#.....#...#....#...#.###.#", "..#....#....#.....#...#......#.", ".....##..#.............#...#...", "........#..#.......#.#.......#.", "#...###..#.##.#...###...##..##.", "....##..#.......#...#.#........", ".#...#.#.##....####........#..#", ".#...#.#.####.##.#.............", "#..##...#....#...#.#.#.#.##..#.", ".#.......#........#.....###....", "#.#.....#....#..#....#..#....#.", "...#..#...#.....#.........##...", ".#....#......###...#....#.#.#..", "#.#........#......#...#....##..", ".....#..#......#..#..#......#..", ".#.....#..#.##.#.#.#...#......#", "##........#..#.#..#...#.####...", "..........##....#.#..#.#....#..", "#.##..#..#....#..#....##..#.#.#", "..#......#.......#...##..#.....", "##...#.........#......#......#.", ".#.....................#..#.##.", ".#.......#........#.#.#..##.#..", "..#..........#........#..##.#..", ".#...#...#.........##.#.#.#....", "....#....#.###.#....###....#.##", "....##......##........##.#.##..", "....#.#......#.##.#...#.##.....", "....#....#..#.#..###.#.#.......", "....#......#..#.#.......#..##..", ".....#..#.#.##.##..##.....#.#..", "...#....................##.....", "#.....#...##...#.#.............", "..#.#...#.#.#.....##..#....#..."
        };
    }
}
