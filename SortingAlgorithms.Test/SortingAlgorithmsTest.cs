using NUnit.Framework;
using System;

namespace SortingAlgorithms.Tests
{
    [TestFixture]
    public class Tests
    {
        #region Constants and fields
        private int[] sortedArray;
        private int[] unsortedArray;
        #endregion

        [SetUp]
        public void Setup()
        {
            sortedArray = new int[] { 1, 17, 22, 45, 67, 123, 180, 457, 540, 1024 };
            unsortedArray = new int[] { 123, 45, 67, 22, 1, 540, 1024, 457, 17, 180 };
        }

        [Test]
        public void InsertionSortTest()
        {
            int[] possiblySortedArray = (new InsertionSort()).Sort(unsortedArray);
            Assert.AreEqual(sortedArray, possiblySortedArray);
        }

        [Test]
        public void MergeSortTest()
        {
            int[] possiblySortedArray = (new MergeSort()).Sort(unsortedArray);
            Assert.AreEqual(sortedArray, possiblySortedArray);
        }

        [Test]
        public void QuickSortTest()
        {
            int[] possiblySortedArray = (new QuickSort()).Sort(unsortedArray);
            Assert.AreEqual(sortedArray, possiblySortedArray);
        }

        [Test]
        public void SelectionSortTest()
        {
            int[] possiblySortedArray = (new SelectionSort()).Sort(unsortedArray);
            Assert.AreEqual(sortedArray, possiblySortedArray);
        }

        [Test]
        public void ShellSortTest()
        {
            int[] possiblySortedArray = (new ShellSort()).Sort(unsortedArray);
            Assert.AreEqual(sortedArray, possiblySortedArray);
        }
    }
}