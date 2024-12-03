using AOC_2024.Functions;

namespace AOC_2024.Days;

public class Day1
{
    public static int Part1(string filePath)
    {
        var inputLists = ReadFileFunctions.ReadColumns(filePath);
        inputLists.ForEach(list => list.Sort());
        int result = 0;
        for (int i = 0; i < inputLists[0].Count; i++)
        {
            result += Math.Abs(inputLists[0][i] - inputLists[1][i]);
        }
        return result;
    }

    public static int Part2(string filePath)
    {
        var inputLists = ReadFileFunctions.ReadColumns(filePath);
        int result = 0;
        foreach (var number in inputLists[0])
        {
            result += number * inputLists[1].Count(n => n == number);
        }
        return result;
    }
}
