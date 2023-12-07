using System.Text.RegularExpressions;

namespace day_5;

public static partial class PartOne
{
    public static void Run()
    {
        var lines = File.ReadLines("./input.txt").ToArray();

        var mapper = MapperFactory.CreateMapper(lines.AsSpan()[2..]);

        var seeds = GetSeeds(lines[0]);
        var seedsAndLocations = seeds.Select(seed => mapper.MapToLocation(seed));

        var lowestLocation = seedsAndLocations.Min();

        Console.WriteLine($"Part I: {lowestLocation}");
    }

    [GeneratedRegex(@"((\d+) *)+", RegexOptions.Singleline)]
    private static partial Regex SeedsLineRegex();

    private static IReadOnlyCollection<long> GetSeeds(string seedsLine)
    {
        var matches = SeedsLineRegex().Match(seedsLine);

        return matches.Groups[1].Captures.Select(c => long.Parse(c.Value)).ToList();
    }
}