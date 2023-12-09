namespace day_6;

public static class QuadraticEquationSolver
{
    public static (double x1, double x2) Solve(long a, long b, long c)
    {
        var delta = b * b - 4 * a * c;

        var sqrtDelta = Math.Sqrt(delta);

        return (
            x1: (-b - sqrtDelta)/(2 * a),
            x2: (-b + sqrtDelta)/(2 * a)
        );
    }
}