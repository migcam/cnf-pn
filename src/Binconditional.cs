using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpll_dotnet_5
{
    public class Biconditional
    {
        /*
        deletes dobles implications
        p<->q == (p->q)^(q->p)
        p<->q == (pv-q)^(-pvq)
        */
        // public static int RightChild_idx;
        public static void Delete_MaterialConditions(StringBuilder input)
        {
            StringBuilder LeftChild = new StringBuilder();
            StringBuilder RightChild = new StringBuilder();
            //string LeftChild = "";
            //string RightChild = "";
            Stack<int> mystack = new Stack<int>();
            // RightChild_idx = 0;

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i].Equals('E'))
                {
                    LeftChild = Copy.CopySubTree(input,i+1);
                    RightChild = Copy.CopySubTree(input, i + 1 + LeftChild.Length);

                    input[i] = 'C';
                    input.Insert(i + 1 + LeftChild.Length + RightChild.Length, "I" + RightChild + LeftChild);
                    input.Insert(i + 1, 'I');
                }
               
            }

        }
    }
}