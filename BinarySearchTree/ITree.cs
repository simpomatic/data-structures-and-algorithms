using System;
using Trees.Shared;

namespace Trees
{
    public abstract class ITree
    {
        #region Constants and fields
        public TreeNode Root { get; protected set; }
        #endregion

        public ITree()
        {
            Root = null;
        }

        public ITree(TreeNode treeNode)
        {
            Root = treeNode;
        }

        public TreeNode this[int key]
        {
            get
            {
                return Get(key);
            }
        }

        public abstract TreeNode Get(int key);

        public abstract void Insert(TreeNode node);

        public abstract void Delete(int key);

        public override bool Equals(Object obj)
        {
            // Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ITree tree = (ITree) obj;
                return GetHashCode() == tree.GetHashCode();
            }
        }

        public override int GetHashCode()
        {
            return Root.GetHashCode();
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }
}
