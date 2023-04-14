using System;
using System.Text;
using pkg;
using BenchmarkDotNet.Attributes;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class NegationBenchmarks
    {

        private void GenericStringBuilder(StringBuilder input)
        {
            Negations.Delete_Negation(input);
        }

        [Benchmark]
        public void NegationStringBuilder1() => GenericStringBuilder(new StringBuilder("DNDNqrDNDNpqDNpr"));
        [Benchmark]
        public void NegationStringBuilder2() => GenericStringBuilder(new StringBuilder("NCNpp"));
        [Benchmark]
        public void NegationStringBuilder3() => GenericStringBuilder(new StringBuilder("NNNNNNNp"));
        [Benchmark]
        public void NegationStringBuilder4() => GenericStringBuilder(new StringBuilder("DNDNpqDpNp"));

        // [Benchmark]
        // public void test5()
        // {
        //     string input = "DNDNqrDNDNpqDNpr";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DCqNrDCpNqDNpr", output);
        // }

        // [Benchmark]
        // public void test6()
        // {
        //     string input = "NCNpp";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DpNp", output);
        // }

        [Benchmark]
        public void Negation_3_String()
        {
            string output = Negations.Delete_Negation("NNNNNNNp");
        }

        // [Benchmark]
        // public void test8()
        // {
        //     string input =  "DNDNpqDpNp";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DCpNqDpNp", output);
        // }

    }
}
