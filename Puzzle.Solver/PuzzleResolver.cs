using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle.Solver
{
    public class PuzzleResolver : IResolver
    {
        private const int FinalEmptyIndex = 3;
        private const int FinalEmptyValue = 0;

        private readonly IPuzzleGraphBuilder _graphBuilder;

        public PuzzleResolver()
        {
            _graphBuilder = new DefaultPuzzleGraphBuilder();
        }

        public PuzzleResolver(IPuzzleGraphBuilder graphBuilder)
        {
            _graphBuilder = graphBuilder ?? throw new ArgumentNullException(nameof(graphBuilder));
        }

        public int[] Solve(int[] input)
        {
            ValidateInput(input);

            var graph = _graphBuilder.BuildGraph(input);

            var emptyVertex = graph.GetVertexByValue(FinalEmptyValue);

            return FindPath(emptyVertex, new List<int>()).ToArray();
        }

        private static List<int> FindPath(IPuzzleVertex vertex, List<int> path)
        {
            var finalValue = GetFinalValueByIndex(vertex.Index);
            if (finalValue == FinalEmptyValue)
                return path;

            var nextVertex = vertex.Neighbors.FirstOrDefault(t => t.Value == finalValue);

            if (nextVertex == null)
                throw new TooComplicatedPuzzleException();

            path.Add(nextVertex.Value);

            return FindPath(nextVertex, path);
        }

        private static int GetFinalValueByIndex(int index)
        {
            if (index == FinalEmptyIndex)
                return FinalEmptyValue;

            if (index < FinalEmptyIndex)
                return index + 1;

            return index;
        }

        private void ValidateInput(int[] input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Length != 10)
                throw new ArgumentException("Array length must be equal to 10");

            if (input.Any(t => t < 0 || t > 9))
                throw new ArgumentException("Array must contain only numbers between 0 and 9");

            if (input.GroupBy(t => t).Any(t => t.Count() != 1))
                throw new ArgumentException("Array must not contain duplicate numbers");
        }
    }
}