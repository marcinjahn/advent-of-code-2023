namespace day_7;

public static class HandTypeRecognizerWithJoker
{
    public static HandType Recognize(string cards)
    {
        var sortedTypes = cards
            .GroupBy(c => c, (c, b) => (character: c, count: b.Count()))
            .OrderByDescending(g => g.count)
            .ToList();

        var sortedTypesWithoutJoker = sortedTypes.Where(g => g.character is not 'J').ToList();

        var thereAreNoJokers = sortedTypesWithoutJoker.Count == sortedTypes.Count;
        if (thereAreNoJokers) return HandTypeRecognizer.Recognize(cards);

        return sortedTypesWithoutJoker.Count switch
        {
            0 or 1 => HandType.FiveOfAKind,
            2 => (sortedTypesWithoutJoker[0].count, sortedTypesWithoutJoker[1].count) switch
            {
                (3, _) or (2, 1)  => HandType.FourOfAKind,
                (2, 2) => HandType.FullHouse,
                _ => HandType.OnePair,
            },
            3 => HandType.ThreeOfAKind,
            4 => HandType.OnePair,
            _ => throw new InvalidOperationException("Impossible amount of variations in hand")
        };
    }
}