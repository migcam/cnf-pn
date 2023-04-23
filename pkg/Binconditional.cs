using System;
using System.Text;

namespace pkg
{
    public class Biconditional
    {
        /*
        deletes biconditionals using De'Morgan's laws
        p<->q == (p->q)^(q->p)
        p<->q == (pv-q)^(-pvq)

        Epq == CIpqIqp
        */
        // public static int RightChild_idx;
        public static void Delete_MaterialConditions(StringBuilder input)
        {
            StringBuilder LeftChild = new StringBuilder();
            StringBuilder RightChild = new StringBuilder();

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i].Equals('E'))
                {
                    LeftChild = SubTree.Copy(input,i+1);
                    RightChild = SubTree.Copy(input, i + 1 + LeftChild.Length);

                    input[i] = 'C';
                    input.Insert(i + 1 + LeftChild.Length + RightChild.Length, "I" + RightChild + LeftChild);
                    input.Insert(i + 1, 'I');
                }
               
            }

        }

        public static string Delete_MaterialConditions(string input)
        {
            string LeftChild = "";
            string RightChild = "";
            
            string beforei = "";
            string afteri = "";

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == 'E')
                {
                    LeftChild = SubTree.Copy(input,i+1);
                    RightChild = SubTree.Copy(input, i + 1 + LeftChild.Length);

                    beforei = input.Substring(0,i);
                    afteri = input.Substring(i+LeftChild.Length+RightChild.Length+1);

                    input =  string.Concat(beforei, "CI", LeftChild,RightChild, "I", RightChild, LeftChild, afteri);

                }
               
            }

            return input;

        }

        public static ReadOnlySpan<char> Delete_MaterialConditions(ReadOnlySpan<char> input)
        {
            ReadOnlySpan<char> LeftChild = "";
            ReadOnlySpan<char> RightChild = "";
            
            ReadOnlySpan<char> beforei = "";
            ReadOnlySpan<char> afteri = "";

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == 'E')
                {
                    LeftChild = SubTree.Copy(input,i+1);
                    RightChild = SubTree.Copy(input, i + 1 + LeftChild.Length);

                    beforei = input.Slice(0,i);
                    afteri = input.Slice(i+LeftChild.Length+RightChild.Length+1);

                    input =  string.Concat(string.Concat(beforei, "CI", LeftChild,RightChild), string.Concat("I", RightChild, LeftChild, afteri));
                }
               
            }

            return input;

        }

    }
}