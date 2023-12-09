namespace day_7;

public class HandComparer : Comparer<Hand>
{
    private readonly Comparer<char> _cardComparer;

    public HandComparer(Comparer<char> cardComparer)
    {
        _cardComparer = cardComparer;
    }

    public override int Compare(Hand? x, Hand? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;

        if (x.HandType > y.HandType) return 1;
        if (x.HandType < y.HandType) return -1;

        if (x.Cards == y.Cards) return 0;

        for (var i = 0; i < x.Cards.Length; i++)
        {
            var cardOrder = _cardComparer.Compare(x.Cards[i], y.Cards[i]);

            if (cardOrder is not 0) return cardOrder;
        }

        throw new InvalidOperationException("Comparison logic is broken!");
    }
}