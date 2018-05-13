using System;
using System.Collections.Generic;

namespace A4
{
    class Program
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

            root.PrintTree("");     
        }

        class TreeNode<T>
        {
            private T _item;  
            private TreeNode<T> _parentNode;
            private List<TreeNode<T>> _children;
            //private List<TreeNode<T>> sublist;
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

            public TreeNode(T item, TreeNode<T> _parentNode)
            {
                _item = item;
                _parentNode.AppendChild(this);                      
            }

            public void AppendChild(TreeNode<T> child)
            {
                if (_children == null)
                {                              
                    _children = new List<TreeNode<T>> { child };       
                }
                else
                {
                    _children.Add(child);                           
                }
                child._parentNode = this;                           
            }                                                       

            public void RemoveChild(TreeNode<T> child)
            {
                _children.Remove(child);
            }

            public void PrintTree(String sternchen)
            {                    
                Console.WriteLine(sternchen + _item.ToString());        
                if (_children != null)
                {                                 
                    foreach (var child in _children)
                    {
                        child.PrintTree(sternchen + "*");                 
                    }
                }
            }
            
            public List<TreeNode<T>> FindAll (T search)
            {
            var found = new List<TreeNode<T>>();

            if (_item.Equals(search))
            {
                found.Add(this);
            }

            foreach (TreeNode<T> child in _children)
            {
                child.FindAll(search);
            }
            return found;
            }
        }
    }
}