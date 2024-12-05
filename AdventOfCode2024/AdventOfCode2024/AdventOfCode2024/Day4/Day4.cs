using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day4;

public class Day4
{
    public int GetXmas2()
    {
        var lines = File.ReadLines("../../../Day4/Input.txt");
        var matrix = lines.Select(s => s.ToArray()).ToArray();

        var group = GetGroups(matrix)
            .Count(IsXmas);

        return group;
    }

    private IEnumerable<char[][]> GetGroups(char[][] matrix)
    {
        for(var row = 0; row <= matrix.Length - 3; row++)
        {
            for (int column = 0; column <= matrix[row].Length - 3; column++)
            {
                var group = new List<char[]>();
                group.Add(matrix[row][column..(column + 3)]);
                group.Add(matrix[row + 1][column..(column + 3)]);
                group.Add(matrix[row + 2][column..(column + 3)]);

                yield return group.ToArray();
            }
        }
    }


    private bool IsXmas(char[][] arg)
    {
        if (arg[1][1] != 'A')
            return false;

        if (!(arg[0][0] is 'M' or 'S' && arg[2][2] is 'M' or 'S' && arg[0][0] != arg[2][2]))
            return false;

        return arg[0][2] is ('M' or 'S') && arg[2][0] is 'M' or 'S' && arg[0][2] != arg[2][0];
    }

    public int GetXmas()
    {
        var lines = File.ReadLines("../../../Day4/Input.txt");
        var matrix = lines.Select(s => s.ToArray()).ToArray();
        var xmas = "XMAS";

        var count = Count(matrix, xmas);
        var flipped = Flip(matrix);
        count += Count(flipped, xmas);

        return count;
    }

    private char[][] Flip(char[][] matrix)
    {
        var result = new List<char[]>();
        foreach (var line in matrix.Reverse())
        {
            result.Add(line.Reverse().ToArray());
        }

        return result.ToArray();
    }

    private static int Count(char[][] matrix, string xmas)
    {
        var count = 0;
        for(var row = 0; row < matrix.Length; row++)
        {
            for(var column = 0; column <= matrix[row].Length - xmas.Length; column++)
            {
                var word = new string(matrix[row][column..(column + xmas.Length)]);
                if (word == xmas)
                {
                    count++;
                }
            }
        }

        for(var row = 0; row <= matrix.Length - xmas.Length; row++)
        {
            for(var column = 0; column < matrix[row].Length; column++)
            {
                var word = new string(Enumerable.Range(row, xmas.Length)
                    .Select(k => matrix[k][column])
                    .ToArray());
                if (word == xmas)
                {
                    count++;
                }
            }
        }

        for(var i = 0; i <= matrix.Length - xmas.Length; i++)
        {
            for(var j = 0; j <= matrix[i].Length - xmas.Length; j++)
            {
                var word = new string(Enumerable.Range(0, xmas.Length)
                    .Select(k => matrix[k+i][k+j])
                    .ToArray());
                if (word == xmas)
                {
                    count++;
                }
            }
        }

        for(var row = 0; row <= matrix.Length - xmas.Length; row++)
        {
            for(var column = 3; column < matrix[row].Length; column++)
            {
                var word = new string(Enumerable.Range(0, xmas.Length)
                    .Select(k => matrix[row + k][column - k])
                    .ToArray());
                if (word == xmas)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
