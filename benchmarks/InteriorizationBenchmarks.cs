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
    public class DistributionBenchmarks
    {

        private void GenericStringBuilderDistributionOR(StringBuilder input)
        {
            Distribution.Distribution_ORs(input);
        }

        private void GenericStringDistributionOR(string input)
        {
            string output = Distribution.Distribution_ORs(input);
        }

        [Benchmark]
        public void Distribution_ORs_1_StringBuilder() => GenericStringBuilderDistributionOR(new StringBuilder("DCqrp"));
        [Benchmark]
        public void Distribution_ORs_1_String() => GenericStringDistributionOR("DCqrp");

        [Benchmark]
        public void Distribution_ORs_2_StringBuilder() => GenericStringBuilderDistributionOR(new StringBuilder("DpCqr"));
        [Benchmark]
        public void Distribution_ORs_2_String() => GenericStringDistributionOR("DpCqr");

        [Benchmark]
        public void Distribution_ORs_3_StringBuilder() => GenericStringBuilderDistributionOR(new StringBuilder("DCabCqr"));
        [Benchmark]
        public void Distribution_ORs_3_String() => GenericStringDistributionOR("DCabCqr");

    }
}
