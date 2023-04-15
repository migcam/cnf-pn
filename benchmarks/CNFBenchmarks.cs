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
    public class CNFBenchmarks
    {
        private void GenericStringBuilderBenchmark(StringBuilder input) 
        {
            CNF.ConvertFromStringBuilder(input);
        }

        private void GenericStringBenchmark(string input) => input = CNF.ConvertFromString(input);

        private void GeneticSpanBenchmark(ReadOnlySpan<char> input){
            var res =CNF.ConvertFromString(input);
        }


        [Benchmark]
        public void ConvertStringBuilder() => GenericStringBuilderBenchmark(new StringBuilder("IIpqDpNp"));
        [Benchmark]
        public void ConvertString() => GenericStringBenchmark("IIpqDpNp");
        [Benchmark]
        public void ConvertSpan() => GeneticSpanBenchmark("IIpqDpNp");


        [Benchmark]
        public void ConvertStringBuilder1() => GenericStringBuilderBenchmark(new StringBuilder("NCNpp"));
        [Benchmark]
        public void ConvertString1() => GenericStringBenchmark("NCNpp");
        [Benchmark]
        public void ConvertSpan1() => GeneticSpanBenchmark("NCNpp");


        [Benchmark]
        public void ConvertStringBuilder2() => GenericStringBuilderBenchmark(new StringBuilder("Iaz"));
        [Benchmark]
        public void ConvertString2() => GenericStringBenchmark("Iaz");
        [Benchmark]
        public void ConvertSpan2() => GeneticSpanBenchmark("Iaz");


        [Benchmark]
        public void ConvertStringBuilder3() => GenericStringBuilderBenchmark(new StringBuilder("NNNNNNNp"));
        [Benchmark]
        public void ConvertString3() => GenericStringBenchmark("NNNNNNNp");
        [Benchmark]
        public void ConvertSpan3() => GeneticSpanBenchmark("NNNNNNNp");


        [Benchmark]
        public void ConvertStringBuilder4() => GenericStringBuilderBenchmark(new StringBuilder("IIqrIIpqIpr"));
        [Benchmark]
        public void ConvertString4() => GenericStringBenchmark("IIqrIIpqIpr");
        [Benchmark]
        public void ConvertSpan4() => GeneticSpanBenchmark("IIqrIIpqIpr");


        [Benchmark]
        public void ConvertStringBuilder5() => GenericStringBuilderBenchmark(new StringBuilder("Ipp"));
        [Benchmark]
        public void ConvertString5() => GenericStringBenchmark("Ipp");
        [Benchmark]
        public void ConvertSpan5() => GeneticSpanBenchmark("Ipp");
        

        [Benchmark]
        public void ConvertStringBuilder6() => GenericStringBuilderBenchmark(new StringBuilder("Ezz"));
        [Benchmark]
        public void ConvertString6() => GenericStringBenchmark("Ezz");
        [Benchmark]
        public void ConvertSpan6() => GeneticSpanBenchmark("Ezz");

    }
}
