using Node = string;

namespace day_8;

public record LeftAndRight(Node Left, Node Right);

public static class LeftAndRightExtensions
{
    public static Node Choose(this LeftAndRight leftAndRight, char direction) =>
        direction switch
        {
            'L' => leftAndRight.Left,
            'R' => leftAndRight.Right,
            _ => throw new NotSupportedException("Only L and R directions are supported")
        };
}