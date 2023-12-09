using System.Text.RegularExpressions;

namespace day_6;

public static partial class PartTwo
{
    public static void Run()
    {
        var lines = File.ReadLines("./input.txt").ToList();

        var race = GetRace(lines);

        var (buttonTime1, buttonTime2) = QuadraticEquationSolver.Solve(-1, race.BestTime, -race.Distance);
        var result = GetValuesBetween(buttonTime1, buttonTime2).Count();

        Console.WriteLine($"Part II: {result}");
    }

    private static Race GetRace(IReadOnlyCollection<string> lines)
    {
        var time = GetNumber(lines.ElementAt(0));
        var distance = GetNumber(lines.ElementAt(1));

        return new Race(time, distance);
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

    private static long GetNumber(string line)
    {
        var matches = LineRegex().Matches(line);

        var totalLength = matches.Sum(match => match.Value.Length);

        var numberAsString = string.Create(totalLength, matches, (span, state) =>
        {
            var index = 0;

            for (var i = 0; i < state.Count; i++)
            {
                state[i].Value.AsSpan().CopyTo(span[index..]);
                index += state[i].Value.Length;
            }
        });

        return long.Parse(numberAsString);
    }
}