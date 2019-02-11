using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle.Solver
{
    internal class PuzzleVertex: IPuzzleVertex
    {
        private readonly List<PuzzleVertex> _neighbors = new List<PuzzleVertex>();

        public int Index { get; }
        public int Value { get; }

        public IEnumerable<IPuzzleVertex> Neighbors
        {
            get { return _neighbors; }
        }

        public PuzzleVertex(int index, int value)
        {
            Index = index;
            Value = value;
        }

        public void AddNeighbor(PuzzleVertex neighbor)
        {
            if (_neighbors.Any(t => IsEquals(t)))
                throw new ArgumentException("Neighbor already exists");

            _neighbors.Add(neighbor);
        }

        private bool IsEquals(PuzzleVertex vertex)
        {
            return vertex.Index == Index && vertex.Value == Value;
        }
    }
}