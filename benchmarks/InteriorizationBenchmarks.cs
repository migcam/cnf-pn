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

        private void GenericStringBuilderDistributionOR(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = Distribution.Distribution_ORs(input);
        }

        private void GenericStringDistributionOR(string input , string stroutput)
        {
            string output = Distribution.Distribution_ORs(input);
        }

        [Benchmark]
        public void Distribution_ORs_1_StringBuilder() => GenericStringBuilderDistributionOR("DCqrp" , "CDqpDrp");
        [Benchmark]
        public void Distribution_ORs_2_StringBuilder() => GenericStringBuilderDistributionOR("DpCqr" , "CDpqDpr");
        [Benchmark]
        public void Distribution_ORs_3_StringBuilder() => GenericStringBuilderDistributionOR("DCabCqr" , "CCDaqDbqCDarDbr");

        [Benchmark]
        public void Distribution_ORs_1_String() => GenericStringDistributionOR("DCqrp", "CDqpDrp");
        [Benchmark]
        public void Distribution_ORs_2_String() => GenericStringDistributionOR("DpCqr", "CDpqDpr");
        [Benchmark]
        public void Distribution_ORs_3_String() => GenericStringDistributionOR("DCabCqr", "CCDaqDbqCDarDbr");

    }
}
