using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class Interiorization_Tests
    {

        private void GenericStringBuilderInteriorizationOR(string strinput , string stroutput)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = Interiorization.Interiorization_ORs(input);
            Assert.Equal(stroutput, output.ToString());
        }

        private void GenericStringInteriorizationOR(string input , string stroutput)
        {
            string output = Interiorization.Interiorization_ORs(input);
            Assert.Equal(stroutput, output);
        }

        [Fact]
        public void Interiorization_ORs_test1() => GenericStringBuilderInteriorizationOR("DCqrp" , "CDqpDrp");
        [Fact]
        public void Interiorization_ORs_test2() => GenericStringBuilderInteriorizationOR("DpCqr" , "CDpqDpr");
        [Fact]
        public void Interiorization_ORs_test3() => GenericStringBuilderInteriorizationOR("DCabCqr" , "CCDaqDbqCDarDbr");

        [Fact]
        public void Interiorization_ORs_test4() => GenericStringInteriorizationOR("DCqrp", "CDqpDrp");
        [Fact]
        public void Interiorization_ORs_test5() => GenericStringInteriorizationOR("DpCqr", "CDpqDpr");
        [Fact]
        public void Interiorization_ORs_test6() => GenericStringInteriorizationOR("DCabCqr", "CCDaqDbqCDarDbr");

    }
}
