using System.Text.RegularExpressions;

namespace day_2;

public static partial class PartOne
{
    private const int MAX_RED = 12;
    private const int MAX_GREEN = 13;
    private const int MAX_BLUE = 14;

    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;
        await foreach(var line in lines)
        {
            var maxRed = ColorRegexes.GetMaxNumberOfRed(line);
            var maxGreen = ColorRegexes.GetMaxNumberOfGreen(line);
            var maxBlue = ColorRegexes.GetMaxNumberOfBlue(line);

            if (maxRed <= MAX_RED && maxGreen <= MAX_GREEN && maxBlue <= MAX_BLUE)
            {
                result += GetGameId(line);
            }
        }

        Console.WriteLine($"Part I: {result}");
    }

    [GeneratedRegex("Game (\\d*)", RegexOptions.Singleline)]
    private static partial Regex GameIdRegex();

    private static int GetGameId(string line) => int.Parse(GameIdRegex().Match(line).Groups.Values.ElementAt(1).Value);
}
