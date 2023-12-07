using System.Text.RegularExpressions;

namespace day_5;

public static partial class PartTwo
{
    public static void Run()
    {
        var lines = File.ReadLines("./input.txt").ToArray();

        var mapper = MapperFactory.CreateMapper(lines.AsSpan()[1..]);

        var seedRanges = GetSeedRanges(lines[0]).ToList();

        long lowestLocation = -1;
        for (long i = 0;; i++)
        {
            var value = mapper.MapToSeed(i);

            if (seedRanges.Any(range => range.min <= value && value <= range.max))
            {
                lowestLocation = i;
                break;
            }

            if (i == long.MaxValue)
            {
                break;
            }
        }

        Console.WriteLine($"Part II: {lowestLocation}");
    }

    [GeneratedRegex(@"((\d+) *)+", RegexOptions.Singleline)]
    private static partial Regex SeedsLineRegex();

    private static IEnumerable<long> GetSeeds(string seedsLine)
    {
        var matches = SeedsLineRegex().Match(seedsLine);

        var captures = matches.Groups[1].Captures;

        for (var i = 0; i < captures.Count / 2; i++)
        {
            var startValue = long.Parse(captures.ElementAt(i * 2).Value);
            var length = long.Parse(captures.ElementAt(i * 2 + 1).Value);

            for (var j = startValue; j < startValue + length; j++)
            {
                yield return j;
            }
        }
    }

    private static IEnumerable<(long min, long max)> GetSeedRanges(string seedsLine)
    {
        var matches = SeedsLineRegex().Match(seedsLine);

        var captures = matches.Groups[1].Captures;

        for (var i = 0; i < captures.Count / 2; i++)
        {
            var startValue = long.Parse(captures.ElementAt(i * 2).Value);
            var length = long.Parse(captures.ElementAt(i * 2 + 1).Value);

            yield return (startValue, startValue + length - 1);
        }
    }
}