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
        private void GenericStringBuilder(StringBuilder input) 
        {
            CNF.ConvertFromStringBuilder(input);
        }

        private void GenericString(string input) => input = CNF.ConvertFromString(input);


        [Benchmark]
        public void ConvertStringBuilder() => GenericStringBuilder(new StringBuilder("IIpqDpNp"));
        [Benchmark]
        public void ConvertString() => GenericString("IIpqDpNp");

        [Benchmark]
        public void ConvertStringBuilder1() => GenericStringBuilder(new StringBuilder("NCNpp"));
        [Benchmark]
        public void ConvertString1() => GenericString("NCNpp");

        [Benchmark]
        public void ConvertStringBuilder2() => GenericStringBuilder(new StringBuilder("Iaz"));
        [Benchmark]
        public void ConvertString2() => GenericString("Iaz");

        [Benchmark]
        public void ConvertStringBuilder3() => GenericStringBuilder(new StringBuilder("NNNNNNNp"));
        [Benchmark]
        public void ConvertString3() => GenericString("NNNNNNNp");

        [Benchmark]
        public void ConvertStringBuilder4() => GenericStringBuilder(new StringBuilder("IIqrIIpqIpr"));
        [Benchmark]
        public void ConvertString4() => GenericString("IIqrIIpqIpr");

        [Benchmark]
        public void ConvertStringBuilder5() => GenericStringBuilder(new StringBuilder("Ipp"));
        [Benchmark]
        public void ConvertString5() => GenericString("Ipp");

        [Benchmark]
        public void ConvertStringBuilder6() => GenericStringBuilder(new StringBuilder("Ezz"));
        [Benchmark]
        public void ConvertString6() => GenericString("Ezz");

    }
}
