namespace Puzzle.Solver
{
    public interface IPuzzleGraphBuilder
    {
        IPuzzleGraph BuildGraph(int[] input);
    }
}