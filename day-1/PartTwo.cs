namespace day_1;

public static class PartTwo
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;

        await foreach (var line in lines)
        {
            var digits = GetAllDigits(line);

            result += digits[digits.Keys.Min()] * 10 + digits[digits.Keys.Max()];
        }

        Console.WriteLine($"Part II: the result is {result}");
    }

    /// <summary>
    /// Returns index,digit pairs
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private static Dictionary<int, int> GetAllDigits(string line)
    {
        var result = new Dictionary<int, int>();

        for (var i = 0; i < line.Length; i++)
        {
            var character = line[i];

            if (char.IsNumber(character))
            {
                result.Add(i, ConvertToInt(character));
            }
        }

        foreach (var potentialSpelledOutDigit in Digits.StringsAndInts.Keys)
        {
            var index = line.IndexOf(potentialSpelledOutDigit, StringComparison.Ordinal);
            if (index != -1)
            {
                var value = Digits.StringsAndInts[potentialSpelledOutDigit];
                result.Add(index, value);

                var lastIndex = line.LastIndexOf(potentialSpelledOutDigit, StringComparison.Ordinal);
                if (lastIndex != index)
                {
                    result.Add(lastIndex, value);
                }
            }
        }

        return result;
    }

    private static int ConvertToInt(char character) => character - '0';
}