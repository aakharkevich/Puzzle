using System;

namespace Puzzle.Solver
{
    public class TooComplicatedPuzzleException: Exception
    {
        public override string Message
        {
            get { return "Puzzle is too complicated for now"; }
        }
    }
}