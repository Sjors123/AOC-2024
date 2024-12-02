using AOC_2024.Functions;

namespace AOC_2024.Days.Day2;

public class Day2
{
    public static int Part1(string filePath)
    {
        int validReports = 0;
        var reports = ReadFileFunctions.ReadLinesToIntList(filePath);
        foreach(var report in reports)
        {
            if (report[0] - report[1] == 0) continue;
            bool increase = report[0] - report[1] > 0 ? false : true;
            bool stillValid = true;
            for (int i = 0; i < report.Count()-1; i++)
            {
                if (increase)
                {
                    int difference = report[i + 1] - report[i];
                    if (difference > 3 || difference < 1)
                    {
                        stillValid = false;
                        break;
                    }
                }
                else
                {
                    int difference = report[i] - report[i+1];
                    if (difference > 3 || difference < 1)
                    {
                        stillValid = false;
                        break;
                    }
                }
            }
            if (stillValid) validReports++;
        } 
        return validReports;
    }

    public static int Part2(string filePath)
    {
        int validReports = 0;
        var reports = ReadFileFunctions.ReadLinesToIntList(filePath);
        foreach (var report in reports)
        {
            if (report[0] - report[1] == 0)
            {
                bool adjustedCorrect = false;
                for (int j = 0; j < report.Count(); j++)
                {
                    var adjustedReport = report.Where((_, index) => index != j).ToList();
                    if (validReport(adjustedReport))
                    {
                        adjustedCorrect = true;
                        break;
                    }
                }
                if (adjustedCorrect)
                {
                    validReports++;
                }
                continue;

            }
            bool increase = report[0] - report[1] > 0 ? false : true;
            bool stillValid = true;
            for (int i = 0; i < report.Count() - 1; i++)
            {
                if (increase)
                {
                    int difference = report[i + 1] - report[i];
                    if (difference > 3 || difference < 1)
                    {
                        bool adjustedCorrect = false;
                        for (int j = 0; j < report.Count(); j++)
                        {
                            var adjustedReport = report.Where((_, index) => index != j).ToList();
                            if (validReport(adjustedReport))
                            {
                                adjustedCorrect = true;
                                break;
                            }
                        }
                        if (adjustedCorrect) break;
                        stillValid = false;
                        break;
                    }
                }
                else
                {
                    int difference = report[i] - report[i + 1];
                    if (difference > 3 || difference < 1)
                    {
                        bool adjustedCorrect = false;
                        for (int j = 0; j < report.Count(); j++)
                        {
                            var adjustedReport = report.Where((_, index) => index != j).ToList();
                            if (validReport(adjustedReport))
                            {
                                adjustedCorrect = true;
                                break;
                            }
                        }
                        if (adjustedCorrect) break;
                        stillValid = false;
                        break;
                    }
                }
            }
            if (stillValid) validReports++;
        }
        return validReports;
    }

    private static bool validReport(List<int> report)
    {
        if (report[0] - report[1] == 0) return false;
        bool increase = report[0] - report[1] > 0 ? false : true;
        for (int i = 0; i < report.Count() - 1; i++)
        {
            if (increase)
            {
                int difference = report[i + 1] - report[i];
                if (difference > 3 || difference < 1)
                {
                    return false;
                }
            }
            else
            {
                int difference = report[i] - report[i + 1];
                if (difference > 3 || difference < 1)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
