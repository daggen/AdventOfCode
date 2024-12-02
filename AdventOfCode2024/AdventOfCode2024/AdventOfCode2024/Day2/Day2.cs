namespace AdventOfCode2024.Day2;

public class Day2
{
    public int GetValidReports()
    {
        var lines = File.ReadLines("../../../Day2/Input.txt");
        var count = lines.Select(line => line.Split(" "))
            .Where(IsValid2)
            .Count();

        return count;
    }

    private bool IsValid2(string[] arg)
    {
        var numbers = arg.Select(int.Parse).ToList();
        if (numbers.First() > numbers.Last())
            numbers.Reverse();


        for (int i = 0; i < numbers.Count - 1; i++)
        {
            var diff = numbers[i+1] - numbers[i];
            if (diff is not (1 or 2 or 3))
            {
                var t1 = numbers.ToList();
                var t2 = numbers.ToList();
                t1.RemoveAt(i);
                t2.RemoveAt(i + 1);
                return IsValid(t1) || IsValid(t2);
            }
        }

        return true;
    }

    private bool IsValid(string[] arg)
    {
        var numbers = arg.Select(int.Parse).ToList();
        if (numbers.First() > numbers.Last())
            numbers.Reverse();


        for (int i = 0; i < numbers.Count - 1; i++)
        {
            var diff = numbers[i+1] - numbers[i];
            if (diff is not (1 or 2 or 3))
                return false;
        }

        return true;
    }

    private bool IsValid(List<int> numbers)
    {
        if (numbers.First() > numbers.Last())
            numbers.Reverse();


        for (int i = 0; i < numbers.Count - 1; i++)
        {
            var diff = numbers[i+1] - numbers[i];
            if (diff is not (1 or 2 or 3))
                return false;
        }

        return true;
    }
}
