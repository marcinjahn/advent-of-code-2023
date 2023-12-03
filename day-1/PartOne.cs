namespace day_1;

public static class PartOne
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        var result = 0;

        await foreach (var line in lines)
        {
            result += GetCalibrationValue(line);
        }

        Console.WriteLine($"Part I: the result is {result}");
    }

    private static int GetCalibrationValue(string line)
    {
        var value = 0;
        foreach (var character in line)
        {
            if (char.IsNumber(character))
            {
                value = ConvertToInt(character) * 10;
                break;
            }
        }

        for (var i = line.Length - 1; i >= 0; i--)
        {
            var character = line[i];

            if (char.IsNumber(character))
            {
                value += ConvertToInt(character);
                break;
            }
        }

        return value;
    }

    private static int ConvertToInt(char character) => character - '0';
}