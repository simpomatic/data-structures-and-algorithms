using Trees.Shared;

namespace Trees
{
    public class BinarySearchTree : ITree
    {
        public override TreeNode Get(int key)
        {
            return GetTreeNode(key, root);
        }

        /// <summary>
        /// Attempts to find a tree node with the given key value. Will recursively call itself to traverse down the tree until a match is found, otherwise it will return null.
        /// </summary>
        /// <param name="key">Unique identifier value that is used to find a specific tree node</param>
        /// <param name="currentNode">The node currently being examined</param>
        /// <returns>Tree node with the given key value or null if no node was found with the given key value.</returns>
        private TreeNode GetTreeNode(int key, TreeNode currentNode)
        {
            if (currentNode.key == key)
            {
                return currentNode;
            }
            // Make sure the current node is not a leaf (a node with no children)
            else if (!currentNode.isLeaf())
            {
                bool isCurrentNodeKeyLarger = currentNode.key > key;
                if (isCurrentNodeKeyLarger && currentNode.hasLeftChild())
                {
                    return GetTreeNode(key, currentNode.leftChild);
                } else if (!isCurrentNodeKeyLarger && currentNode.hasRightChild())
                {
                    return GetTreeNode(key, currentNode.rightChild);
                }
            }

            // If you have gotten to this point and nothing has happened, that means no matching current node was found.
            return null;
        }

        public override void Insert(TreeNode node)
        {
            InsertTreeNode(root, node);
        }

        /// <summary>
        /// Recursively traverse through the tree to insert the tree node where it belongs. If the new node key matches one of the existing nodes' key, 
        /// then the existing node's value will be overwritten with the new node's value. Will set the new node as the root if there is currently no root node.
        /// </summary>
        /// <param name="currentNode">The tree node currently being examined</param>
        /// <param name="newNode">The tree node to be inserted</param>
        private void InsertTreeNode(TreeNode currentNode, TreeNode newNode)
        {
            // This should only occur if the current binary search tree does not contain a root tree node
            if (currentNode == null && root == null)
            {
                root = newNode;
            }
            // The key of the current node is greater than the new node's key
            else if (currentNode.key > newNode.key)
            {
                if (!currentNode.hasLeftChild())
                {
                    currentNode.leftChild = newNode;
                }
                // A left child is present, traverse one level down the tree
                else
                {
                    InsertTreeNode(currentNode.leftChild, newNode);
                }
            }
            // The key of the current node is less than the new node's key
            else if (currentNode.key < newNode.key)
            {
                if (!currentNode.hasRightChild())
                {
                    currentNode.rightChild = newNode;
                }
                // A right child is present, traverse one level down the tree
                else
                {
                    InsertTreeNode(currentNode.rightChild, newNode);
                }
            }
            // If the new node has the same key as the current node
            else
            {
                // Overwrite the value of the current node with the value of the new node
                currentNode.value = newNode.value;
            }
        }

        public override void Delete(int key)
        {
            if (root != null)
            {
                DeleteTreeNode(key, root);
            }
        }

        /// <summary>
        /// Traverses the binary search tree to find the a tree node with the given key value. If a match is found, the tree node will be removed, and the children will be handle appropriate to maintain the
        /// integrity of the binary search tree.
        /// </summary>
        /// <param name="key">Unique identifier value used to find a specific tree node</param>
        /// <param name="currentNode">The tree node current being examined</param>
        private void DeleteTreeNode(int key, TreeNode currentNode)
        {
            if (currentNode.key == key)
            {
                if (currentNode.isRoot())
                {
                    root = null;
                }
                // The current node is not the root node
                else
                {
                    // Current node does not have any children
                    if (currentNode.isLeaf())
                    {
                        ReplaceCurrentNode(currentNode);
                    } else
                    {
                        if (currentNode.hasRightChild())
                        {
                            ReplaceCurrentNode(currentNode, currentNode.rightChild);
                        }
                        // The current node does not have a right child, so go with the left child
                        else
                        {
                            ReplaceCurrentNode(currentNode, currentNode.leftChild);
                        }
                    }
                }
            }
            // The key is less than the current node's key, traverse down the left side of this node
            else if (!currentNode.isLeaf() && currentNode.key > key && currentNode.hasLeftChild())
            {
                DeleteTreeNode(key, currentNode.leftChild);
            }
            // The key is greater than the current node's key, traverse down the right side of this node
            else if (!currentNode.isLeaf() && currentNode.key < key && currentNode.hasRightChild())
            {
                DeleteTreeNode(key, currentNode.rightChild);
            }
        }

        /// <summary>
        /// Removes the current node from the binary search tree by replacing its relationship with the parent with the child node. If no child node is given, this essentially removes the current node from the tree entirely.
        /// To maintain the integrity of the binary search tree, if a child node is given, the child node to be replaced must be a child of the current node.
        /// </summary>
        /// <param name="currentNode">The tree node to be replaced/removed</param>
        /// <param name="childNode">The tree node to replace the current tree node, must be one of the children of the current node</param>
        private void ReplaceCurrentNode(TreeNode currentNode, TreeNode childNode = null)
        {
            // Replace the parent's left child or down right remove it if the child node is null
            if ((currentNode.isLeftChild() && childNode.parent == currentNode) || childNode == null)
            {
                currentNode.parent.leftChild = childNode;
            }
            // Replace the parent's right child or down right remove it if the child node is null
            else if ((currentNode.isRightChild() && childNode.parent == currentNode) || childNode == null)
            {
                currentNode.parent.rightChild = childNode;
            }
        }
    }
}
