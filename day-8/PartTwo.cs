namespace day_8;

public class PartTwo
{
    public static void Run()
    {
        var lines = File.ReadAllLines("./input.txt");

        var directions = lines[0];
        var (nodes, startingNodes) = AdvancesNodesDeserializer.Deserialize(lines.AsSpan()[2..]);

        var steps = MultipleTraverser.Traverse(nodes, startingNodes, directions);

        Console.WriteLine($"Part II: {steps}");
    }
}