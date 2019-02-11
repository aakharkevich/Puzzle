using System;
using Puzzle.Solver;

namespace Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[10] { 1, 2, 3, 4, 6, 5, 8, 9, 7, 0 };
            var result = new PuzzleResolver().Solve(input);

            Console.WriteLine($"Input: {string.Join(", ", input)}");
            Console.WriteLine($"Result: {string.Join(", ", result)}");

            Console.ReadLine();
        }
    }
}
