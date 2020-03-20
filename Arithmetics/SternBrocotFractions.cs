using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    static class SternBrocotFunctions
    {
        public  static List<FakeFraction>  FindFarrey(int n)
        {
            
            List<FakeFraction> fractions = new List<FakeFraction>();
            BinaryTree<BrocotFraction> a = GetSbTree(n).left;
            fractions.Add(new FakeFraction(0, 1));
            fractions.AddRange(GetListElements(a, n));
            
            fractions.Add(new FakeFraction(1, 0));
            for (int i = 0; i < fractions.Count();i++)
            { 
            if (fractions[i].p >= n || fractions[i].q >= n)
                {
                    fractions.Remove(fractions[i]);
                }
            }
            return fractions;
        }
        public static BinaryTree<BrocotFraction> GetSbTree(int depth)
        {

            if (depth <= 0)
                return null;
            else
            {

                FakeFraction t = new FakeFraction(1, 1);
                FakeFraction left = new FakeFraction(0, 1);
                FakeFraction right = new FakeFraction(1, 0);


                BrocotFraction FirstStage = new BrocotFraction(t, left, right);
                BinaryTree<BrocotFraction> b = new BinaryTree<BrocotFraction>(FirstStage);
                if (depth == 1)
                    return b;
                b.value = FirstStage;
                b.right = GetSbSubTree(new BrocotFraction(b.value.current + b.value.right, b.value.current, b.value.right), depth - 1);
                b.left = GetSbSubTree(new BrocotFraction(b.value.current + b.value.left, b.value.left, b.value.current), depth - 1);



                return b;
            }
        }
        public static List<FakeFraction> GetListElements(BinaryTree<BrocotFraction> binarytree, int q)
        {
            List<FakeFraction> fractions = new List<FakeFraction>();

            if (binarytree.left != null || binarytree.right != null)
            {

                FakeFraction c = binarytree.value.current;
                fractions.AddRange(GetListElements(binarytree.left, q));
                if (c.q <= q)
                {
                    fractions.Add(c);
                }
                fractions.AddRange(GetListElements(binarytree.right, q));
            }
            return fractions;
        }

        public static FakeFraction GetFarrey(int n, int m)
        {
            FakeFraction right = new FakeFraction(1, 1);
            FakeFraction left = new FakeFraction(0, 1);
            FakeFraction t = new FakeFraction(1, 1);
            BinaryTree<FakeFraction> tree = new BinaryTree<FakeFraction>(new FakeFraction(1, 2));

            return t;
        }
     

        public static BinaryTree<BrocotFraction> GetSbSubTree(BrocotFraction f, int depth)
        {
            if (depth > 0)
            { FakeFraction x = f.left+ f.current;
                FakeFraction y = f.right + f.current;

                    BrocotFraction leftSub = new BrocotFraction(x, f.left, f.current);
                    BrocotFraction rightSub = new BrocotFraction(y, f.current, f.right);
                

                    BinaryTree<BrocotFraction> leftSubTree = GetSbSubTree(leftSub, depth - 1);
                    BinaryTree<BrocotFraction> rightSubTree = GetSbSubTree(rightSub, depth - 1);
                    BinaryTree<BrocotFraction> tree = new BinaryTree<BrocotFraction>(f, leftSubTree, rightSubTree);
                
                return tree;
            }
            else

                return null;
        }
    }
}
