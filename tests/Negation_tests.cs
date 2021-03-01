using System;
using System.Text;
using Xunit;
using pkg;

namespace tests
{
    public class Negation_tests
    {
        [Fact]
        public void test1()
        {
            StringBuilder input = new StringBuilder("DNDNqrDNDNpqDNpr");
            StringBuilder output = Negations.Delete_Negation(input);
            Assert.Equal("DCqNrDCpNqDNpr", output.ToString());
        }

        [Fact]
        public void test2()
        {
            StringBuilder input = new StringBuilder("NCNpp");
            StringBuilder output = Negations.Delete_Negation(input);
            Assert.Equal("DpNp", output.ToString());
        }

        [Fact]
        public void test3()
        {
            StringBuilder input = new StringBuilder("NNNNNNNp");
            StringBuilder output = Negations.Delete_Negation(input);
            Assert.Equal("Np", output.ToString());
        }

        [Fact]
        public void test4()
        {
            StringBuilder input = new StringBuilder("DNDNpqDpNp");
            StringBuilder output = Negations.Delete_Negation(input);
            Assert.Equal("DCpNqDpNp", output.ToString());
        }
    }
}
