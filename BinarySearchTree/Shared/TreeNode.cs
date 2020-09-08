using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

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
        [JsonProperty]
        public int Count
        {
            get
            {
                if (IsLeaf())
                {
                    return 1;
                } else
                {
                    int leftChildCount = LeftChild != null ? LeftChild.Count : 0;
                    int rightChildCount = RightChild != null ? RightChild.Count : 0;
                    return leftChildCount + rightChildCount;
                }
            }
        }
        [JsonProperty]
        public int Depth
        {
            get
            {
                // Setup variables
                int depth = 0;
                TreeNode currentNode = this;
                // Traverse up the hierarchy until you reach the root node
                while (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    depth++;
                }

                return depth;
            }
        }
        [JsonProperty]
        public int MaxDepth
        {
            get
            {
                if (IsLeaf())
                {
                    return Depth;
                } else
                {
                    int leftMaxDepth = HasLeftChild() ? LeftChild.MaxDepth : 0;
                    int rightMaxDepth = HasRightChild() ? RightChild.MaxDepth : 0;
                    return Math.Max(leftMaxDepth, rightMaxDepth);
                }
            }
        }
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

        public override bool Equals(Object obj)
        {
            // Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TreeNode treeNode = (TreeNode) obj;
                return GetHashCode() == treeNode.GetHashCode();
            }
        }

        public override int GetHashCode()
        {
            var bytes = Encoding.UTF8.GetBytes(ToString());
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                return BitConverter.ToInt32(hashedInputBytes);
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
