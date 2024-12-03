using AOC_2024.Functions;
using System.Text.RegularExpressions;

namespace AOC_2024.Days;

public class Day3
{
    public static int Part1(string filePath)
    {
        int result = 0;
        string data = ReadFileFunctions.ReadString(filePath);
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        MatchCollection validMulitplications = Regex.Matches(data, pattern);
        string numbersAndCommas = @"[^\d,]";
        foreach (Match multiplication in validMulitplications)
        {
            string[] multiplicationnumbers = Regex.Replace(multiplication.Value, numbersAndCommas, "").Split(",");
            result += int.Parse(multiplicationnumbers[0]) * int.Parse(multiplicationnumbers[1]);
        }
        return result;
    }

    public static int Part2(string filePath)
    {
        int result = 0;
        string data = ReadFileFunctions.ReadString(filePath);
        bool enabled = true;
        string MultiplicationPattern = @"mul\(\d{1,3},\d{1,3}\)";
        string EnablePattern = @"do\(\)";
        string DisablePattern = @"don't\(\)";
        string numbersAndCommas = @"[^\d,]";
        for (int i = 0; i < data.Length-12; i++)
        {
            string StringToCheck = data.Substring(i, 12);
            MatchCollection validMulitplication = Regex.Matches(StringToCheck, MultiplicationPattern);
            MatchCollection enable = Regex.Matches(StringToCheck, EnablePattern);
            MatchCollection disable = Regex.Matches(StringToCheck, DisablePattern);
            if (enabled && validMulitplication.Count() != 0)
            {
                string[] multiplicationnumbers = Regex.Replace(validMulitplication[0].Value, numbersAndCommas, "").Split(",");
                result += int.Parse(multiplicationnumbers[0]) * int.Parse(multiplicationnumbers[1]);
                i += 11;
                continue;
            }
            if (disable.Count != 0)
            { 
                enabled = false;
                continue;
            }
            if (enable.Count != 0)
            {
                enabled = true;
                continue;
            }
        }
        return result;
    }
}
