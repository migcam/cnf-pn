using System;
using System.Text;
using Xunit;
using pkg;

namespace tests
{
    public class Negation_tests
    {

        private void GenericStringBuilderTest(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = Negations.Delete_Negation(input);
            Assert.Equal(stroutput, output.ToString());
        }

        [Fact]
        public void test1() => GenericStringBuilderTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void test2() => GenericStringBuilderTest("NCNpp","DpNp");
        [Fact]
        public void test3() => GenericStringBuilderTest("NNNNNNNp","Np");
        [Fact]
        public void test4() => GenericStringBuilderTest("DNDNpqDpNp","DCpNqDpNp");

        // [Fact]
        // public void test5()
        // {
        //     string input = "DNDNqrDNDNpqDNpr";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DCqNrDCpNqDNpr", output);
        // }

        // [Fact]
        // public void test6()
        // {
        //     string input = "NCNpp";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DpNp", output);
        // }

        // [Fact]
        // public void test7()
        // {
        //     string input = "NNNNNNNp";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("Np", output);
        // }

        // [Fact]
        // public void test8()
        // {
        //     string input =  "DNDNpqDpNp";
        //     string output = Negations.Delete_Negation(input);
        //     Assert.Equal("DCpNqDpNp", output);
        // }

    }
}
