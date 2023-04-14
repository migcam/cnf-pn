using System.Text;
using pkg;
using BenchmarkDotNet.Attributes;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class ImplicationBenchmarks
    {
        [Benchmark]
        public void Delete_All_Implications_Test()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            Implication.Delete_All_Implications(input);
        }

        [Benchmark]
        public void Delete_All_Implications_Test1()
        {
            string input = "IIqrIIpqIpr";
            string output = Implication.Delete_All_Implications(input);
            
        }


    }
}
