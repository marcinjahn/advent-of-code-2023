namespace day_8;
using StepsCount = int;

public static class Traverser
{
    public static StepsCount Traverse(Dictionary<string, LeftAndRight> nodes, string directions)
    {
        var options = nodes["AAA"];
        var steps = 0;

        while(true)
        {
            foreach (var direction in directions)
            {
                var choice = options.Choose(direction);
                steps++;

                if (choice is "ZZZ")
                {
                    return steps;
                }

                options = nodes[choice];
            }
        }
    }
}