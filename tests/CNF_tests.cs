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
    

    }
}