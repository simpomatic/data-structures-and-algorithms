using NUnit.Framework;
using System;
using System.IO;
using Trees.Shared;

namespace Trees.Tests
{
    [TestFixture]
    public class TreeTraversalTests
    {
        #region Fields and constants
        private TreeNode Root;
        #endregion

        [SetUp]
        public void Setup()
        {
            Root = new TreeNode(18, "a");
            Root.LeftChild = new TreeNode(20, "b");
            Root.LeftChild.Parent = Root;
            Root.RightChild = new TreeNode(21, "c");
            Root.RightChild.Parent = Root;
            Root.LeftChild.LeftChild = new TreeNode(9, "d");
            Root.LeftChild.LeftChild.Parent = Root.LeftChild;
            Root.LeftChild.RightChild = new TreeNode(81, "e");
            Root.LeftChild.RightChild.Parent = Root.LeftChild;
            Root.RightChild.LeftChild = new TreeNode(24, "f");
            Root.RightChild.LeftChild.Parent = Root.RightChild;
            Root.RightChild.RightChild = new TreeNode(37, "g");
            Root.RightChild.RightChild.Parent = Root.RightChild;
        }

        [Test]
        public void BreadthFirstTraversalTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                TreeTraversals.BreadthFirstTraversal(Root, Root.Depth + 1, true);

                string expected = "[18:a] => [20:b] => [21:c] => [9:d] => ";
                string actual = sw.ToString();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
