using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class Biconditional_tests
    {
        private void GenericStringBuilderTest(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            Biconditional.Delete_MaterialConditions(input);
            Assert.Equal(stroutput, input.ToString());
        }

        private void GenericStringTest(string input , string stroutput)
        {
            input = Biconditional.Delete_MaterialConditions(input);
            Assert.Equal(stroutput, input);
        }

        private void GenericSpanTest(string strInput , string stroutput)
        {
            ReadOnlySpan<char> input = strInput;
            input = Biconditional.Delete_MaterialConditions(input);
            Assert.Equal(stroutput, input.ToString());
        }


        // StringBuiler tests
        [Fact]
        public void Delete_MaterialConditions_StringBuilder_Test1() => GenericStringBuilderTest("Epq", "CIpqIqp");

        [Fact]
        public void Delete_MaterialConditions_StringBuilder_Test2() => GenericStringBuilderTest("ECpqDab", "CICpqDabIDabCpq");

        // String tests
        [Fact]
        public void Delete_MaterialConditions_String_Test3() => GenericStringTest("Epq", "CIpqIqp");

        [Fact]
        public void Delete_MaterialConditions_String_Test4() => GenericStringTest("ECpqDab", "CICpqDabIDabCpq");

        // Span tests
        [Fact]
        public void Delete_MaterialConditions_Span_Test3() => GenericSpanTest("Epq", "CIpqIqp");

        [Fact]
        public void Delete_MaterialConditions_Span_Test4() => GenericStringTest("ECpqDab", "CICpqDabIDabCpq");

    }
}
