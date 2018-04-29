using System;
using System.Collections.Generic;

namespace Aufgabe4
{
    class Programm
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            Console.WriteLine(root.PrintTree());
        }


    }
    class TreeNode<T>
    {
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();
        private T _item;
        private TreeNode<T> _parentNode { get; set; }

        public TreeNode()
        {
        }

        public TreeNode<T> CreateNode(T item)
        {
            TreeNode<T> node = new TreeNode<T>();
            node._item = item;
            return node;
        }
        public TreeNode(T item)
        {
            _item = item;
        }
 
        public void AppendChild(TreeNode<T> child)
        {
            _children.Add(child);
            child._parentNode = this;
        }

        public void RemoveChild(TreeNode<T> child)
        {
            _children.Remove(child);
        }

        public string PrintTree()
        {

            return _item.ToString();
        }

    }

}
