using NUnit.Framework;
using ConsoleApp47;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void TestBySum()
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r1 = new int[,] { { 7, 3, 4 }, { 1, 9, 6 }, { 6, 2, 10 }, { 8, 7, 5 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r1);
        }
        [Test]
        public void TestBySumDesc()
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r2 = new int[,] { { 8, 7, 5 }, { 6, 2, 10 }, { 1, 9, 6 }, { 7, 3, 4 } };
            sortAl.SetAlgotithm(BySumElements.Sort);
            m = sortAl.SortMatrix(m, false);
            Assert.AreEqual(m, r2);
        }
        [Test]
        public void TestByMax()
        {
            var sortAl = new SortAlgotithm(ByMaxElement.Sort);
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r1 = new int[,] { { 7, 3, 4 }, { 8, 7, 5 }, { 1, 9, 6 }, { 6, 2, 10 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r1);
        }
        [Test]
        public void TestByMaxDesc()
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r2 = new int[,] { { 6, 2, 10 }, { 1, 9, 6 }, { 8, 7, 5 }, { 7, 3, 4 } };
            sortAl.SetAlgotithm(ByMaxElement.Sort);
            m = sortAl.SortMatrix(m, false);
            Assert.AreEqual(m, r2);
        }
        [Test]
        public void TestByMin()
        {
            var sortAl = new SortAlgotithm(ByMinElement.Sort);
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r1 = new int[,] { { 1, 9, 6 }, { 6, 2, 10 }, { 7, 3, 4 }, { 8, 7, 5 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r1);
        }
        [Test]
        public void TestByMinDesc()
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2, 10 }, { 8, 7, 5 }, { 1, 9, 6 }, { 7, 3, 4 } };
            int[,] r2 = new int[,] { { 8, 7, 5 }, { 7, 3, 4 }, { 6, 2, 10 }, { 1, 9, 6 } };
            sortAl.SetAlgotithm(ByMinElement.Sort);
            m = sortAl.SortMatrix(m, false);
            Assert.AreEqual(m, r2);
        }
        [Test]
        public void TestAnotherMatrix()
        {
            var sortAl = new SortAlgotithm();
            int[,] m = new int[,] { { 6, 2}, { 8, 7, }, { 1, 9 } };
            int[,] r = new int[,] { { 6, 2 }, { 1, 9 } , { 8, 7 }};
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r);
        }
        [Test]
        public void TestAnotherMatrix2()
        {
            var sortAl = new SortAlgotithm(ByMinElement.Sort);
            int[,] m = new int[,] { { 6, 2 }, { 2, 7, }, { 1, 9 } };
            int[,] r = new int[,] { { 1, 9 }, { 6, 2 }, { 2, 7 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r);
        }
        [Test]
        public void TestAnotherMatrix3()
        {
            var sortAl = new SortAlgotithm(ByMaxElement.Sort);
            int[,] m = new int[,] { { 6, 6 }, { 7, 7, }, { 0, 0 } };
            int[,] r = new int[,] { { 0, 0 }, { 6, 6 }, { 7, 7 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r);
        }
        [Test]
        public void TestAnotherMatrix4()
        {
            var sortAl = new SortAlgotithm(ByMaxElement.Sort);
            int[,] m = new int[,] { { 6, 6 }, { 5, 6, }, { 0, 6 } };
            int[,] r = new int[,] { { 6, 6 }, { 5, 6, }, { 0, 6 } };
            m = sortAl.SortMatrix(m);
            Assert.AreEqual(m, r);
        }
    }
}