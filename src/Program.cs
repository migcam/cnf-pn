using System;
using pkg;

namespace dpll_dotnet_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());
            string[] res = new string[n];

            for (int i = 0; i < n; i++)
            {
                res[i] = CNF.Convert(Console.ReadLine());
            }

            Console.WriteLine("====================");

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

        }

    }

}


