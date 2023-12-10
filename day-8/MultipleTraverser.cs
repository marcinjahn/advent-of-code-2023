namespace day_8;
using StepsCount = long;

public class MultipleTraverser
{
    public static StepsCount Traverse(Dictionary<string, LeftAndRight> nodes, List<string> startingNodes, string directions)
    {
        var options = startingNodes.Select(node => nodes[node]).ToList();

        var loopLengths = options.Select(option =>
        {
            var steps = 0L;

            while (true)
            {
                foreach (var direction in directions)
                {
                    var choice = option.Choose(direction);
                    steps++;

                    if (choice.IsEnd())
                    {
                        return steps;
                    }

                    option = nodes[choice];
                }
            }
        }).ToList();

        var lcm = MathUtils.FindLcm(loopLengths);

        return lcm;
    }
}

file static class NodeExtensions
{
    public static bool IsEnd(this string node) => node[2] == 'Z';
}