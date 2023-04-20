using System.Text;
using Xunit;
using pkg;
using System;

namespace tests
{
    public class Implication_tests
    {
        [Fact]
        public void Delete_All_Implications_StringBuilder_Test()
        {
            StringBuilder input = new StringBuilder("IIqrIIpqIpr");
            Implication.Delete_All_Implications(input);          
            Assert.Equal("DNDNqrDNDNpqDNpr", input.ToString());
        }

        [Fact]
        public void Delete_All_Implications_String_Test()
        {
            string input = "IIqrIIpqIpr";
            string output = Implication.Delete_All_Implications(input);
            Assert.Equal("DNDNqrDNDNpqDNpr", output);
        }

        [Fact]
        public void Delete_All_Implications_Span_Test()
        {
            ReadOnlySpan<char> input = "IIqrIIpqIpr";
            ReadOnlySpan<char> output = Implication.Delete_All_Implications(input);
            Assert.Equal("DNDNqrDNDNpqDNpr", output.ToString());
        }

        [Fact]
        public void Delete_All_Implications_Expression_Test()
        {
            CnfExpressionParser input = new CnfExpressionParser("IIqrIIpqIpr");
            CnfExpressionParser output = new CnfExpressionParser("DNDNqrDNDNpqDNpr");
            Assert.Equal(input.ToString(), output.ToString());
        }


    }
}
