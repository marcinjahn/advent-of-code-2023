namespace day_7;

public static class PartTwo
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        List<Hand> hands = [];
        await foreach (var line in lines)
        {
            hands.Add(Deserialize(line));
        }

        var handComparer = new HandComparer(new CardComparerWithJoker());
        var orderedHands = hands.Order(handComparer).ToList();

        long result = 0;

        for (var i = 0; i < orderedHands.Count; i++)
        {
            result += orderedHands[i].Bid * (i + 1);
        }

        Console.WriteLine($"Part II: {result}");
    }

    public static Hand Deserialize(string line)
    {
        var cards = line[..5];
        var bid = int.Parse(line[6..]);

        return new Hand(cards, bid, HandTypeRecognizerWithJoker.Recognize(cards));
    }
}