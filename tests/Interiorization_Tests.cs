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

        [Fact]
        public void Distribution_ORs_test1() => GenericStringBuilderDistributionOR("DCqrp" , "CDqpDrp");
        [Fact]
        public void Distribution_ORs_test2() => GenericStringBuilderDistributionOR("DpCqr" , "CDpqDpr");
        [Fact]
        public void Distribution_ORs_test3() => GenericStringBuilderDistributionOR("DCabCqr" , "CCDaqDbqCDarDbr");

        [Fact]
        public void Distribution_ORs_test4() => GenericStringDistributionOR("DCqrp", "CDqpDrp");
        [Fact]
        public void Distribution_ORs_test5() => GenericStringDistributionOR("DpCqr", "CDpqDpr");
        [Fact]
        public void Distribution_ORs_test6() => GenericStringDistributionOR("DCabCqr", "CCDaqDbqCDarDbr");

    }
}
