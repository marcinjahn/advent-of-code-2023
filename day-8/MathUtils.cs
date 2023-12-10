namespace day_8;

public static class MathUtils
{
    public static long FindLcm(List<long> numbers)
    {
        var lcm = numbers[0];

        for (var i = 1; i < numbers.Count; i++) {
            lcm = lcm * numbers[i] / Gcd(lcm, numbers[i]);
        }

        return lcm;
    }

    private static long Gcd(long number1, long number2)
    {
        return number2 is 0 ?
            number1 :
            Gcd(number2, number1 % number2);
    }
}