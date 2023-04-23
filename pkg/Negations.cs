using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class Negations
    {
        // !p or q === !p and !q; 
        // !p and q === !p or !q
        public static void Delete_Negation(StringBuilder input)
        {
            int pLength;
            for (int i = 0; i < input.Length-1; i++)
            {
                if(input[i+1].Equals('C') && input[i].Equals('N'))
                {
                    input[i] = 'D';
                    input[i+1]='N';
                    pLength = SubTree.GetSubTreeLength(input,i+2);
                    input.Insert(i+2+pLength,'N');                
                }
                else if(input[i+1].Equals('D') && input[i].Equals('N'))
                {
                    input[i] = 'C';
                    input[i+1]='N';
                    pLength = SubTree.GetSubTreeLength(input,i+2);
                    input.Insert(i+2+pLength,'N'); 
                }
                
                if(input[i].Equals('N') && input[i+1].Equals('N'))
                {
                    input.Remove(i--,2);
                }
            }
        }

        public static string Delete_Negation(string input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {

                if(input[i+1].Equals('C') && input[i].Equals('N'))
                {
                    string p = SubTree.Copy(input,i+2);
                    string q = SubTree.Copy(input,i+2+p.Length);
                    input = string.Concat(input.Substring(0,i),"DN",p,"N",q,input.Substring(i+2+p.Length+q.Length));
                }
                else if(input[i+1].Equals('D') && input[i].Equals('N'))
                {
                    string p = SubTree.Copy(input,i+2);
                    string q = SubTree.Copy(input,i+2+p.Length);
                    input = string.Concat(input.Substring(0,i),"CN",p,"N",q,input.Substring(i+2+p.Length+q.Length));
                }

                if(input[i].Equals('N') && input[i+1].Equals('N'))
                {
                    input = input.Remove(i--,2);
                }

            }

            return input;
        }

        public static ReadOnlySpan<char>  Delete_Negation(ReadOnlySpan<char> input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {

                if(input[i+1].Equals('C') && input[i].Equals('N'))
                {
                    var p = SubTree.Copy(input,i+2);
                    var q = SubTree.Copy(input,i+2+p.Length);
                    input = string.Concat(string.Concat(input.Slice(0,i),"DN",p,"N"),q,input.Slice(i+2+p.Length+q.Length));
                }
                else if(input[i+1].Equals('D') && input[i].Equals('N'))
                {
                    var p = SubTree.Copy(input,i+2);
                    var q = SubTree.Copy(input,i+2+p.Length);
                    input = string.Concat(string.Concat(input.Slice(0,i),"CN",p,"N"),q,input.Slice(i+2+p.Length+q.Length));
                }

                if(input[i].Equals('N') && input[i+1].Equals('N'))
                {
                    input = input.Remove(i--,2);
                }

            }

            return input;
        }

    }

    public static class ReadOnlySpanExtensions
    {
        public static ReadOnlySpan<char> Remove(this ReadOnlySpan<char> input, int idx, int length)
        {
           return string.Concat(input.Slice(0,idx),input.Slice(idx+length,input.Length-idx-length));
        }

        public static ReadOnlySpan<char> Insert(this ReadOnlySpan<char> input, int idx, string newStr)
        {
           return string.Concat(input.Slice(0,idx),newStr,input.Slice(idx,input.Length-idx));
        }

        public static ReadOnlySpan<char> Insert(this ReadOnlySpan<char> input, int idx, ReadOnlySpan<char> newStr)
        {
           return string.Concat(input.Slice(0,idx),newStr,input.Slice(idx,input.Length-idx));
        }
    }
}
