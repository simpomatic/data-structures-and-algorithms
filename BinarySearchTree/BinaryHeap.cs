using Trees.Shared;

namespace Trees
{
    public enum HeapOrderingType
    {
        Max,
        Min
    }

    public class BinaryHeap
    {
        #region Constants and fields
        private HeapOrderingType HeapOrderingType;
        private TreeNode Root;
        #endregion

        public BinaryHeap(HeapOrderingType heapOrderingType)
        {
            HeapOrderingType = heapOrderingType;
            Root = null;
        }

        public BinaryHeap(HeapOrderingType heapOrderingType, TreeNode treeNode)
        {
            HeapOrderingType = heapOrderingType;
            Root = treeNode;
        }

        private void SwapTreeNodes(ref TreeNode parentNode, ref TreeNode childNode)
        {
            TreeNode temp = parentNode;
            // Swap child node into parent's place
            parentNode.Key = childNode.Key;
            parentNode.Value = childNode.Value;
            // Using the temporary tree node, put the parent in the child's place
            childNode.Key = temp.Key;
            childNode.Value = temp.Value;
        }

        private void PercolateUp(TreeNode treeNode)
        {
            if (HeapOrderingType == HeapOrderingType.Max)
            {
                if (treeNode.Depth > 0 && treeNode.Parent.Key < treeNode.Key)
                {
                    TreeNode parentNode = treeNode.Parent;
                    SwapTreeNodes(ref parentNode, ref treeNode);
                    // Run the same logic again on the parent (formerly the given tree node)
                    PercolateUp(parentNode);
                }
            }
            else
            {
                if (treeNode.Depth > 0 && treeNode.Parent.Key > treeNode.Key)
                {
                    TreeNode parentNode = treeNode.Parent;
                    SwapTreeNodes(ref parentNode, ref treeNode);
                    // Run the same logic again on the parent (formerly the given tree node)
                    PercolateUp(parentNode);
                }
            }
        }

        public void Insert(TreeNode treeNode)
        {
            // Insert the tree node into the binary heap
            if (Root == null)
            {
                Root = treeNode;
            } else
            {
                TreeNode lastTreeNode = TreeTraversals.BreadthFirstTraversal(Root, Root.Depth + 1);
                if (!lastTreeNode.HasLeftChild())
                {
                    treeNode.Parent = lastTreeNode;
                    lastTreeNode.LeftChild = treeNode;
                    // Percolate the given tree node up to satisfy the heap ordering property based on the type of heap
                    PercolateUp(lastTreeNode.LeftChild);
                } else
                {
                    treeNode.Parent = lastTreeNode;
                    lastTreeNode.RightChild = treeNode;
                    // Percolate the given tree node up to satisfy the heap ordering property based on the type of heap
                    PercolateUp(lastTreeNode.LeftChild);
                }
            }
        }
    }
}
