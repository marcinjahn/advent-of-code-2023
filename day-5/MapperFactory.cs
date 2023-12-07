using System.Text.RegularExpressions;

namespace day_5;

public static partial class MapperFactory
{
    public static Mapper CreateMapper(ReadOnlySpan<string> lines)
    {
        var maps = new List<Map>(7);

        var linesToSkip = 0;
        for (var i = 0; i < 7; i++)
        {
            linesToSkip += 2;
            var startIndex = linesToSkip;

            while (linesToSkip < lines.Length)
            {
                var line = lines[linesToSkip];
                if (line.Length is 0 || !char.IsDigit(line[0]))
                {
                    break;
                }

                linesToSkip++;
            }

            maps.Add(CreateMap(lines[startIndex..linesToSkip]));
        }

        return new Mapper(
            maps[0],
            maps[1],
            maps[2],
            maps[3],
            maps[4],
            maps[5],
            maps[6]);
    }

    private static Map CreateMap(ReadOnlySpan<string> mappingLines)
    {
        var ranges = new List<Range>(mappingLines.Length);

        foreach (var line in mappingLines)
        {
            var match = MappingLineRegex().Match(line);

            var sourceStart = long.Parse(match.Groups[2].Value);
            var destinationStart = long.Parse(match.Groups[1].Value);
            var length = long.Parse(match.Groups[3].Value);

            ranges.Add(new Range(
                sourceStart,
                destinationStart,
                destinationStart - sourceStart,
                length));
        }

        return new Map(ranges);
    }

    [GeneratedRegex(@"(\d+) (\d+) (\d+)", RegexOptions.Singleline)]
    private static partial Regex MappingLineRegex();
}