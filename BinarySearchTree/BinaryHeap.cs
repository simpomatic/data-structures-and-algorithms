using Trees.Shared;

namespace Trees
{
    public class BinaryHeap
    {
        #region Constants and fields
        private TreeNode Root;
        #endregion

        public BinaryHeap()
        {
            Root = null;
        }

        public BinaryHeap(TreeNode treeNode)
        {
            Root = treeNode;
        }

        public void Insert(TreeNode treeNode)
        {
            if (Root == null)
            {
                Root = treeNode;
            } else if (Root.Key > treeNode.Key)
            {
                
            }
        }

        private TreeNode BreadthFirstTraversal(TreeNode currentNode, int maxDepth)
        {
            if (currentNode.HasLeftChild() && currentNode.Depth < maxDepth)
            {
                return BreadthFirstTraversal(currentNode.LeftChild, maxDepth);
            } else if (currentNode.Depth > 0 && currentNode.IsLeftChild())
            {
                if (currentNode.Parent.HasRightChild())
                {
                    if (currentNode.Parent.RightChild.IsLeaf())
                    {
                        return currentNode;
                    } else
                    {
                        return BreadthFirstTraversal(currentNode.Parent.RightChild, maxDepth);
                    }
                } else
                {
                    return currentNode.Parent;
                }
            } else if (currentNode.Depth > 0)
            {
                if (currentNode.Parent.LeftChild.HasRightChild() && !currentNode.HasRightChild())
                {
                    return currentNode;
                }
                else if (currentNode.Parent.LeftChild.HasRightChild() && currentNode.HasRightChild() && currentNode.Depth > 1)
                {
                    int counter = currentNode.Depth;
                    bool isRightSide = false;
                    TreeNode temp = currentNode;

                    // Traverse to the root
                    while (0 < counter)
                    {
                        if (counter == 1)
                        {
                            isRightSide = temp.IsRightChild();
                        }
                        temp = temp.Parent;
                        counter--;
                        if (counter > 1 && temp.IsLeftChild())
                        {
                            break;
                        }
                    }
                    // Traverse back down to the right side of the tree
                    bool isFirstIteration = true;
                    while (counter < maxDepth)
                    {
                        if (isFirstIteration)
                        {
                            isFirstIteration = false;
                            temp = isRightSide ? temp.LeftChild : temp.RightChild;
                        }
                        else
                        {
                            temp = temp.LeftChild;
                        }
                        counter++;
                    }
                    return isRightSide ? BreadthFirstTraversal(temp, maxDepth + 1) : BreadthFirstTraversal(temp, maxDepth);
                }
                else if (currentNode.Parent.LeftChild.HasRightChild() && currentNode.HasRightChild())
                {
                    return BreadthFirstTraversal(currentNode.Parent.LeftChild, maxDepth + 1);
                }
                else
                {
                    return currentNode.Parent.LeftChild;
                }
            } else
            {
                return currentNode;
            }
        }
    }
}
