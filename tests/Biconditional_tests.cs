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

        [Fact]
        public void Delete_MaterialConditions_Test1() => GenericStringBuilderTest("Epq", "CIpqIqp");

        [Fact]
        public void Delete_MaterialConditions_Test2() => GenericStringBuilderTest("ECpqDab", "CICpqDabIDabCpq");

        [Fact]
        public void Delete_MaterialConditions_Test3() => GenericStringTest("Epq", "CIpqIqp");

        [Fact]
        public void Delete_MaterialConditions_Test4() => GenericStringTest("ECpqDab", "CICpqDabIDabCpq");

    }
}
