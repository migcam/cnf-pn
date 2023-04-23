using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class Implication
    {
    
        // replace all implications
        // p->q == -pvq
        public static void Delete_All_Implications(StringBuilder input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'I')
                {
                    input[i] = 'D';
                    input.Insert(i+1, 'N');
                }
            }
        }

        public static string Delete_All_Implications(string input)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i].Equals('I'))
                    input = input.Substring(0, i) + "DN" + input.Substring(++i);
            return input;
        }

        public static ReadOnlySpan<char> Delete_All_Implications(ReadOnlySpan<char> input)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i].Equals('I'))
                    input = string.Concat(input.Slice(0, i),"DN",input.Slice(++i));
            return input;
        }
        
    }
}