using System.Text.RegularExpressions;

namespace day_6;

public static partial class PartOne
{
    public static void Run()
    {
        var lines = File.ReadLines("./input.txt").ToList();

        var races = GetRaces(lines).ToList();

        var result = 1;

        foreach (var race in races)
        {
            var (buttonTime1, buttonTime2) = QuadraticEquationSolver.Solve(-1, race.BestTime, -race.Distance);

            result *= GetValuesBetween(buttonTime1, buttonTime2).Count();
        }

        Console.WriteLine($"Part I: {result}");
    }

    private static IEnumerable<Race> GetRaces(IReadOnlyCollection<string> lines)
    {
        var times = GetNumbers(lines.ElementAt(0)).ToList();
        var distances = GetNumbers(lines.ElementAt(1)).ToList();

        for (var i = 0; i < times.Count; i++)
        {
            yield return new Race(times[i], distances[i]);
        }
    }

    private static IEnumerable<int> GetValuesBetween(double a, double b)
    {
        var min = double.Min(a, b);
        var max = double.Max(a, b);

        var minCeiling = (int)Math.Ceiling(min);
        min = min == minCeiling ? (int)min + 1 : minCeiling;

        var maxFloor = (int)Math.Floor(max);
        max = max == maxFloor ? (int)max - 1 : maxFloor;

        return Enumerable.Range((int)min, (int)(max - min + 1));
    }

    [GeneratedRegex(@"(\d+)", RegexOptions.Singleline)]
    private static partial Regex LineRegex();

    private static IEnumerable<long> GetNumbers(string line)
    {
        var matches = LineRegex().Matches(line);

        foreach (Match match in matches)
        {
            yield return int.Parse(match.Groups[0].Value);
        }
    }
}