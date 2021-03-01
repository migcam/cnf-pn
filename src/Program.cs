using System;
using System.Collections.Generic;
using System.Text;
//using System.Linq;
using pkg;

namespace dpll_dotnet_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());
            bool[] res = new bool[n];

            for (int i = 0; i < n; i++)
            {
                res[i] = Convert_to_FNC(new StringBuilder(Console.ReadLine()));
            }

            foreach (bool b in res)
            {
                if (b)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }

        }

        //FNC = OR adentro, AND afuera
        public static bool Convert_to_FNC(StringBuilder input)
        {
            //eliminar todas las dobles implicaciones
            Biconditional.Delete_MaterialConditions(input);

            //eliminar todas las implicaiones
            input = MaterialConditional.Delete_All_Implications(input);

            //eliminar doble negaciones
            //interiorizar negaciones          
            //-(pvq) == -p^-q
            //-(p^q) == -pv-q

            

            //input = Delete_Negation(input);

            //introducir ORs y extraer ANDs
            //pv(q^r) == (pvq)^(pvr)

            return false;
        }


    }

}


