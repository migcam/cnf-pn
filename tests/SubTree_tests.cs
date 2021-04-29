using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using pkg;

namespace tests
{
    public class Copy_Tests
    {

        private void GenericStringBuilderTest(string strinput , string stroutput , int i)
        {
            StringBuilder input = new StringBuilder(strinput);
            StringBuilder output = SubTree.Copy(input, i);
            Assert.Equal(stroutput, output.ToString());
        }
        private void GenericStringTest(string strinput , string stroutput , int i)
        {
            // string input = "IIqrIIpqIpr";
            string res = SubTree.Copy(strinput, i);
            Assert.Equal(stroutput, res);
        }

        [Fact]
        public void CopySubTree_Test1()  => GenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_Test2() => GenericStringBuilderTest("IIqrIIpqIpr" , "IIpqIpr",4);
        
        [Fact]
        public void CopySubTree_Test3() => GenericStringBuilderTest("IIqrIIpqIpr" , "q",2);

        [Fact]
        public void CopySubTree_Test4()  => GenericStringBuilderTest("IIqrIIpqIpr" , "Iqr",1);

        [Fact]
        public void CopySubTree_Test5() => GenericStringTest("IIqrIIpqIpr" , "IIpqIpr",4);

        [Fact]
        public void CopySubTree_Test6() => GenericStringTest("IIqrIIpqIpr" , "q",2);

    }
}
