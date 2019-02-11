namespace Puzzle.Solver
{
    internal class DefaultPuzzleGraphBuilder : IPuzzleGraphBuilder
    {
        public IPuzzleGraph BuildGraph(int[] input)
        {
            var graph = new PuzzleGraph();
            for (var i = 0; i < input.Length; i++)
            {
                graph.AddVertex(i, input[i]);
            }

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 6);
            graph.AddEdge(5, 7);
            graph.AddEdge(6, 8);
            graph.AddEdge(7, 8);
            graph.AddEdge(7, 9);
            graph.AddEdge(8, 9);

            return graph;
        }
    }
}