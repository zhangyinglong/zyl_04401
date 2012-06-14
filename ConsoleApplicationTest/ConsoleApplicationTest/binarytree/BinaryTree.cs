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
        public static bool Repeateable { set; get; }
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

        public BinaryTree(TItem nodeData = default(TItem))
        {
            this.NodeData = nodeData;
            this.LeftTree = this.RightTree = null;
        }

        public bool Contain(TItem item)
        {
            try
            {
                if (this.NodeData.Equals(item))
                {
                    return true;
                }
                
                if (this.LeftTree != null)
                {
                    return this.LeftTree.Contain(item);
                }

                if (this.RightTree != null)
                {
                    return this.RightTree.Contain(item);
                }
                return false;
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
        }

        public void Insert(TItem newItem)
        {
            if (BinaryTree<TItem>.Repeateable || !this.Contain(newItem))
            {
                try
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
                catch (NullReferenceException ex)
                {
                    this.NodeData = newItem;
                }
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

    class BinaryTreeTest
    {
        public static void test_int_binarytree()
        {
            Console.WriteLine("\n---------------- test binary tree --------------------\n");
            BinaryTree<int> tree = new BinaryTree<int>(0);
            BinaryTree<int>.Repeateable = false;
            //tree.Insert(5);
            //tree.Insert(11);
            //tree.Insert(5);
            //tree.Insert(-12);
            //tree.Insert(15);
            //tree.Insert(12);
            //tree.Insert(14);
            //tree.Insert(-8);
            //tree.Insert(10);
            //tree.Insert(8);
            //tree.Insert(8);
            tree.Insert(5, 11, 5, -12, 15, 12, 14, -8, 10, 8, 8, 9);

            Console.WriteLine("=========== First traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.First);
            Console.WriteLine("");
            foreach (var i in tree.FirstTravEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n============ In-order traversal ===========");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Inorder);
            Console.WriteLine("");
            foreach (var i in tree.InorderEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Postorder traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Postorder);
            Console.WriteLine("");
            foreach (var i in tree.PostorderTravEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n============ Ascend traversal ===========");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Ascend);
            Console.WriteLine("");
            foreach (var i in tree.AscendEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Descend traversal ============");
            tree.WalkBinaryTree(BinaryTree<int>.TraverType.Descend);
            Console.WriteLine("");
            foreach (var i in tree.DescendEnumertor)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine("\n\n=========== Enumertor traversal ============");
            foreach (var i in tree)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine("\n\n=========== end ============");
        }

        public static void test_Linq_employee_binarytree()
        {
            Console.WriteLine("\n---------------- test binary tree --------------------\n");
            BinaryTree<Employee> tree = new BinaryTree<Employee>();
            //BinaryTree<Employee>.Repeateable = true;
            tree.Insert(new Employee { Id = 1, Name = "zhangyinglong", PhoneNumber = 15801553960, Province = "YunNan" }
                        , new Employee { Id = 2, Name = "hewei", PhoneNumber = 15801553960, Province = "ShenYang" }
                        , new Employee { Id = 3, Name = "yuguangzhen", PhoneNumber = 15801553960, Province = "ChengDu" }
                        , new Employee { Id = 4, Name = "zhangxuesong", PhoneNumber = 15801553960, Province = "BeiJing" }
                        , new Employee { Id = 5, Name = "tanhaibing", PhoneNumber = 15801553960, Province = "HeBei" }
                        , new Employee { Id = 6, Name = "songpeipei", PhoneNumber = 15801553960, Province = "YunNan" });

            var name = from e in tree
                       orderby e.Name
                       where String.Equals(e.Province, "YunNan")
                       select e.Name;
            foreach (var e in name)
            {
                Console.WriteLine("Name = {0}", e);
            }

            var group_by_province = from e in tree
                                    group e by e.Province;
            foreach (var gprovince in group_by_province)
            {
                Console.WriteLine("{0} : {1}", gprovince.Key, gprovince.Count());
                foreach (var p in gprovince)
                {
                    Console.WriteLine("{0}", p);
                }
            }

            tree.Insert(new Employee { Id = 4, Name = "zhangyinglong", PhoneNumber = 15801553960, Province = "YunNan" });
            foreach (var e in name)//name.Distinct())
            {
                Console.WriteLine("Name = {0}", e);
            }

            Employee e1 = new Employee { Id = 1, Name = "zhangyinglong", PhoneNumber = 15801553960, Province = "YunNan" };
            Employee e2 = new Employee { Id = 2, Name = "zhangyinglong", PhoneNumber = 15801553960, Province = "YunNan" };
            if (e1 == e2)
            {
                ;
            }
        }
    }
}
