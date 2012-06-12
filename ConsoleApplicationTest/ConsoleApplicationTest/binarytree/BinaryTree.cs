using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.binarytree
{
    class BinaryTree<TItem> where TItem : IComparable<TItem>
    {
        public enum TraverType { First, Inorder, Postorder, Descend, Ascend = Inorder }
        public TItem NodeData { set; get; }
        public BinaryTree<TItem> LeftTree { set; get; }
        public BinaryTree<TItem> RightTree { set; get; }

        public BinaryTree(TItem nodeData)
        {
            this.NodeData = nodeData;
            this.LeftTree = this.RightTree = null;
        }

        public void Insert(TItem newItem)
        {
            TItem currentData = this.NodeData;
            if (currentData.CompareTo(newItem) > 0)
            {
                this.InsertLeftTree(newItem);
            }
            else
            {
                this.InsertRightTree(newItem);
            }
        }

        public void Insert(params TItem[] newItems)
        {
            foreach (TItem item in newItems)
            {
                this.Insert(item);
            }
        }

        private void InsertLeftTree(TItem newItem)
        {
            if (this.LeftTree == null)
            {
                this.LeftTree = new BinaryTree<TItem>(newItem);
            } 
            else
            {
                this.LeftTree.Insert(newItem);
            }
        }

        private void InsertRightTree(TItem newItem)
        {
            if (this.RightTree == null)
            {
                this.RightTree = new BinaryTree<TItem>(newItem);
            }
            else
            {
                this.RightTree.Insert(newItem);
            }
        }

        public void WalkBinaryTree(TraverType type = TraverType.First)
        {
            switch(type)
            {
                case TraverType.First:
                    {
                        this.FirstTraversalBinaryTree();
                        break;
                    }

                //case TraverType.Ascend:
                case TraverType.Inorder:
                    {
                        this.InorderTraversalBinaryTree();
                        break;
                    }

                case TraverType.Postorder:
                    {
                        this.PostorderTraversalBinaryTree();
                        break;
                    }

                case TraverType.Descend:
                    {
                        this.DescendTraversalBinaryTree();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void FirstTraversalBinaryTree()
        {
            Console.Write(this.NodeData.ToString() + ",");
            if (this.LeftTree != null)
            {
                this.LeftTree.FirstTraversalBinaryTree();
            }
            if (this.RightTree != null)
            {
                this.RightTree.FirstTraversalBinaryTree();
            }
        }

        private void InorderTraversalBinaryTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.InorderTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ",");
            if (this.RightTree != null)
            {
                this.RightTree.InorderTraversalBinaryTree();
            }
        }

        private void PostorderTraversalBinaryTree()
        {
            if (this.RightTree != null)
            {
                this.RightTree.PostorderTraversalBinaryTree();
            }
            if (this.LeftTree != null)
            {
                this.LeftTree.PostorderTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ",");
        }

        private void DescendTraversalBinaryTree()
        {
            if (this.RightTree != null)
            {
                this.RightTree.DescendTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ",");
            if (this.LeftTree != null)
            {
                this.LeftTree.DescendTraversalBinaryTree();
            }
        }
    }
}
