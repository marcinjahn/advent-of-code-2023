namespace day_1;

public static class Digits
{
    public static Dictionary<string, int> StringsAndInts { get; } = new()
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 },
        { "three", 3},
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public static Dictionary<string, int> ReversedStringsAndInts { get; set; } = StringsAndInts.ToDictionary(
        kv => new string(kv.Key.Reverse().ToArray()),
        kv => kv.Value);
}