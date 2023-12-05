namespace day_3;

public static class PartTwo
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;

        var enumerator = lines.GetAsyncEnumerator();

        if (!await enumerator.MoveNextAsync())
        {
            throw new InvalidDataException("Provided input has no data");
        }

        State? state = null;

        while (true)
        {
            if (state?.NextLine is null && state?.PreviousLine is not null)
            {
                break;
            }

            state = await GetNewState(state, enumerator);
            var gearPositions = GetGearPositions(state).ToList();
            var parts = GetParts(state);

            result += AnalyzeParts(parts, gearPositions);
        }

        Console.WriteLine($"Part II: {result}");
    }

    private static int AnalyzeParts(List<Part> parts, List<int> gearPositions)
    {
        var result = 0;

        foreach (var gearPosition in gearPositions)
        {
            var neighbours = parts.Where(part => IsNeighbour(part, gearPosition)).ToList();

            if (neighbours.Count != 2)
            {
                continue;
            }

            result += neighbours[0].Value * neighbours[1].Value;
        }

        return result;
    }

    private static bool IsNeighbour(Part part, int gearPosition) =>
        part.StartIndex - 1 <= gearPosition && gearPosition <= part.StartIndex + part.Length;

    private static List<Part> GetParts(State state)
    {
        var result = new List<Part>();

        if (state.PreviousLine is not null)
        {
            result.AddRange(GetParts(state.PreviousLine));
        }

        result.AddRange(GetParts(state.CurrentLine));

        if (state.NextLine is not null)
        {
            result.AddRange(GetParts(state.NextLine));
        }

        return result;
    }

    private static IEnumerable<Part> GetParts(string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            if (!char.IsNumber(line[i]))
            {
                continue;
            }

            var startIndex = i;

            ReadOnlySpan<char> span;
            do
            {
                span = line.AsSpan().Slice(startIndex, i - startIndex + 1);
                i++;
            } while (i < line.Length && char.IsNumber(line[i]));

            yield return new Part(int.Parse(span), startIndex, span.Length);
        }
    }

    private static IEnumerable<int> GetGearPositions(State state)
    {
        for (var i = 0; i < state.CurrentLine.Length; i++)
        {
            if (state.CurrentLine[i] == '*')
            {
                yield return i;
            }
        }
    }

    private static async Task<State> GetNewState(State? oldState, IAsyncEnumerator<string> enumerator) =>
        new(
            oldState?.CurrentLine,
            oldState?.NextLine ?? enumerator.Current,
            await enumerator.MoveNextAsync() ? enumerator.Current : null);
}