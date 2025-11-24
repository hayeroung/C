using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTT
{
    //트리 노드
    class Treenode
    {
        private int data;
        private Treenode left, right;

        public Treenode(int _data, Treenode _left, Treenode _right)
        {
            this.data = _data;
            this.left = _left;
            this.right = _right;
        }

        public int GetData()
        {
            return this.data; //옛날버전
        }
        //프로퍼티
        public int Data { get => data; set => data = value; }
        public void SetData(int _data)
        { this.data = _data; }
        public Treenode GetLeft()
        { return this.left; }

        public Treenode GetRight()
        { return this.right; }
        public void SetLeft(Treenode _node)
        { this.left = _node; }
        public void SetRight(Treenode _node)
        { this.right = _node; }
    }
    class Tree
    {
        private Treenode root;
        public Tree(Treenode _root)
        { this.root = _root; }
        public Treenode GetRoot()
        { return this.root; }

        public void Preoreder(Treenode _root)
        {
            if (_root == null) return;

            Console.Write(_root.GetData() + " ");
            Preoreder(_root.GetLeft());
            Preoreder(_root.GetRight());
        }
        public void Inoreder(Treenode _root)
        {
            if (_root == null) return;

            Inoreder(_root.GetLeft());
            Console.Write(_root.Data + " ");
            Inoreder(_root.GetRight());
        }
        public void Postoreder(Treenode _root)
        {
            if (_root == null) return;

            Postoreder(_root.GetLeft());
            Postoreder(_root.GetRight());
            Console.Write(_root.Data + " ");
        }
        public Treenode Search(int _data)
        {
            if (this.root == null)
            {
                Console.WriteLine("트리가 텅텅");
                return null;
            }
            Treenode node = this.root;
            while (node != null)
            {
                if (_data == node.Data)
                {
                    //찾았다
                    Console.WriteLine("찾았다");
                    return node;
                }
                else if (_data < node.Data)
                {
                    node = node.GetLeft();
                }
                else
                {
                    node = node.GetRight();
                }

            }//while
            Console.WriteLine("못찾겠다 꾀꼬리");
            return null;
        }

        public Treenode Insert(int _data)
        {//빈 트리일때
            if (this.root == null)
            {
                this.root = new Treenode(_data, null, null);
                return this.root;
            }
            //find
            Treenode node = this.root;
            while (node != null)
            {
                if (_data == node.Data)
                {
                    //이미 존재
                    Console.WriteLine("이미 존재합니다");
                    return node;
                }
                else if (_data < node.Data)
                {
                    if (node.GetLeft() == null)
                    {
                        Treenode temp = new Treenode(_data, null, null);
                        node.SetLeft(temp);
                        return temp;
                    }
                    node = node.GetLeft();
                }
                else
                {
                    if (node.GetRight() == null)
                    {
                        Treenode temp = new Treenode(_data, null, null);
                        node.SetRight(temp);
                        return temp;
                    }
                    node = node.GetRight();
                }

            }//while
            return null;
        }//Insert()
        //Delete 추가할 점
        internal class Program
        {
            static void Main(string[] args)
            {
                Tree tree = new Tree(null);

                Console.WriteLine("Insert 4,2,1,6,7");
                tree.Insert(4);
                tree.Insert(2);
                tree.Insert(1);
                tree.Insert(6);
                tree.Insert(7);

                tree.Preoreder(tree.GetRoot());
            }
        }

    }
}
