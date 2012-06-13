using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.binarytree
{
    class BinaryTree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public enum TraverType { First, Inorder, Postorder, Descend, Ascend = Inorder }
        public TItem NodeData { set; get; }
        public BinaryTree<TItem> LeftTree { set; get; }
        public BinaryTree<TItem> RightTree { set; get; }

        public IEnumerable<TItem> FirstTravEnumertor // 先序遍历的迭代器
        {
            get
            {
                yield return this.NodeData;
                if (this.LeftTree != null)
                {
                    foreach(TItem item in this.LeftTree.FirstTravEnumertor)
                    {
                        yield return item;
                    }
                }
                if (this.RightTree != null)
                {
                    foreach(TItem item in this.RightTree.FirstTravEnumertor)
                    {
                        yield return item;
                    }
                }
            }
        }

        public IEnumerable<TItem> InorderEnumertor // 中序遍历的迭代器
        {
            get
            {
                if (this.LeftTree != null)
                {
                    foreach (TItem item in this.LeftTree.InorderEnumertor)
                    {
                        yield return item;
                    }
                }
                yield return this.NodeData;
                if (this.RightTree != null)
                {
                    foreach (TItem item in this.RightTree.InorderEnumertor)
                    {
                        yield return item;
                    }
                }
            }
        }

        public IEnumerable<TItem> PostorderTravEnumertor // 后序遍历的迭代器
        {
            get
            {
                if (this.RightTree != null)
                {
                    foreach (TItem item in this.RightTree.PostorderTravEnumertor)
                    {
                        yield return item;
                    }
                }
                if (this.LeftTree != null)
                {
                    foreach (TItem item in this.LeftTree.PostorderTravEnumertor)
                    {
                        yield return item;
                    }
                }
                yield return this.NodeData;
            }
        }

        public IEnumerable<TItem> AscendEnumertor // 升序遍历的迭代器
        {
            get
            {
                return this.InorderEnumertor;
            }
        }

        public IEnumerable<TItem> DescendEnumertor // 降序遍历的迭代器
        {
            get
            {
                if (this.RightTree != null)
                {
                    foreach (TItem item in this.RightTree.DescendEnumertor)
                    {
                        yield return item;
                    }
                }
                yield return this.NodeData;
                if (this.LeftTree != null)
                {
                    foreach (TItem item in this.LeftTree.DescendEnumertor)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() // 泛型迭代
        {
            return this.InorderEnumertor.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

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
            Console.Write(this.NodeData.ToString() + ", ");
            if (this.LeftTree != null)
            {
                this.LeftTree.FirstTraversalBinaryTree();
            }
            if (this.RightTree != null)
            {
                this.RightTree.FirstTraversalBinaryTree();
            }
        }

        private void InorderTraversalBinaryTree()// 中序遍历 = 升序遍历
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.InorderTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ", ");
            if (this.RightTree != null)
            {
                this.RightTree.InorderTraversalBinaryTree();
            }
        }

        private void PostorderTraversalBinaryTree()// 后序遍历
        {
            if (this.RightTree != null)
            {
                this.RightTree.PostorderTraversalBinaryTree();
            }
            if (this.LeftTree != null)
            {
                this.LeftTree.PostorderTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ", ");
        }

        private void DescendTraversalBinaryTree()// 降序遍历
        {
            if (this.RightTree != null)
            {
                this.RightTree.DescendTraversalBinaryTree();
            }
            Console.Write(this.NodeData.ToString() + ", ");
            if (this.LeftTree != null)
            {
                this.LeftTree.DescendTraversalBinaryTree();
            }
        }
    }
}
