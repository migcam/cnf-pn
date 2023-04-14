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
            Implication.Delete_All_Implications(new StringBuilder("IIqrIIpqIpr"));
        }

        [Benchmark]
        public void Delete_All_Implications_Test1()
        {
            string output = Implication.Delete_All_Implications("IIqrIIpqIpr");  
        }


    }
}
