using System.Text.RegularExpressions;

namespace day_2;

public static partial class ColorRegexes
{
    [GeneratedRegex("(\\d*) red", RegexOptions.Singleline)]
    private static partial Regex RedRegex();
    public static int GetMaxNumberOfRed(string line) => GetMaxValue(line, RedRegex());

    [GeneratedRegex("(\\d*) green", RegexOptions.Singleline)]
    private static partial Regex GreenRegex();
    public static int GetMaxNumberOfGreen(string line) => GetMaxValue(line, GreenRegex());

    [GeneratedRegex("(\\d*) blue", RegexOptions.Singleline)]
    private static partial Regex BlueRegex();
    public static int GetMaxNumberOfBlue(string line) => GetMaxValue(line, BlueRegex());

    private static int GetMaxValue(string line, Regex regex) =>
        regex.Matches(line).Max(r => int.Parse(r.Groups.Values.ElementAt(1).Value));
}