using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;

namespace pkg
{
    public class Interiorization
    {

        /*
         *         v                                        ^
         *        / \                                    /     \
         *       p   ^        ---->                     v       v
         *          / \                                / \     / \
         *         q   r                              p   q   p   r
         * 
        */
        // introducir ORs y extraer ANDs
        // pv(q^r) == (p v q)^(p v r)
        // DpCqr == CDpqDpr
        // DCqrp == CDqpDrp

        // ( a^b)v(q^r)                ==  DCabCqr 
        // ( (a^b) v q )^((a^b) v r)    ==  
        // ((avq)^(bvq))^((avr)^(bvr))

        
        public static StringBuilder Interiorization_ORs(StringBuilder input)
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

            return input;
        }
        
        private static bool checkLast(Stack<char> ops)
        {
            if (ops.Count > 0)
                return ops.Peek().Equals('C');
            else
                return false;

        }

        public static string Interiorization_ORs(string input)
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
                        string q = SubTree.Copy(input, i + 2);
                        string r = SubTree.Cut(ref input, i + 2 + q.Length);
                        string p = SubTree.Cut(ref input, i + 2 + q.Length);

                        string beforei = "";
                        string afteri = "";

                        if(i>0)
                            beforei = input.Substring(0,i);
                        if(i<input.Length-2)
                            afteri = input.Substring(i+2);
                        
                        input = beforei + "CD" + afteri;        
                        input = input.Insert(i + 2 + q.Length, p);
                        input = input.Insert(i + 2 + q.Length + r.Length, "D" + r + p);
                    }
                    else /*if (!input[i + 1].Equals('C'))*/
                    {
                        string q = SubTree.Cut(ref input, i + 1);
                        string r = SubTree.Cut(ref input, i + 2);
                        string p = SubTree.Cut(ref input, i + 2);

                        string beforei = "";
                        string afteri = "";

                        if(i>0)
                            beforei = input.Substring(0,i);
                        if(i<input.Length-2)
                            afteri = input.Substring(i+2);
                        
                        input = beforei + "CD" + afteri; 
                        input = input.Insert(i + 2, q + r);
                        input = input.Insert(i + 2 + q.Length + r.Length, "D" + q + p);
                    }
                    ops.Clear();
                    i = input.Length;
                }

            }

            return input;
        }


    }
}
