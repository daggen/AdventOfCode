using System.Numerics;

namespace AdventOfCode2024.Day9;

public class Day9
{
    public string GetSum2()
    {
        var lines = File.ReadLines("../../../Day9/Input.txt").First()
            .Select((n, i)
                => i % 2 == 0 ? (Block)new BlockFile(int.Parse(n.ToString()), i / 2) : new EmptySpace(int.Parse(n.ToString())))
            .ToArray();

        var result2 = lines.Select(b => b.ToNumbers())
            .SelectMany(x => x)
            .ToArray();
        Console.WriteLine(string.Join("", result2));

        for (var i = lines.Length - 1; i > 0; i--)
        {
            if (lines[i] is not BlockFile file)
                continue;

            for (int j = 0; j < i; j++)
            {
                if (lines[j] is EmptySpace emptySpace
                    && emptySpace.RoomFor(file))
                {
                    emptySpace.AddFile(file);
                    lines[i] = new EmptySpace(file.Size);
                    break;
                }
            }
        }

        var result = lines.Select(b => b.ToNumbers())
            .SelectMany(x => x)
            .ToArray();

        Console.WriteLine(string.Join("", result));
        return result
            .Select((s, i) => s * i)
            .Aggregate(new BigInteger(0), (acc, i) => acc + i)
            .ToString();
    }

    public interface Block
    {
        IEnumerable<int> ToNumbers();
    }

    public class BlockFile(
        int size,
        int i) : Block
    {
        public int Size => size;
        public int Index => i;
        public IEnumerable<int> ToNumbers() => Enumerable.Repeat(i, size);
    }

    public class EmptySpace(int size) : Block
    {
        private readonly List<BlockFile> _files = new();

        public bool RoomFor(BlockFile file)
            => AvailableSize >= file.Size;

        private int AvailableSize => size - _files.Sum(f => f.Size);

        public void AddFile(BlockFile file)
        {
            _files.Add(file);
        }

        public IEnumerable<int> ToNumbers()
        {
            return _files.Select(f => f.ToNumbers())
                .SelectMany(x => x)
                .Concat(Enumerable.Repeat(0, AvailableSize));
        }
    }


    public string GetSum1()
    {
        var lines = File.ReadLines("../../../Day9/Input.txt").First()
            .Select((n, i) => Enumerable.Repeat(i % 2 == 0 ? (i / 2).ToString() : '.'.ToString(), int.Parse(n.ToString())))
            .SelectMany(x => x)
            .ToArray();

        do
        {
            var first = Array.IndexOf(lines, ".");
            var last = GetLastNumber(lines);

            if (first < last)
            {
                (lines[first], lines[last]) = (lines[last], lines[first]);
            }
            else
            {
                break;
            }
        } while (true);


        Console.WriteLine(string.Join("", lines));
        return lines.TakeWhile(c => int.TryParse(c, out _))
            .Select((s, i) => int.Parse(s) * i)
            .Aggregate(new BigInteger(0), (acc, i) => acc + i)
            .ToString();
    }

    private int GetLastNumber(string[] arg)
    {
        for(var i = arg.Length - 1; i >= 0; i--)
        {
            if (arg[i] != ".")
            {
                return i;
            }
        }

        return -1;
    }
}
