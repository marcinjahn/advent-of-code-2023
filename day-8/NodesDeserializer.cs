using Node = string;

namespace day_8;

public static class NodesDeserializer
{
    public static Dictionary<Node, LeftAndRight> Deserialize(Span<string> lines)
    {
        var nodes = new Dictionary<Node, LeftAndRight>(lines.Length);

        foreach (var line in lines)
        {
            nodes.Add(line[..3], new LeftAndRight(line[7..10], line[12..15]));
        }

        return nodes;
    }
}

public static class AdvancesNodesDeserializer
{
    public static (Dictionary<Node, LeftAndRight> Nodes, List<Node> StartingNodes) Deserialize(Span<string> lines)
    {
        var nodes = new Dictionary<Node, LeftAndRight>(lines.Length);
        var startingNodes = new List<Node>();

        foreach (var line in lines)
        {
            var node = line[..3];

            if (node[2] == 'A')
            {
                startingNodes.Add(node);
            }

            nodes.Add(node, new LeftAndRight(line[7..10], line[12..15]));
        }

        return (nodes, startingNodes);
    }
}