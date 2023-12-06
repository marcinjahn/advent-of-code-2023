using System.Text.RegularExpressions;

namespace day_4;

public static partial class PartTwo
{
    public static void Run()
    {
        var matches = File.ReadLines("./input.txt").Select(Deserialize).Select(CalculateMatches).ToList();

        var result = matches.Count;

        for (var i = 0; i < matches.Count; i++)
        {
            result += ProcessCard(i + 1, matches[i], matches);
        }

        Console.WriteLine($"Part II: {result}");
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

    private static int CalculateMatches(Card card) => card.WinningNumbers.Intersect(card.ChosenNumbers).Count();

    private static int ProcessCard(int cardNumber, int matches, List<int> allMatches)
    {
        if (matches is 0)
        {
            return 0;
        }

        var result = matches;

        for (var i = 1; i <= matches; i++)
        {
            result += ProcessCard(allMatches[cardNumber - 1 + i], cardNumber + i, allMatches);
        }

        return result;
    }
}