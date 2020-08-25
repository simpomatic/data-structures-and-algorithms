using Newtonsoft.Json;

namespace Trees.Shared
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TreeNode
    {
        #region Fields and constants
        [JsonProperty]
        public int Key { get; set; }
        [JsonProperty]
        public string Value { get; set; }
        [JsonProperty]
        public TreeNode LeftChild { get; set; }
        [JsonProperty]
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        #endregion

        public TreeNode(
            int key,
            string value,
            TreeNode leftChild = null,
            TreeNode rightChild = null,
            TreeNode parent = null
        ) {
            Key = key;
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Parent = parent;
        }

        public bool HasLeftChild()
        {
            return LeftChild != null;
        }

        public bool HasRightChild()
        {
            return RightChild != null;
        }

        public bool IsLeftChild()
        {
            return Parent != null && Parent.LeftChild == this;
        }

        public bool IsRightChild()
        {
            return Parent != null && Parent.RightChild == this;
        }

        public bool IsRoot()
        {
            return Parent == null;
        }

        public bool IsLeaf()
        {
            return RightChild == null && LeftChild == null;
        }
    }
}
