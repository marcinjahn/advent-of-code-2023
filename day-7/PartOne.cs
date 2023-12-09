namespace day_7;

public static class PartOne
{
    public static async Task Run()
    {
        var lines = File.ReadLinesAsync("./input.txt");

        List<Hand> hands = [];
        await foreach (var line in lines)
        {
            hands.Add(Deserialize(line));
        }

        var handComparer = new HandComparer(new DefaultCardComparer());
        var orderedHands = hands.Order(handComparer).ToList();

        var result = 0;

        for (var i = 0; i < orderedHands.Count; i++)
        {
            result += orderedHands[i].Bid * (i + 1);
        }

        Console.WriteLine($"Part I: {result}");
    }

    public static Hand Deserialize(string line)
    {
        var cards = line[..5];
        var bid = int.Parse(line[6..]);

        return new Hand(cards, bid, HandTypeRecognizer.Recognize(cards));
    }
}