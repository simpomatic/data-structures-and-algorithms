using Trees.Shared;

namespace Trees
{
    public abstract class ITree
    {
        #region Constants and fields
        public TreeNode root { get; set; }
        #endregion

        public abstract TreeNode Get(int key);

        public abstract void Insert(TreeNode node);

        public abstract void Delete(int key);
    }
}
