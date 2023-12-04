using System.Text.RegularExpressions;

namespace day_2;

public static partial class PartTwo
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;
        await foreach(var line in lines)
        {
            var maxRed = ColorRegexes.GetMaxNumberOfRed(line);
            var maxGreen = ColorRegexes.GetMaxNumberOfGreen(line);
            var maxBlue = ColorRegexes.GetMaxNumberOfBlue(line);

            result += maxRed * maxGreen * maxBlue;
        }

        Console.WriteLine($"Part II: {result}");
    }
}
