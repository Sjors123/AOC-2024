using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2024.Functions;

public class ReadFileFunctions
{
    public static List<List<int>> ReadColumns(string filePath)
    {
        List<List<int>> result = new List<List<int>>();
        foreach (var line in File.ReadLines(filePath))
        {
            var numbers = line.Split("   ");
            if (result.Count == 0)
            {
                result = Enumerable.Range(0, numbers.Length).Select(_ => new List<int>()).ToList();
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                
                result[i].Add(int.Parse(numbers[i]));
            }

        }
        return result;
    }

    public static List<List<int>> ReadLinesToIntList(string filePath)
    {
        List<List<int>> result = new List<List<int>>();
        foreach (var line in File.ReadLines(filePath))
        {
            result.Add(line.Split(' ').Select(int.Parse).ToList());
        }
        return result;
    }
}
