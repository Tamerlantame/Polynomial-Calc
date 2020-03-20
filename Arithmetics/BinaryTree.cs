using System;
using System.Collections.Generic;
using System.Text;

namespace Arithmetics
{
    
    class BinaryTree<T> 
    {
        public T value;
        public BinaryTree<T> left;
        public BinaryTree<T> right;
        public int level;


        public BinaryTree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
            this.level = 0;

        }
        public BinaryTree(T value, BinaryTree<T> lefttree, BinaryTree<T> righttree)
        {
            if (lefttree != null || righttree != null)
                this.level = Math.Max(lefttree.level, righttree.level) + 1;
            this.value = value;
            left = lefttree;
            right = righttree;

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", left, value, right);
        }

    }
}