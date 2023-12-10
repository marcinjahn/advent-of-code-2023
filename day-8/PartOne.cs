namespace day_8;

public class PartOne
{
    public static void Run()
    {
        var lines = File.ReadAllLines("./input.txt");

        var directions = lines[0];
        var nodes = NodesDeserializer.Deserialize(lines.AsSpan()[2..]);

        var steps = Traverser.Traverse(nodes, directions);

        Console.WriteLine($"Part I: {steps}");
    }
}