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
            for (int i = input.Length - 2; i > -1; i--)
            {
                if (input[i].Equals('I'))
                {
                    input[i] = 'D';
                    input.Insert(i + 1, 'N');
                }
            }
        }

        public static string Delete_All_Implications(string input)
        {
            string beforei = "";
            string afteri = "";
            for (int i = input.Length - 1; i > -1; i--)
            {
                if (input[i].Equals('I'))
                {
                    beforei = "";
                    afteri = "";
                    if (i > 0)
                        beforei = input.Substring(0, i);
                    if (i < input.Length - 1)
                        afteri = input.Substring(i + 1);

                    input = beforei + 'D' + afteri;
                    input = input.Insert(i + 1, "N");
                }
            }

            return input;
        }
        
    }
}