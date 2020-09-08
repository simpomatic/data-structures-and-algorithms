using System;
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

        /// <summary>
        /// Returns the maximum number of possible nodes for the given depth.
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <returns>Maximum number of possible nodes for the given depth</returns>
        private int GetMaxTheoreticalCount(int depth)
        {
            return (2 * (int) Math.Pow(2, depth)) - 1;
        }

        /// <summary>
        /// Sever/trim the the given tree node from its parent.
        /// </summary>
        /// <param name="treeNode">Tree node to be trimmed/severed</param>
        private void TrimTreeNode(ref TreeNode treeNode)
        {
            if (treeNode.IsRightChild())
            {
                treeNode.Parent.RightChild = null;
            }
            else
            {
                treeNode.Parent.LeftChild = null;
            }
        }

        /// <summary>
        /// Swaps the key/value pairs between the two given tree nodes. This is done by reference and only
        /// the key and values are swapped, to maintain the same tree structure.
        /// </summary>
        /// <param name="firstTreeNode"></param>
        /// <param name="secondTreeNode"></param>
        private void SwapTreeNodes(ref TreeNode firstTreeNode, ref TreeNode secondTreeNode)
        {
            TreeNode temp = firstTreeNode;
            // Swap child node into parent's place
            firstTreeNode.Key = secondTreeNode.Key;
            firstTreeNode.Value = secondTreeNode.Value;
            // Using the temporary tree node, put the parent in the child's place
            secondTreeNode.Key = temp.Key;
            secondTreeNode.Value = temp.Value;
        }

        private bool PercolateDownHelper(ref TreeNode firstTreeNode, ref TreeNode secondTreeNode)
        {
            if (HeapOrderingType == HeapOrderingType.Max)
            {
                if (secondTreeNode.Key > firstTreeNode.Key)
                {
                    SwapTreeNodes(ref firstTreeNode, ref secondTreeNode);
                    return true;
                }

                return false;
            }
            else
            {
                if (secondTreeNode.Key < firstTreeNode.Key)
                {
                    SwapTreeNodes(ref firstTreeNode, ref secondTreeNode);
                    return true;
                }

                return false;
            }
        }

        private void PercolateDown(TreeNode treeNode)
        {
            int leftSubTreeCount = treeNode.HasLeftChild() ? treeNode.LeftChild.Count : 0;
            int rightSubTreeCount = treeNode.HasLeftChild() ? treeNode.RightChild.Count : 0;
            int leftSubTreeMaxDepth = treeNode.HasLeftChild() ? treeNode.LeftChild.MaxDepth - treeNode.LeftChild.Depth : 0;
            int rightSubTreeMaxDepth = treeNode.HasRightChild() ? treeNode.RightChild.MaxDepth - treeNode.RightChild.Depth : 0;

            if (GetMaxTheoreticalCount(leftSubTreeMaxDepth) == leftSubTreeCount && GetMaxTheoreticalCount(rightSubTreeMaxDepth) == rightSubTreeCount || GetMaxTheoreticalCount(rightSubTreeMaxDepth) == rightSubTreeMaxDepth)
            {
                TreeNode childNode = treeNode.LeftChild;
                if (PercolateDownHelper(ref treeNode, ref childNode))
                {
                    PercolateDown(treeNode);
                }
            }
            else
            {
                TreeNode childNode = treeNode.RightChild;
                if (PercolateDownHelper(ref treeNode, ref childNode))
                {
                    PercolateDown(treeNode);
                }
            }
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
                    // Percolate up the given tree node up to satisfy the heap ordering property based on the type of heap
                    PercolateUp(lastTreeNode.LeftChild);
                } else
                {
                    treeNode.Parent = lastTreeNode;
                    lastTreeNode.RightChild = treeNode;
                    // Percolate up the given tree node up to satisfy the heap ordering property based on the type of heap
                    PercolateUp(lastTreeNode.LeftChild);
                }
            }
        }

        public TreeNode Top()
        {
            TreeNode rootNode = Root;
            TreeNode currentNode = TreeTraversals.BreadthFirstTraversal(Root, Root.Depth + 1);
            // Swap the root with the last entry in the tree and then remove the root which is now located at the end of the tree
            if (currentNode.IsLeaf() && currentNode.IsLeftChild() && currentNode.Parent.HasRightChild() && currentNode.Depth > 1)
            {
                int counter = currentNode.Depth;
                int maxDepth = currentNode.Depth;
                TreeNode temp = currentNode;

                // Traverse to the root
                while (0 < counter)
                {
                    temp = temp.Parent;
                    counter--;
                }
                // Traverse back down to the right side of the tree
                while (counter < maxDepth)
                {
                    temp = temp.RightChild;
                    counter++;
                }

                SwapTreeNodes(ref Root, ref temp);
                TrimTreeNode(ref temp);
            } else
            {
                SwapTreeNodes(ref Root, ref currentNode);
                TrimTreeNode(ref currentNode);
            }

            // The tree might not be satisfying the heap ordering property anymore after the swap, so percolate down from the root to satisfy the property
            PercolateDown(Root);
            return rootNode;
        }
    }
}
