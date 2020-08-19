namespace Trees.Shared
{
    public class TreeNode
    {
        #region Fields and constants
        public int key { get; set; }
        public string value { get; set; }
        public TreeNode leftChild { get; set; }
        public TreeNode rightChild { get; set; }
        public TreeNode parent { get; set; }
        #endregion

        public TreeNode(
            int key,
            string value,
            TreeNode leftChild = null,
            TreeNode rightChild = null,
            TreeNode parent = null
        ) {
            this.key = key;
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
            this.parent = parent;
        }

        public bool hasLeftChild()
        {
            return leftChild != null;
        }

        public bool hasRightChild()
        {
            return rightChild != null;
        }

        public bool isLeftChild()
        {
            return parent != null && parent.leftChild == this;
        }

        public bool isRightChild()
        {
            return parent != null && parent.rightChild == this;
        }

        public bool isRoot()
        {
            return parent == null;
        }

        public bool isLeaf()
        {
            return rightChild == null && leftChild == null;
        }
    }
}
