using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class Distribution_Tests
    {

        private void GenericStringBuilderDistributionOR(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            Distribution.Distribution_ORs(input);
            Assert.Equal(stroutput, input.ToString());
        }

        private void GenericStringDistributionOR(string input , string stroutput)
        {
            string output = Distribution.Distribution_ORs(input);
            Assert.Equal(stroutput, output);
        }

        private void GenericSpanDistributionOR(string strInput , string stroutput)
        {
            ReadOnlySpan<char> input = strInput;
            ReadOnlySpan<char> output = Distribution.Distribution_ORs(input);
            Assert.Equal(stroutput, output.ToString());
        }


        // String builder tests
        [Fact]
        public void Distribution_StringBuilder1() => GenericStringBuilderDistributionOR("DCqrp" , "CDqpDrp");
        [Fact]
        public void Distribution_StringBuilder2() => GenericStringBuilderDistributionOR("DpCqr" , "CDpqDpr");
        [Fact]
        public void Distribution_StringBuilder3() => GenericStringBuilderDistributionOR("DCabCqr" , "CCDaqDbqCDarDbr");


        //String tests
        [Fact]
        public void Distribution_String1() => GenericStringDistributionOR("DCqrp", "CDqpDrp");
        [Fact]
        public void Distribution_String2() => GenericStringDistributionOR("DpCqr", "CDpqDpr");
        [Fact]
        public void Distribution_String3() => GenericStringDistributionOR("DCabCqr", "CCDaqDbqCDarDbr");


        //Span tests
        [Fact]
        public void Distribution_Span1() => GenericStringDistributionOR("DCqrp", "CDqpDrp");
        [Fact]
        public void Distribution_Span2() => GenericStringDistributionOR("DpCqr", "CDpqDpr");
        [Fact]
        public void Distribution_Span3() => GenericStringDistributionOR("DCabCqr", "CCDaqDbqCDarDbr");


    }
}
