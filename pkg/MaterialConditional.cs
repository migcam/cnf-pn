using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class MaterialConditional
    {
    
        //eliminar todas las implicaiones
        //p->q == -pvq
        
        public static StringBuilder Delete_All_Implications(StringBuilder input)
        {
            for (int i = input.Length - 2; i > -1; i--)
            {
                if (input[i].Equals('I'))
                {
                    input[i] = 'D';
                    input.Insert(i + 1, 'N');
                    continue;
                }
            }

            return input;
        }
        
    }
}