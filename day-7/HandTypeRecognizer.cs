namespace day_7;

public static class HandTypeRecognizer
{
    public static HandType Recognize(string cards)
    {
        var sortedTypes = cards
            .GroupBy(c => c, (c, b) => (character: c, count: b.Count()))
            .OrderByDescending(g => g.count)
            .ToList();

        return sortedTypes.Count switch
        {
            1 => HandType.FiveOfAKind,
            2 => sortedTypes[0].count switch
            {
                4 => HandType.FourOfAKind,
                3 => HandType.FullHouse,
                _ => throw new InvalidOperationException("Impossible hand with 2 card types")
            },
            3 => (sortedTypes[0].count, sortedTypes[1].count, sortedTypes[2].count) switch
            {
                (3, _, _) => HandType.ThreeOfAKind,
                (2, 2, _) => HandType.TwoPair,
                _ => throw new InvalidOperationException("Impossible hand with 3 card types")
            },
            4 => HandType.OnePair,
            5 => HandType.HighCard,
            _ => throw new InvalidOperationException("Impossible amount of variations in hand")
        };
    }
}