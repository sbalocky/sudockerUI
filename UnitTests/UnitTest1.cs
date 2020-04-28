using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudocker;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod1()
        {
            SmallGrid grid = new SmallGrid(new int[] { 1,3,4,5,6,7,8,7,2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {
            SmallGrid grid = new SmallGrid(new int[] { 1, 3, 4, 5, 6, 7, 8, 7 });
        }

        [TestMethod]      
        public void TestMethod3()
        {
            SmallGrid grid = new SmallGrid(new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 2 });
        }


        [TestMethod]
        public void TestMethod4()
        {
            SmallGrid grid = new SmallGrid(new int[] { 1, 3, 4, 5, 7, 6, 8, 9, 2 });
            var row = grid.GetRow(2);
            Assert.IsTrue(row.Item0 == 8 && row.Item1 == 9 && row.Item2 == 2);

            var row1 = grid.GetRow(0);
            Assert.IsTrue(row1.Item0 == 1 && row1.Item1 == 3 && row1.Item2 == 4);

            var row2 = grid.GetRow(1);
            Assert.IsTrue(row2.Item0 == 5 && row2.Item1 == 7 && row2.Item2 == 6);
        }


        [TestMethod]
        public void TestMethod5()
        {
            SmallGrid grid = new SmallGrid(new int[] { 1, 3, 4, 5, 7, 6, 8, 9, 2 });
            var column = grid.GetColumn(2);
            Assert.IsTrue(column.Item0 == 4 && column.Item1 == 6 && column.Item2 == 2);

            var column0 = grid.GetColumn(1);
            Assert.IsTrue(column0.Item0 == 3 && column0.Item1 == 7 && column0.Item2 == 9);

            var column1 = grid.GetColumn(0);
            Assert.IsTrue(column1.Item0 == 1 && column1.Item1 == 5 && column1.Item2 == 8);
        }

        [TestMethod]
        public void TestMethod7()
        {
            SmallGrid grid = new SmallGrid(new int[] { -1, 3, -1, -1, -1, 6, 8, 9, 2 });
            var possible = grid.GetPosibleNumbers();
            Assert.IsTrue(possible.Length == 4);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var grid1 = new SmallGrid(new int[9] { 2, 4, 6, 1, 8, 9, 5, 7, 3 });
            var grid2 = new SmallGrid(new int[9] { 8, 5, 7, 6, 4, 3, 2, 9, 1 });
            var grid3 = new SmallGrid(new int[9] { 9, 1, 3, 2, 7, 5, 4, 8, 6 });

            var grid4 = new SmallGrid(new int[9] { 4, 1, 8, 6, 3, 7, 9, 5, 2 });
            var grid5 = new SmallGrid(new int[9] { 3, 2, 9, 4, 8, 5, 1, 7, 6 });
            var grid6 = new SmallGrid(new int[9] { 5, 6, 7, 1, 2, 9, 3, 4, 8 });

            var grid7 = new SmallGrid(new int[9] { 7, 6, 4, 3, 2, 1, 8, 9, 5 });
            var grid8 = new SmallGrid(new int[9] { 5, 3, 2, 9, 6, 8, 7, 1, 4 });
            var grid9 = new SmallGrid(new int[9] { 8, 9, 1, 7, 5, 4, 6, 3, 2 });

            var state = new State(new PlayGrid(new SmallGrid[] { grid1, grid2, grid3, grid4, grid5, grid6, grid7, grid8, grid9 }));

            Assert.IsTrue(state.IsFinal());
        }

        [TestMethod]
        public void TestMethod8()
        {
            var grid1 = new SmallGrid(new int[9] { 2, 4, 6, 1, 8, 9, 5, 7, 3 });
            var grid2 = new SmallGrid(new int[9] { 8, 5, 7, 6, 4, 3, 2, 9, 1 });
            var grid3 = new SmallGrid(new int[9] { 9, 1, 3, 2, 7, 5, 4, 8, 6 });

            var grid4 = new SmallGrid(new int[9] { 4, 1, 8, 6, 3, 7, 9, 5, 2 });
            var grid5 = new SmallGrid(new int[9] { 3, 2, 9, 4, 8, 5, 1, 7, 6 });
            var grid6 = new SmallGrid(new int[9] { 5, 6, 7, 1, 2, 9, 3, 4, 8 });

            var grid7 = new SmallGrid(new int[9] { 7, 6, 4, 3, 2, 1, 8, 9, 5 });
            var grid8 = new SmallGrid(new int[9] { 5, 3, 2, 9, 6, 8, 7, 1, 4 });
            var grid9 = new SmallGrid(new int[9] { 8, 9, 1, 7, 5, 4, 6, 3, -1 });

            var state = new State(new PlayGrid(new SmallGrid[] { grid1, grid2, grid3, grid4, grid5, grid6, grid7, grid8, grid9 }));

            Assert.IsTrue(!state.IsSumValid());
        }

        [TestMethod]
        public void TestMethod9()
        {
            var grid1 = new SmallGrid(new int[9] { 2, 4, 6, 1, 8, 9, 5, 7, 3 });
            var grid2 = new SmallGrid(new int[9] { 8, 5, 7, 6, 4, 3, 2, 9, 1 });
            var grid3 = new SmallGrid(new int[9] { 9, 1, 3, 2, 7, 5, 4, 8, 6 });

            var grid4 = new SmallGrid(new int[9] { 4, 1, 8, 6, 3, 7, 9, 5, 2 });
            var grid5 = new SmallGrid(new int[9] { -1, 2, 9, 4, -1, 5, 1, 7, 6 });
            var grid6 = new SmallGrid(new int[9] { 5, 6, 7, 1, 2, 9, 3, 4, 8 });

            var grid7 = new SmallGrid(new int[9] { 7, 6, 4, 3, 2, 1, 8, 9, 5 });
            var grid8 = new SmallGrid(new int[9] { 5, 3, 2, 9, 6, 8, 7, 1, 4 });
            var grid9 = new SmallGrid(new int[9] { 8, 9, 1, 7, 5, 4, 6, 3, 2 });

            var playGrid = new PlayGrid(new SmallGrid[] { grid1, grid2, grid3, grid4, grid5, grid6, grid7, grid8, grid9 });

          // var numbers =  playGrid.GetPosibleNumbers(4, 4);
         //  Assert.IsTrue(numbers.Length == 1);
        }
    }
}
