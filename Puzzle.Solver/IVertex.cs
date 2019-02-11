using System.Collections.Generic;

namespace Puzzle.Solver
{
    public interface IPuzzleVertex
    {
        int Index { get; }
        int Value { get; }

        IEnumerable<IPuzzleVertex> Neighbors { get; }
    }
}