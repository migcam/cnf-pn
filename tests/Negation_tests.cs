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

        private void GenericSpanTest(string strinput , string stroutput)
        {
            ReadOnlySpan<char> output = Negations.Delete_Negation(strinput.AsSpan());
            Assert.Equal(stroutput, output.ToString());
        }

        private void GenericExpressionTest(string strinput , string stroutput)
        {
            CnfExpressionParser input = new CnfExpressionParser(strinput);
            input.ReduceNots();
            CnfExpressionParser output = new CnfExpressionParser(stroutput);
            Assert.Equal(output.ToString(), input.ToString());
        }

        // StringBuilder tests
        [Fact]
        public void Delete_Negation_StringBuilder_1() => GenericStringBuilderTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void Delete_Negation_StringBuilder_2() => GenericStringBuilderTest("NCNpp","DpNp");
        [Fact]
        public void Delete_Negation_StringBuilder_3() => GenericStringBuilderTest("NNNNNNNp","Np");
        [Fact]
        public void Delete_Negation_StringBuilder_4() => GenericStringBuilderTest("DNDNpqDpNp","DCpNqDpNp");

        // String tests
        [Fact]
        public void Delete_Negation_String_1() => GenericStringTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void Delete_Negation_String_2() => GenericStringTest("NCNpp","DpNp");
        [Fact]
        public void Delete_Negation_String_3() => GenericStringTest("NNNNNNNp","Np");
        [Fact]
        public void Delete_Negation_String_4() => GenericStringTest("DNDNpqDpNp","DCpNqDpNp");

        // Span tests 
        [Fact]
        public void Delete_Negation_Span_1() => GenericSpanTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        [Fact]
        public void Delete_Negation_Span_2() => GenericSpanTest("NCNpp","DpNp");
        [Fact]
        public void Delete_Negation_Span_3() => GenericSpanTest("NNNNNNNp","Np");
        [Fact]
        public void Delete_Negation_Span_4() => GenericSpanTest("DNDNpqDpNp","DCpNqDpNp");

        // Expression tests 
        // [Fact]
        // public void Delete_Negation_Expression_1() => GenericExpressionTest("DNDNqrDNDNpqDNpr","DCqNrDCpNqDNpr");
        // [Fact]
        // public void Delete_Negation_Expression_2() => GenericExpressionTest("NCNpp","DpNp");
        [Fact]
        public void Delete_Negation_Expression_3() => GenericExpressionTest("NNNNNNNp","Np");
        // [Fact]
        // public void Delete_Negation_Expression_4() => GenericExpressionTest("DNDNpqDpNp","DCpNqDpNp");

    }
}
