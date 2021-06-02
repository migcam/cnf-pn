using System;
using System.Collections.Generic;
// using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkg
{
    public class CNF
    {
        public CNF(string expression){
            expression =  Biconditional.Delete_MaterialConditions(expression);
            expression = Implication.Delete_All_Implications(expression);

        }

    }
}