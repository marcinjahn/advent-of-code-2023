namespace day_7;

public class CardComparerWithJoker : Comparer<char>
{
    private readonly List<char> _lowToHigh = ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'];

    public override int Compare(char x, char y)
    {
        if (x == y) return 0;

        if (x is 'J') return -1;
        if (y is 'J') return 1;

        if (char.IsDigit(x) && char.IsDigit(y)) return x > y ? 1 : -1;
        if (char.IsDigit(x) && char.IsLetter(y)) return -1;
        if (char.IsLetter(x) && char.IsDigit(y)) return 1;

        var indexOfX = _lowToHigh.IndexOf(x);
        if (indexOfX is -1) throw new ArgumentException($"Unsupported card was provided: {x}");

        var indexOfY = _lowToHigh.IndexOf(y);
        if (indexOfY is -1) throw new ArgumentException($"Unsupported card was provided: {y}");

        if (indexOfX < indexOfY) return -1;
        if (indexOfX > indexOfY) return 1;

        return 0;
    }
}