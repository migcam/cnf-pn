using System;
using System.Text;
using pkg;
using BenchmarkDotNet.Attributes;

namespace benchmarks
{
    [MemoryDiagnoser]
    public class NegationBenchmarks
    {

        private void GenericStringBuilder(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = Negations.Delete_Negation(input);
        }

        [Benchmark]
        public void NegationStringBuilder1() => GenericStringBuilder("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Benchmark]
        public void NegationStringBuilder2() => GenericStringBuilder("NCNpp","DpNp");
        [Benchmark]
        public void NegationStringBuilder3() => GenericStringBuilder("NNNNNNNp","Np");
        [Benchmark]
        public void NegationStringBuilder4() => GenericStringBuilder("DNDNpqDpNp","DCpNqDpNp");

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
