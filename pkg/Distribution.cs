using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pkg
{
    public class Distribution
    {

        /*
         *         v                                        ^
         *        / \                                    /     \
         *       p   ^        ---->                     v       v
         *          / \                                / \     / \
         *         q   r                              p   q   p   r
         * 
        */
        // insert ORs y extrat ANDs
        // pv(q^r) == (p v q)^(p v r)
        // DpCqr == CDpqDpr
        // DCqrp == CDqpDrp

        // (a^b)v(q^r)                ==  DCabCqr 
        // ( (a^b) v q )^((a^b) v r)    ==  
        // ((avq)^(bvq))^((avr)^(bvr))

        
        public static void Distribution_ORs(StringBuilder input)
        {
            Stack<char> ops = new Stack<char>();
            Stack<char> ds = new Stack<char>();
            for (int i = input.Length - 1; i > -1; i--)
            {
                if (input[i].Equals('C'))
                {
                    ops.Push(input[i]);
                    if(ds.Count > 1)
                    {
                        ops.Clear();
                        ds.Clear();
                    }
                }

                if (input[i].Equals('D')){
                    ds.Push(input[i]);
                }


                if (input[i].Equals('D') && checkLast(ops))
                {
                    if(input[i + 1].Equals('C') && ops.Count==1)
                    {
                        StringBuilder q = SubTree.Copy(input, i + 2);
                        StringBuilder r = SubTree.Cut(input, i + 2 + q.Length);
                        StringBuilder p = SubTree.Cut(input, i + 2 + q.Length);

                        input[i] = 'C';
                        input[i + 1] = 'D';
                        input.Insert(i + 2 + q.Length, p);
                        input.Insert(i + 2 + q.Length + r.Length, "D" + r + p);
                    }
                    else /*if (!input[i + 1].Equals('C'))*/
                    {
                        StringBuilder q = SubTree.Cut(input, i + 1);
                        StringBuilder r = SubTree.Cut(input, i + 2);
                        StringBuilder p = SubTree.Cut(input, i + 2);

                        input[i] = 'C';
                        input[i + 1] = 'D';
                        input.Insert(i + 2, "" + q + r);
                        input.Insert(i + 2 + q.Length + r.Length, "D" + q + p);
                    }
                    ops.Clear();
                    i = input.Length;
                }

            }

            // return input;
        }
        
        private static bool checkLast(Stack<char> ops)
        {
            if (ops.Count > 0)
                return ops.Peek().Equals('C');
            else
                return false;

        }

        public static string Distribution_ORs(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i].Equals('D')){
                    // get left subtree and right subtrees roots
                    string left  = SubTree.Copy(input,i+1);
                    string right = SubTree.Copy(input,i + left.Length + 1);

                    // Look for Ands in subtrees roots

                    //if left node has and and rght does not
                    if(left[0].Equals('C') && !right[0].Equals('C')){
                        string q = SubTree.Copy(left,1);
                        string r = SubTree.Copy(left,q.Length + 1);

                        input = input.Substring(0,i) + "CD" + q + right + "D" + r + right;
                        continue;
                    }
                    //if right node has and and left does not
                    if(!left[0].Equals('C') && right[0].Equals('C')){
                        string q = SubTree.Copy(right,1);
                        string r = SubTree.Copy(right,q.Length + 1);

                        input = input.Substring(0,i) + "CD" + left + q + "D" +left + r;
                        continue;
                    }

                    // when both children nodes are ands
                    if(left[0].Equals('C') && right[0].Equals('C')){
                        string p = SubTree.Copy(left,1);
                        string q = SubTree.Copy(left,p.Length + 1);

                        string r = SubTree.Copy(right,1);
                        string s = SubTree.Copy(right,r.Length + 1);

                        input = input.Substring(0,i) + "CCD" + p + r + 
                                                        "D" + q + r +
                                                        "CD" + p + s +
                                                        "D" + q + s;

                    }

                }
            }

            return input;
        }

        public static ReadOnlySpan<char> Distribution_ORs(ReadOnlySpan<char> input)
        {
            Stack<char> ops = new Stack<char>();
            Stack<char> ds = new Stack<char>();
            for (int i = input.Length - 1; i > -1; i--)
            {
                if (input[i].Equals('C'))
                {
                    ops.Push(input[i]);
                    if(ds.Count > 1)
                    {
                        ops.Clear();
                        ds.Clear();
                    }
                }

                if (input[i].Equals('D')){
                    ds.Push(input[i]);
                }


                if (input[i].Equals('D') && checkLast(ops))
                {
                    if(input[i + 1].Equals('C') && ops.Count == 1)
                    {
                        ReadOnlySpan<char> q = SubTree.Copy(input, i + 2);
                        ReadOnlySpan<char> r = SubTree.Cut(ref input, i + 2 + q.Length);
                        ReadOnlySpan<char> p = SubTree.Cut(ref input, i + 2 + q.Length);

                        ReadOnlySpan<char> beforei = "";
                        ReadOnlySpan<char> afteri = "";

                        if(i>0)
                            beforei = input.Slice(0,i);
                        if(i<input.Length-2)
                            afteri = input.Slice(i+2);
                        
                        input = string.Concat(beforei,"CD",afteri);       
                        input = input.Insert(i + 2 + q.Length, p);
                        input = input.Insert(i + 2 + q.Length + r.Length, string.Concat("D",r,p));
                    }
                    else /*if (!input[i + 1].Equals('C'))*/
                    {
                        ReadOnlySpan<char> q = SubTree.Cut(ref input, i + 1);
                        ReadOnlySpan<char> r = SubTree.Cut(ref input, i + 2);
                        ReadOnlySpan<char> p = SubTree.Cut(ref input, i + 2);

                        ReadOnlySpan<char> beforei = "";
                        ReadOnlySpan<char> afteri = "";

                        if(i>0)
                            beforei = input.Slice(0,i);
                        if(i<input.Length-2)
                            afteri = input.Slice(i+2);
                        
                        input = string.Concat(beforei,"CD",afteri);
                        input = input.Insert(i + 2, string.Concat(q,p));
                        input = input.Insert(i + 2 + q.Length + r.Length, string.Concat("D",q,p));
                    }
                    ops.Clear();
                    i = input.Length;
                }

            }

            return input;
        }
        
        public static ReadOnlySpan<char> Distribution_ORs2(ReadOnlySpan<char> input)
        {
            ReadOnlySpan<char> left;
            ReadOnlySpan<char> right;
            ReadOnlySpan<char> p;
            ReadOnlySpan<char> q;
            ReadOnlySpan<char> r;
            ReadOnlySpan<char> s;

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i].Equals('D')){
                    // get left subtree and right subtrees roots
                    left = SubTree.Copy(input,i+1);
                    right = SubTree.Copy(input,i + left.Length + 1);

                    // Look for Ands in subtrees roots

                    //if left node has and and rght does not
                    if(left[0].Equals('C') && !right[0].Equals('C')){
                        q = SubTree.Copy(left,1);
                        r = SubTree.Copy(left,q.Length + 1);

                        input = string.Concat(string.Concat(input.Slice(0,i), "CD", q, right), "D",r,right);
                        continue;
                    }
                    //if right node has and and left does not
                    if(!left[0].Equals('C') && right[0].Equals('C')){
                        q = SubTree.Copy(right,1);
                        r = SubTree.Copy(right,q.Length + 1);

                        input = string.Concat(string.Concat(input.Slice(0,i), "CD", left, q), "D",left, r);
                        continue;
                    }

                    // when both children nodes are ands
                    if(left[0].Equals('C') && right[0].Equals('C')){
                        p = SubTree.Copy(left,1);
                        q = SubTree.Copy(left,p.Length + 1);

                        r = SubTree.Copy(right,1);
                        s = SubTree.Copy(right,r.Length + 1);

                        input = string.Concat(string.Concat(input.Slice(0,i), "CCD", p, r),
                                                        string.Concat("D",q,r),
                                                        string.Concat("CD",p,s),
                                                        string.Concat("D",q,s));

                    }

                }
            }

            return input;
        }


    }
}
