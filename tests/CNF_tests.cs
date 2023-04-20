using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class CNF_tests
    {

        [Fact]
        public void ConvertStringBuilderTest() => GenericStringBuilderTest("IIpqDpNp", "CDpDpDNqDpNpNp");
        [Fact]
        public void ConvertStringTest() => GenericStringTest("IIpqDpNp", "CDpDpDNqDpNpNp");
        [Fact]
        public void ConvertSpanTest() => GenericSpanTest("IIpqDpNp", "CDpDpDNqDpNpNp");
        [Fact]
        public void ConvertExpressionTest() => GenericExpressionTest("IIpqDpNp", "CDpDpDNqDpNpNp");


        [Fact]
        public void ConvertStringBuilderTest1() => GenericStringBuilderTest("NCNpp","DpNp");
        [Fact]
        public void ConvertStringTest1() => GenericStringTest("NCNpp","DpNp");
        [Fact]
        public void ConvertSpanTest1() => GenericSpanTest("NCNpp","DpNp");
        [Fact]
        public void ConvertExpressionTest1() => GenericExpressionTest("NCNpp","DpNp");


        [Fact]
        public void ConvertStringBuilderTest2() => GenericStringBuilderTest("Iaz","DNaz");
        [Fact]
        public void ConvertStringTest2() => GenericStringTest("Iaz","DNaz");
        [Fact]
        public void ConvertSpanTest2() => GenericSpanTest("Iaz","DNaz");
        [Fact]
        public void ConvertExpressionTest2() => GenericExpressionTest("Iaz","DNaz");


        [Fact]
        public void ConvertStringBuilderTest3() => GenericStringBuilderTest("NNNNNNNp","Np");
        [Fact]
        public void ConvertStringTest3() => GenericStringTest("NNNNNNNp","Np");
        [Fact]
        public void ConvertSpanTest3() => GenericSpanTest("NNNNNNNp","Np");
        [Fact]
        public void ConvertExpressionTest3() => GenericExpressionTest("NNNNNNNp","Np");


        [Fact]
        public void ConvertStringBuilderTest4() => GenericStringBuilderTest("IIqrIIpqIpr","CDqCDDNrCDpDNDNqDNprprpDNDNqDNprpr");
        [Fact]
        public void ConvertStringTest4() => GenericStringTest("IIqrIIpqIpr","CDqCDDNrCDpDNDNqDNprprpDNDNqDNprpr");
        [Fact]
        public void ConvertSpanTest4() => GenericSpanTest("IIqrIIpqIpr","CDqCDDNrCDpDNDNqDNprprpDNDNqDNprpr");
        [Fact]
        public void ConvertExpressionTest4() => GenericExpressionTest("IIqrIIpqIpr","CDqCDDNrCDpDNDNqDNprprpDNDNqDNprpr");


        [Fact]
        public void ConvertStringBuilderTest5() => GenericStringBuilderTest("Ipp","DNpp");
        [Fact]
        public void ConvertStringTest5() => GenericStringTest("Ipp","DNpp");
        [Fact]
        public void ConvertSpanTest5() => GenericSpanTest("Ipp","DNpp");
        [Fact]
        public void ConvertExpressionTest5() => GenericExpressionTest("Ipp","DNpp");
        

        [Fact]
        public void ConvertStringBuilderTest6() => GenericStringBuilderTest("Ezz","CDNzzDNzz");
        [Fact]
        public void ConvertStringTest6() => GenericStringTest("Ezz","CDNzzDNzz");
        [Fact]
        public void ConvertSpanTest6() => GenericSpanTest("Ezz","CDNzzDNzz");
        [Fact]
        public void ConvertExpressionTest6() => GenericExpressionTest("Ezz","CDNzzDNzz");


        #region helper methods
        private void GenericStringBuilderTest(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            CNF.ConvertFromStringBuilder(input);
            Assert.Equal(stroutput, input.ToString());
        }

        private void GenericStringTest(string strinput , string stroutput)
        {
            string output = CNF.ConvertFromString(strinput);
            Assert.Equal(stroutput, output);
        }

        private void GenericSpanTest(string strinput , string stroutput)
        {
            ReadOnlySpan<char> input = strinput;
            ReadOnlySpan<char>  output = CNF.ConvertFromSpan(input);
            Assert.Equal(stroutput, output.ToString());
        }

        private void GenericExpressionTest(string strinput , string stroutput)
        {
            var input  = new CnfExpressionParser(strinput).ToCNF();
            var output  = new CnfExpressionParser(strinput);
            Assert.Equal(output.ToString(),input.ToString());
        }

        #endregion


    }
}