using System.Text.RegularExpressions;

namespace day_4;

public static partial class PartOne
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;

        await foreach (var line in lines)
        {
            var card = Deserialize(line);
            result += CalculatePoints(card);
        }

        Console.WriteLine($"Part I: {result}");
    }

    [GeneratedRegex(@"Card\s+\d+:\s+((\d+)\s+)+\|\s+((\d+)\s*)+", RegexOptions.Singleline)]
    private static partial Regex CardRegex();

    private static Card Deserialize(string line)
    {
        var matches = CardRegex().Matches(line);

        return new Card(
            WinningNumbers: matches[0].Groups[1].Captures.Select(c => int.Parse(c.Value)).ToList(),
            ChosenNumbers: matches[0].Groups[3].Captures.Select(c => int.Parse(c.Value)).ToList());
    }

    private static int CalculatePoints(Card card)
    {
        var intersections = card.WinningNumbers.Intersect(card.ChosenNumbers).Count();

        if (intersections == 0)
        {
            return 0;
        }

        return (int)Math.Pow(2, intersections - 1);
    }
}