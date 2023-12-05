namespace day_3;

public static class PartOne
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
            var symbolPositions = GetSymbolPositions(state);
            var parts = GetParts(state).ToList();

            result += AnalyzeParts(parts, symbolPositions);
        }

        Console.WriteLine($"Part I: {result}");
    }

    private static int AnalyzeParts(List<Part> parts, List<int> symbolPositions)
    {
        var result = 0;
        foreach (var part in parts)
        {
            for (var i = part.StartIndex - 1; i <= part.StartIndex + part.Length; i++)
            {
                if (symbolPositions.Contains(i))
                {
                    result += part.Value;
                    break;
                }
            }
        }

        return result;
    }

    private static IEnumerable<Part> GetParts(State state)
    {
        for (var i = 0; i < state.CurrentLine.Length; i++)
        {
            if (!char.IsNumber(state.CurrentLine[i]))
            {
                continue;
            }

            var startIndex = i;

            ReadOnlySpan<char> span;
            do
            {
                span = state.CurrentLine.AsSpan().Slice(startIndex, i - startIndex + 1);
                i++;
            } while (i < state.CurrentLine.Length && char.IsNumber(state.CurrentLine[i]));

            yield return new Part(int.Parse(span), startIndex, span.Length);
        }
    }

    private static List<int> GetSymbolPositions(State state)
    {
        var result = new List<int>();

        if (state.PreviousLine is not null)
        {
            result.AddRange(GetSymbolPositions(state.PreviousLine));
        }

        result.AddRange(GetSymbolPositions(state.CurrentLine));

        if (state.NextLine is not null)
        {
            result.AddRange(GetSymbolPositions(state.NextLine));
        }

        return result;
    }

    private static IEnumerable<int> GetSymbolPositions(string line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            if (char.IsNumber(line[i]) || line[i] == '.')
            {
                continue;
            }

            yield return i;
        }
    }

    private static async Task<State> GetNewState(State? oldState, IAsyncEnumerator<string> enumerator) =>
        new(
            oldState?.CurrentLine,
            oldState?.NextLine ?? enumerator.Current,
            await enumerator.MoveNextAsync() ? enumerator.Current : null);
}

internal record State(string? PreviousLine, string CurrentLine, string? NextLine);

internal record Part(int Value, int StartIndex, int Length);