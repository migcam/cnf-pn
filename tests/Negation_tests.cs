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
            Negations.Delete_Negation(input);
            Assert.Equal(stroutput, input.ToString());
        }
        private void GenericStringTest(string strinput , string stroutput)
        {
            string output = Negations.Delete_Negation(strinput);
            Assert.Equal(stroutput, output);
        }

        [Fact]
        public void test1() => GenericStringBuilderTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void test2() => GenericStringBuilderTest("NCNpp","DpNp");
        [Fact]
        public void test3() => GenericStringBuilderTest("NNNNNNNp","Np");
        [Fact]
        public void test4() => GenericStringBuilderTest("DNDNpqDpNp","DCpNqDpNp");

        [Fact]
        public void test5() => GenericStringBuilderTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void test6() => GenericStringBuilderTest("NCNpp","DpNp");
        [Fact]
        public void test7() => GenericStringBuilderTest("NNNNNNNp","Np");
        [Fact]
        public void test8() => GenericStringBuilderTest("DNDNpqDpNp","DCpNqDpNp");

    }
}
