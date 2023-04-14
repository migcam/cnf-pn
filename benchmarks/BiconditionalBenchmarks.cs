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
        private void GenericStringBuilder(StringBuilder strinput)
        {
            Biconditional.Delete_MaterialConditions(strinput);
        }

        private void GenericString(string input)
        {
            input = Biconditional.Delete_MaterialConditions(input);
        }

        [Benchmark]
        public void DeleteMaterialConditions1StringBuilder() => GenericStringBuilder(new StringBuilder("Epq"));
        [Benchmark]
        public void DeleteMaterialConditions1String() => GenericString("Epq");

        [Benchmark]
        public void DeleteMaterialConditions2StringBuilder() => GenericStringBuilder(new StringBuilder("ECpqDab"));
        [Benchmark]
        public void DeleteMaterialConditions2String() => GenericString("ECpqDab");

    }
}
