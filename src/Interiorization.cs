using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpll_dotnet_5
{
    public class Interiorization
    {
        //introducir ORs y extraer ANDs
        //pv(q^r) == (pvq)^(pvr)

        public static StringBuilder Interiorization_ORs(StringBuilder input)
        {
            for (int i = input.Length - 1; i > -1 ; i--)
            {
                if (input[i].Equals('D'))
                {
                    if (input[i + 1].Equals('C'))
                    {
                        StringBuilder q = Copy.CopySubTree(input, i + 2);
                        StringBuilder r = Copy.CutSubTree(input, i + 2+ q.Length);
                        StringBuilder p = Copy.CutSubTree(input, i + 2 + q.Length);

                        input[i] = 'C';
                        input[i + 1] = 'D';
                        input.Insert(i + 2 + q.Length,p);
                        input.Insert(i + 2 + q.Length+ r.Length, "D" + r + p);
                    }


                    //revisar si alguno tiene
                }
            }

            return input;
        }

    }
}
