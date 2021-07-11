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
        private void GenericStringBuilder(string strinput)
        {
            StringBuilder input = new StringBuilder(strinput);
            CNF.Convert(input);
        }

        private void GenericString(string input) => input = CNF.Convert(input);


        [Benchmark]
        public void ConvertStringBuilder() => GenericStringBuilder("IIpqDpNp");
        [Benchmark]
        public void ConvertString() => GenericString("IIpqDpNp");

        [Benchmark]
        public void ConvertStringBuilder1() => GenericStringBuilder("NCNpp");
        [Benchmark]
        public void ConvertString1() => GenericString("NCNpp");

        [Benchmark]
        public void ConvertStringBuilder2() => GenericStringBuilder("Iaz");
        [Benchmark]
        public void ConvertString2() => GenericString("Iaz");

        [Benchmark]
        public void ConvertStringBuilder3() => GenericStringBuilder("NNNNNNNp");
        [Benchmark]
        public void ConvertString3() => GenericString("NNNNNNNp");

        [Benchmark]
        public void ConvertStringBuilder4() => GenericStringBuilder("IIqrIIpqIpr");
        [Benchmark]
        public void ConvertString4() => GenericString("IIqrIIpqIpr");

        [Benchmark]
        public void ConvertStringBuilder5() => GenericStringBuilder("Ipp");
        [Benchmark]
        public void ConvertString5() => GenericString("Ipp");

        [Benchmark]
        public void ConvertStringBuilder6() => GenericStringBuilder("Ezz");
        [Benchmark]
        public void ConvertString6() => GenericString("Ezz");

    }
}
