using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle.Solver
{
    internal class PuzzleGraph: IPuzzleGraph
    {
        private readonly Dictionary<int, PuzzleVertex> _vertexes = new Dictionary<int, PuzzleVertex>();

        public void AddVertex(int index, int value)
        {
            if (_vertexes.ContainsKey(index))
                throw new ArgumentException($"Vertex with index {index} already exists");

            if (_vertexes.Values.Any(t => t.Value == value))
                throw new ArgumentException($"Vertex with value {value} already exists");

            _vertexes[index] = new PuzzleVertex(index, value);
        }

        public void AddEdge(int firstIndex, int secondIndex)
        {
            var firstVertex = GetVertexByIndex(firstIndex);
            var secondVertex = GetVertexByIndex(secondIndex);

            firstVertex.AddNeighbor(secondVertex);
            secondVertex.AddNeighbor(firstVertex);
        }

        public IPuzzleVertex GetVertexByValue(int value)
        {
            var vertex = _vertexes.Values.SingleOrDefault(t => t.Value == value);

            if (vertex == null)
                throw new ArgumentException($"Vertex with value {value} not found");

            return vertex;
        }

        private PuzzleVertex GetVertexByIndex(int index)
        {
            if (!_vertexes.ContainsKey(index))
                throw new ArgumentException($"Vertex with index {index} not found");

            return _vertexes[index];
        }
    }
}