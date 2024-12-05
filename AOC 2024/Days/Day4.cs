using AOC_2024.Functions;

namespace AOC_2024.Days;

public class Day4
{
    public Day4(string filePath)
    {
        Data = ReadFileFunctions.ReadFileIntoStrings(filePath);
    }
    private static List<string>? Data;
    private static string XMAS = "XMAS";
    private static readonly List<List<int>> directions = new List<List<int>>
{
    new List<int> {-1, 0},
    new List<int> {1, 0},
    new List<int> {0, -1},
    new List<int> {0, 1},
    new List<int> {-1, -1},
    new List<int> {-1, 1},
    new List<int> {1, -1},
    new List<int> {1, 1}
};
    public int Part1()
    {
        int result = 0;
        for (int i = 0; i < Data.Count(); i++)
        {
            for (int j = 0; j < Data[i].Count(); j++)
            {
                if (Data[i][j] == 'X')
                {
                    foreach (var direction in directions)
                    {
                        bool xmas = searchInDirection(direction, i + direction[0], j + direction[1], 1);
                        if (xmas) result += 1;

                    }
                }
            }
        }
        return result;
    }

    public int Part2()
    {
        int result = 0;
        for (int i = 1; i < Data.Count()-1; i++)
        {
            for (int j = 1; j < Data[i].Count()-1; j++)
            {
                if (Data[i][j] == 'A')
                {
                    if (Data[i - 1][j-1] == 'M' && Data[i - 1][j + 1] == 'M' && Data[i + 1][j - 1] == 'S' && Data[i + 1][j + 1] == 'S')
                    {
                        result += 1;
                        continue;
                    }
                    else if (Data[i - 1][j - 1] == 'M' && Data[i - 1][j + 1] == 'S' && Data[i + 1][j - 1] == 'M' && Data[i + 1][j + 1] == 'S')
                    {
                        result += 1;
                        continue;
                    }
                    else if (Data[i - 1][j - 1] == 'S' && Data[i - 1][j + 1] == 'M' && Data[i + 1][j - 1] == 'S' && Data[i + 1][j + 1] == 'M')
                    {
                        result += 1;
                        continue;
                    }
                    else if (Data[i - 1][j - 1] == 'S' && Data[i - 1][j + 1] == 'S' && Data[i + 1][j - 1] == 'M' && Data[i + 1][j + 1] == 'M')
                    {
                        result += 1;
                        continue;
                    }
                }
            }
        }
        return result;
    }

    private static bool searchInDirection(List<int> direction, int currentY, int currentX, int depth)
    {
        if (depth == 4) return true;
        if (currentX < 0 || currentY < 0 || currentY >= Data!.Count() || currentX >= Data![currentY].Length)
            return false;
        else if (Data[currentY][currentX] == XMAS[depth])
        {
            return searchInDirection(direction, currentY + direction[0], currentX + direction[1], depth + 1);
        }
        else return false;
    }
}
