using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Puzzle.Solver.Tests
{
    [TestClass]
    public class PuzzleResolverTests
    {
        [TestMethod]
        public void EmptyCellInTheEndTest()
        {
            var input = new int[10] { 1, 2, 3, 4, 6, 5, 8, 9, 7, 0 };
            var expectedResult = new int[5] { 9, 7, 8, 6, 4 };

            var resolver = new PuzzleResolver();
            var result = resolver.Solve(input);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void EmptyCellInCenterTest()
        {
            var input = new int[10] { 1, 2, 3, 4, 6, 5, 0, 7, 8, 9 };
            var expectedResult = new int[2] {6, 4};

            var resolver = new PuzzleResolver();
            var result = resolver.Solve(input);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void EmptyCellInTheBeginningTest()
        {
            var input = new int[10] { 0, 1, 3, 4, 2, 5, 6, 7, 8, 9 };
            var expectedResult = new int[3] { 1, 2, 4 };

            var resolver = new PuzzleResolver();
            var result = resolver.Solve(input);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FinalPositionTest()
        {
            var input = new int[10] { 1, 2, 3, 0, 4, 5, 6, 7, 8, 9 };
            var expectedResult = new int[0] { };

            var resolver = new PuzzleResolver();
            var result = resolver.Solve(input);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(TooComplicatedPuzzleException))]
        public void ComplicatedCaseTest()
        {
            var input = new int[10] { 0, 2, 3, 1, 4, 5, 6, 7, 8, 9 };
            var resolver = new PuzzleResolver();
            resolver.Solve(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputIsNullTest()
        {
            var resolver = new PuzzleResolver();
            resolver.Solve(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputLengthIsIncorrectTest()
        {
            var resolver = new PuzzleResolver();
            resolver.Solve(new int[15]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputContainsIncorrectValuesTest()
        {
            var input = new int[10] {1, 2, 3, 4, -5, 6, 7, 8, 23, 9};
            var resolver = new PuzzleResolver();
            resolver.Solve(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputContainsDuplicatedValuesTest()
        {
            var input = new int[10] { 1, 2, 3, 4, 5, 5, 7, 8, 9, 9 };
            var resolver = new PuzzleResolver();
            resolver.Solve(input);
        }
    }
}
