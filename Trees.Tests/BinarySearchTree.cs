using NUnit.Framework;
using Trees.Shared;

namespace Trees.Tests
{
    [TestFixture]
    public class Tests
    {
        #region Fields and constants
        private BinarySearchTree BinarySearchTree;
        private TreeNode Root;
        #endregion

        [SetUp]
        public void Setup()
        {
            Root = new TreeNode(20, "secret_value");
            BinarySearchTree = new BinarySearchTree(Root);
        }

        [TearDown]
        public void Reset()
        {
            BinarySearchTree = new BinarySearchTree(Root);
        }

        [Test]
        public void InitBinarySearchTreeTest()
        {
            Assert.AreEqual(Root, BinarySearchTree.Root);
        }

        [Test]
        public void InsertTreeNodeLessThanRootNodeTest()
        {
            TreeNode treeNode  = new TreeNode(10, "less_than_root");
            BinarySearchTree.Insert(treeNode);
            Assert.AreEqual(treeNode, BinarySearchTree.Root.LeftChild);
        }

        [Test]
        public void InsertTreeNodeGreaterThanRootNodeTest()
        {
            TreeNode treeNode = new TreeNode(30, "greater_than_root");
            BinarySearchTree.Insert(treeNode);
            Assert.AreEqual(treeNode, BinarySearchTree.Root.RightChild);
        }

        [Test]
        public void InsertTreeNodeWithTheSameKeyTest()
        {
            TreeNode treeNode = new TreeNode(20, "different_value");
            BinarySearchTree.Insert(treeNode);
            Assert.AreEqual(treeNode.Value, BinarySearchTree.Root.Value);
        }
    }
}