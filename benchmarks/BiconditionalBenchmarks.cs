using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkg;
using BenchmarkDotNet.Attributes;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class BiconditionalBenchmarks
    {
        private void GenericStringBuilder(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            Biconditional.Delete_MaterialConditions(input);
        }

        private void GenericString(string input , string stroutput)
        {
            input = Biconditional.Delete_MaterialConditions(input);
        }

        [Benchmark]
        public void DeleteMaterialConditions1StringBuilder() => GenericStringBuilder("Epq", "CIpqIqp");

        [Benchmark]
        public void DeleteMaterialConditions2StringBuilder() => GenericStringBuilder("ECpqDab", "CICpqDabIDabCpq");

        [Benchmark]
        public void DeleteMaterialConditions1String() => GenericString("Epq", "CIpqIqp");

        [Benchmark]
        public void DeleteMaterialConditions2String() => GenericString("ECpqDab", "CICpqDabIDabCpq");

    }
}
